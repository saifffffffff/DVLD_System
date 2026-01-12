using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using DVLD_Data.Dtos;
using DVLD_Data.Interfaces;

namespace DVLD_Data.Repositories
{
    public class DetainedLicenseRepository : IDetainedLicenseRepository
    {
        public int Add(DetainedLicenseDto dto)
        {
            int GeneratedId = -1;
            var Conn = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = @"
                INSERT INTO DetainedLicenses
                (
                    LicenseID,
                    DetainDate,
                    FineFees,
                    CreatedByUserID,
                    IsReleased,
                    ReleaseDate,
                    ReleasedByUserID,
                    ReleaseApplicationID
                )
                VALUES
                (
                    @LicenseID,
                    @DetainDate,
                    @FineFees,
                    @CreatedByUserID,
                    @IsReleased,
                    @ReleaseDate,
                    @ReleasedByUserID,
                    @ReleaseApplicationID
                );
                SELECT SCOPE_IDENTITY();";

            var Command = new SqlCommand(Query, Conn);

            Command.Parameters.AddWithValue("@LicenseID", dto.LicenseId);
            Command.Parameters.AddWithValue("@DetainDate", DateTime.Now);
            Command.Parameters.AddWithValue("@FineFees", dto.FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", dto.CreatedByUserId);
            Command.Parameters.AddWithValue("@IsReleased", dto.IsReleased);

            if (dto.ReleaseDate.HasValue)
                Command.Parameters.AddWithValue("@ReleaseDate", dto.ReleaseDate.Value);
            else
                Command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);

            if (dto.ReleasedByUserId.HasValue)
                Command.Parameters.AddWithValue("@ReleasedByUserID", dto.ReleasedByUserId.Value);
            else
                Command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);

            if (dto.ReleaseApplicationId.HasValue)
                Command.Parameters.AddWithValue("@ReleaseApplicationID", dto.ReleaseApplicationId.Value);
            else
                Command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);

            try
            {
                Conn.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                    GeneratedId = Convert.ToInt32(Result);
            }
            catch { }
            finally
            {
                Conn.Close();
            }

            return GeneratedId;
        }

        public bool Update(DetainedLicenseDto dto)
        {
            int AffectedRows = 0;
            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = @"
                UPDATE DetainedLicenses
                SET
                    LicenseID = @LicenseID,
                    FineFees = @FineFees,
                    CreatedByUserID = @CreatedByUserID,
                    IsReleased = @IsReleased,
                    ReleaseDate = @ReleaseDate,
                    ReleasedByUserID = @ReleasedByUserID,
                    ReleaseApplicationID = @ReleaseApplicationID
                WHERE DetainID = @DetainID";

            var Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@DetainID", dto.Id);
            Command.Parameters.AddWithValue("@LicenseID", dto.LicenseId);
            Command.Parameters.AddWithValue("@FineFees", dto.FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", dto.CreatedByUserId);
            Command.Parameters.AddWithValue("@IsReleased", dto.IsReleased);

            Command.Parameters.AddWithValue("@ReleaseDate", dto.ReleaseDate ?? (object)DBNull.Value);
            Command.Parameters.AddWithValue("@ReleasedByUserID", dto.ReleasedByUserId ?? (object)DBNull.Value);
            Command.Parameters.AddWithValue("@ReleaseApplicationID", dto.ReleaseApplicationId ?? (object)DBNull.Value);

            try
            {
                Connection.Open();
                AffectedRows = Command.ExecuteNonQuery();
            }
            catch { }
            finally
            {
                Connection.Close();
            }

            return AffectedRows > 0;
        }

        public DetainedLicenseDto GetById(int Id)
        {
            DetainedLicenseDto dto = null;
            string Query = "SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID";
            var Conn = new SqlConnection(clsDataSettings.ConncetionString);
            var Comm = new SqlCommand(Query, Conn);
            Comm.Parameters.AddWithValue("@DetainID", Id);

            try
            {
                Conn.Open();
                var reader = Comm.ExecuteReader();
                if (reader.Read())
                {
                    dto = new DetainedLicenseDto();
                    dto.Id = (int)reader["DetainID"];
                    dto.LicenseId = (int)reader["LicenseID"];
                    dto.FineFees = (decimal)reader["FineFees"];
                    dto.CreatedByUserId = (int)reader["CreatedByUserID"];
                    dto.DetainDate = (DateTime)reader["DetainDate"];
                    dto.IsReleased = (bool)reader["IsReleased"];

                    dto.ReleaseDate = reader["ReleaseDate"] == DBNull.Value ? null : (DateTime?)reader["ReleaseDate"];
                    dto.ReleasedByUserId = reader["ReleasedByUserID"] == DBNull.Value ? null : (int?)reader["ReleasedByUserID"];
                    dto.ReleaseApplicationId = reader["ReleaseApplicationID"] == DBNull.Value ? null : (int?)reader["ReleaseApplicationID"];
                }
                reader.Close();
            }
            catch { }
            finally
            {
                Conn.Close();
            }

            return dto;
        }

        public bool IsExist(int Id)
        {
            bool IsFound = false;
            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = "SELECT 1 FROM DetainedLicenses WHERE DetainID = @Id";
            var Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Id", Id);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null) IsFound = true;
            }
            catch { IsFound = false; }
            finally { Connection.Close(); }

            return IsFound;
        }

        public DataTable GetAll()
        {
            var DataTable = new DataTable();
            var Conn = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = @"select * from DetainedLicenses_View order by IsReleased ,DetainID";


            var Command = new SqlCommand(Query, Conn);

            try
            {
                Conn.Open();
                SqlDataReader reader = Command.ExecuteReader();
                DataTable.Load(reader);
                reader.Close();
            }
            catch { }
            finally
            {
                Conn.Close();
            }

            return DataTable;
        }

        public bool DeleteById(int Id)
        {
            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = "DELETE FROM DetainedLicenses WHERE DetainID = @ID";
            var Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ID", Id);
            int AffectedRows = 0;

            try
            {
                Connection.Open();
                AffectedRows = Command.ExecuteNonQuery();
            }
            catch { }
            finally
            {
                Connection.Close();
            }

            return AffectedRows > 0;
        }

        
        /// <returns>returns the id of an not released detained license ,returns -1 if not found</returns>
        public int GetDetainedLicenseIdByLicenseId(int LicenseId)
        {
            int DetainedLicenseId = -1;
            
            string Query = "SELECT * FROM DetainedLicenses WHERE LicenseId = @LicenseId and IsReleased = 0";
            var Conn = new SqlConnection(clsDataSettings.ConncetionString);
            var Comm = new SqlCommand(Query, Conn);
            Comm.Parameters.AddWithValue("@LicenseId", LicenseId);

            try
            {
                Conn.Open();
                var result = Comm.ExecuteScalar();
                DetainedLicenseId = result != null ? (int)result : -1;
            }
            catch { }
            finally
            {
                Conn.Close();
            }

            return DetainedLicenseId;
        }

        public bool Release(int DetainedLicenseId, int ReleasedByUser, int ReleaseApplication)
        {
            string Query = @"
                UPDATE DetainedLicenses
                SET 
                    IsReleased = 1,
                    ReleaseDate = GetDate(),
                    ReleasedByUserID = @ReleasedByUserID,
                    ReleaseApplicationID = @ReleaseApplicationID
                WHERE DetainID = @DetainID";
            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            var Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@DetainID", DetainedLicenseId);
            Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUser);
            Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplication);
            
            try
            {
                Connection.Open();
                int AffectedRows = Command.ExecuteNonQuery();
                return AffectedRows > 0;
            }
            catch{return false;}
            
            finally{ Connection.Close();}

        }
    }
}