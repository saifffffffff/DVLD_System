using System;
using System.Data;
using System.Data.SqlClient;
using DVLD_Data.Dtos;
using DVLD_Data.Interfaces;

namespace DVLD_Data.Repositries
{
    public class LicenseRepository : ILicenseRepository
    {
        public bool IsExist(int Id)
        {
            bool IsFound = false;
            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = "SELECT 1 FROM Licenses WHERE LicenseID = @Id";
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
            string Query = "SELECT * FROM Licenses";
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

        public LicenseDto GetById(int Id)
        {
            string Query = "SELECT * FROM Licenses WHERE LicenseID = @Id";
            var Conn = new SqlConnection(clsDataSettings.ConncetionString);
            var Comm = new SqlCommand(Query, Conn);
            Comm.Parameters.AddWithValue("@Id", Id);

            LicenseDto dto = null;

            try
            {
                Conn.Open();
                var reader = Comm.ExecuteReader();

                if (reader.Read())
                {
                    dto = new LicenseDto();

                    dto.Id = reader.GetInt32(reader.GetOrdinal("LicenseID"));
                    dto.ApplicationId = reader.GetInt32(reader.GetOrdinal("ApplicationID"));
                    dto.DriverId = reader.GetInt32(reader.GetOrdinal("DriverID"));
                    dto.LicenseClassId = reader.GetInt32(reader.GetOrdinal("LicenseClassID"));
                    dto.CreatedByUserId = reader.GetInt32(reader.GetOrdinal("CreatedByUserID"));
                    dto.IssueDate = reader.GetDateTime(reader.GetOrdinal("IssueDate"));
                    dto.ExpirationDate = reader.GetDateTime(reader.GetOrdinal("ExpirationDate"));

                    // Notes is nullable
                    if (!reader.IsDBNull(reader.GetOrdinal("Notes")))
                        dto.Notes = reader.GetString(reader.GetOrdinal("Notes"));
                    else
                        dto.Notes = string.Empty;

                    dto.PaidFees = reader.GetDecimal(reader.GetOrdinal("PaidFees"));
                    dto.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                    dto.IssueReason = (LicenseDto.enIssueReason)reader.GetByte(reader.GetOrdinal("IssueReason"));
                }

                reader.Close();
            }
            catch { }
            finally { Conn.Close(); }

            return dto;
        }

        public bool DeleteById(int Id)
        {
            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = "DELETE FROM Licenses WHERE LicenseID = @ID";
            var Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ID", Id);

            int AffectedRows = 0;

            try
            {
                Connection.Open();
                AffectedRows = Command.ExecuteNonQuery();
            }
            catch { }
            finally { Connection.Close(); }

            return AffectedRows == 1;
        }

        public int Add(LicenseDto dto)
        {
            int GeneratedId = -1;
            var Conn = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = @"
                INSERT INTO Licenses
                (
                    ApplicationID,
                    DriverID,
                    LicenseClassID,
                    CreatedByUserID,
                    IssueDate,
                    ExpirationDate,
                    Notes,
                    PaidFees,
                    IsActive,
                    IssueReason
                )
                VALUES
                (
                    @ApplicationID,
                    @DriverID,
                    @LicenseClassID,
                    @CreatedByUserID,
                    @IssueDate,
                    @ExpirationDate,
                    @Notes,
                    @PaidFees,
                    @IsActive,
                    @IssueReason
                );
                Update Applications Set ApplicationStatus = 3 where ApplicationID = @ApplicationID;
                SELECT SCOPE_IDENTITY();";

            var Command = new SqlCommand(Query, Conn);

            Command.Parameters.AddWithValue("@ApplicationID", dto.ApplicationId);
            Command.Parameters.AddWithValue("@DriverID", dto.DriverId);
            Command.Parameters.AddWithValue("@LicenseClassID", dto.LicenseClassId);
            Command.Parameters.AddWithValue("@CreatedByUserID", dto.CreatedByUserId);
            Command.Parameters.AddWithValue("@IssueDate", dto.IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", dto.ExpirationDate);

            if (string.IsNullOrEmpty(dto.Notes))
                Command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@Notes", dto.Notes);

            Command.Parameters.AddWithValue("@PaidFees", dto.PaidFees);
            Command.Parameters.AddWithValue("@IsActive", dto.IsActive);
            Command.Parameters.AddWithValue("@IssueReason", dto.IssueReason);

            try
            {
                Conn.Open();
                object Result = Command.ExecuteScalar();
                GeneratedId = Result is null ? -1 : Convert.ToInt32(Result);
            }
            catch { }
            finally { Conn.Close(); }

            return GeneratedId;
        }

        public bool Update(LicenseDto dto)
        {
            int AffectedRows = 0;
            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = @"
                UPDATE Licenses
                SET
                    ApplicationID = @ApplicationID,
                    DriverID = @DriverID,
                    LicenseClassID = @LicenseClassID,
                    CreatedByUserID = @CreatedByUserID,
                    IssueDate = @IssueDate,
                    ExpirationDate = @ExpirationDate,
                    Notes = @Notes,
                    PaidFees = @PaidFees,
                    IsActive = @IsActive,
                    IssueReason = @IssueReason
                WHERE LicenseID = @LicenseID";

            var Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", dto.Id);
            Command.Parameters.AddWithValue("@ApplicationID", dto.ApplicationId);
            Command.Parameters.AddWithValue("@DriverID", dto.DriverId);
            Command.Parameters.AddWithValue("@LicenseClassID", dto.LicenseClassId);
            Command.Parameters.AddWithValue("@CreatedByUserID", dto.CreatedByUserId);
            Command.Parameters.AddWithValue("@IssueDate", dto.IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", dto.ExpirationDate);

            if (dto.Notes != null)
                Command.Parameters.AddWithValue("@Notes", dto.Notes);
            else
                Command.Parameters.AddWithValue("@Notes", DBNull.Value);

            Command.Parameters.AddWithValue("@PaidFees", dto.PaidFees);
            Command.Parameters.AddWithValue("@IsActive", dto.IsActive);
            Command.Parameters.AddWithValue("@IssueReason", dto.IssueReason);

            try
            {
                Connection.Open();
                AffectedRows = Command.ExecuteNonQuery();
            }
            catch { }
            finally { Connection.Close(); }

            return AffectedRows > 0;
        }

        public LicenseDto GetByApplicationId(int ApplicationId)
        {
            string Query = "SELECT * FROM Licenses WHERE ApplicationID = @Id";
            var Conn = new SqlConnection(clsDataSettings.ConncetionString);
            var Comm = new SqlCommand(Query, Conn);
            
            Comm.Parameters.AddWithValue("@Id", ApplicationId);

            LicenseDto dto = null;

            try
            {
                Conn.Open();
                var reader = Comm.ExecuteReader();

                if (reader.Read())
                {
                    dto = new LicenseDto();

                    dto.Id = reader.GetInt32(reader.GetOrdinal("LicenseID"));
                    dto.ApplicationId = reader.GetInt32(reader.GetOrdinal("ApplicationID"));
                    dto.DriverId = reader.GetInt32(reader.GetOrdinal("DriverID"));
                    dto.LicenseClassId = reader.GetInt32(reader.GetOrdinal("LicenseClassID"));
                    dto.CreatedByUserId = reader.GetInt32(reader.GetOrdinal("CreatedByUserID"));
                    dto.IssueDate = reader.GetDateTime(reader.GetOrdinal("IssueDate"));
                    dto.ExpirationDate = reader.GetDateTime(reader.GetOrdinal("ExpirationDate"));

                    // Notes is nullable
                    if (!reader.IsDBNull(reader.GetOrdinal("Notes")))
                        dto.Notes = reader.GetString(reader.GetOrdinal("Notes"));
                    else
                        dto.Notes = string.Empty ;

                    dto.PaidFees = reader.GetDecimal(reader.GetOrdinal("PaidFees"));
                    dto.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                    dto.IssueReason = (LicenseDto.enIssueReason)reader.GetByte(reader.GetOrdinal("IssueReason"));
                }

                reader.Close();
            }
            catch { }
            finally { Conn.Close(); }

            return dto;
        }

        public bool DeActivateById(int LicenseId)
        {

            int AffectedRows = 0;

            string Query = "Update Licenses Set IsActive = 0 Where LicenseId = @LicenseId";

            var Connection = new SqlConnection(clsDataSettings.ConncetionString);

            var Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseId", LicenseId);
            
            try
            {
                Connection.Open();
                AffectedRows = Command.ExecuteNonQuery();
            }
            catch { }
            finally { Connection.Close(); }

            return AffectedRows > 0;

        }

        public bool IsLicenseDetained(int LicenseId)
        {
            bool IsDetained = false;

            string Query = "select 1 from DetainedLicenses where LicenseID = @LicenseID and IsReleased = 0 ";

            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            var Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseId);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                IsDetained = Result != null;
            }
            catch { }
            finally { Connection.Close(); }

            return IsDetained;
        }

        public int GetActiveLicenseId(int PersonId, int LicenseClassId)
        {

            string Query = @"select LicenseId 
                            from Licenses 
                            join Drivers on Drivers.DriverID = Licenses.DriverID
                            where Drivers.PersonID = @PersonId and Licenses.IsActive = 1 and Licenses.LicenseClassID = @LicenseClassId";

            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            var Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonId", PersonId);
            Command.Parameters.AddWithValue("@LicenseClassId", LicenseClassId);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                
                return Result != null ? (int)Result : -1;
            }
            catch { throw new Exception(); }
            finally { Connection.Close(); }


        }
    }
}