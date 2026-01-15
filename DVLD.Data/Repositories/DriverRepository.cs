using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using DVLD_Data.Dtos;
using DVLD_Data.Interfaces;

namespace DVLD_Data.Repositries
{
    public class DriverRepository : IDriverRepository
    {
        public bool IsExist(int Id)
        {
            
            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = "SELECT 1 FROM Drivers WHERE DriverID = @Id";
            var Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Id", Id);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                return  (result != null);
            }
            catch { }
            finally { Connection.Close(); }

            return false;
        }

        public DataTable GetAll()
        {
            var DataTable = new DataTable();
            var Conn = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = @"
                            SELECT D.* , 
                                   AL.ActiveLicenses , 
                                   P.FirstName + ' ' + P.SecondName + ' ' + ISNULL(P.ThirdName + ' ', '') + P.LastName AS FullName , 
                                   P.NationalNo
                            FROM Drivers D
                            LEFT JOIN (
                                SELECT DriverID , COUNT(*) AS ActiveLicenses
                                FROM Licenses
                                WHERE IsActive = 1
                                GROUP BY DriverID
                            ) AL ON AL.DriverID = D.DriverID
                            JOIN People P ON P.PersonID = D.PersonID";

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

        public DriverDto GetById(int Id)
        {
            string Query = "SELECT * FROM Drivers WHERE DriverID = @Id";
            var Conn = new SqlConnection(clsDataSettings.ConncetionString);
            var Comm = new SqlCommand(Query, Conn);
            Comm.Parameters.AddWithValue("@Id", Id);

            DriverDto dto = null;

            try
            {
                Conn.Open();
                var reader = Comm.ExecuteReader();

                if (reader.Read())
                {
                    dto = new DriverDto();

                    dto.Id = reader.GetInt32(reader.GetOrdinal("DriverID"));
                    dto.PersonId = reader.GetInt32(reader.GetOrdinal("PersonID"));
                    dto.CreatedByUserId = reader.GetInt32(reader.GetOrdinal("CreatedByUserID"));
                    dto.CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"));
                }

                reader.Close();
            }
            catch { }
            finally { Conn.Close(); }

            return dto;
        }

        public DriverDto GetByPersonId(int PersonId)
        {
            string Query = "Select * From Drivers Where PersonId = @PersonId";

            var Connection = new SqlConnection(clsDataSettings.ConncetionString);

            var Command =new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonId", PersonId);

            DriverDto dto = null;
            
            try
            {
                Connection.Open();

                var reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    dto = new DriverDto();
                    dto.Id = (int)reader["DriverId"];
                    dto.CreatedDate = (DateTime)reader["CreatedDate"];
                    dto.CreatedByUserId = (int)reader["CreatedByUserId"];
                    dto.PersonId = PersonId;
                }

            }
            catch { throw new Exception("From DVLD_Data\\Repositories\\DriverRepository\\GetByPersonId"); }
            finally { Connection.Close(); }

            return dto;

        }
     
        public bool DeleteById(int Id)
        {
            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = "DELETE FROM Drivers WHERE DriverID = @ID";
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

            return AffectedRows > 0; // Typically drivers shouldn't be deleted easily, but following pattern
        }

        public int Add(DriverDto dto)
        {
            int GeneratedId = -1;
            var Conn = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = @"
                INSERT INTO Drivers
                (
                    PersonID,
                    CreatedByUserID,
                    CreatedDate
                )
                VALUES
                (
                    @PersonID,
                    @CreatedByUserID,
                    @CreatedDate
                );
                SELECT SCOPE_IDENTITY();";

            var Command = new SqlCommand(Query, Conn);

            Command.Parameters.AddWithValue("@PersonID", dto.PersonId);
            Command.Parameters.AddWithValue("@CreatedByUserID", dto.CreatedByUserId);
            Command.Parameters.AddWithValue("@CreatedDate", dto.CreatedDate);

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

        public bool Update(DriverDto dto)
        {
            int AffectedRows = 0;
            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = @"
                UPDATE Drivers
                SET
                    PersonID = @PersonID,
                    CreatedByUserID = @CreatedByUserID,
                    CreatedDate = @CreatedDate
                WHERE DriverID = @DriverID";

            var Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@DriverID", dto.Id);
            Command.Parameters.AddWithValue("@PersonID", dto.PersonId);
            Command.Parameters.AddWithValue("@CreatedByUserID", dto.CreatedByUserId);
            Command.Parameters.AddWithValue("@CreatedDate", dto.CreatedDate);

            try
            {
                Connection.Open();
                AffectedRows = Command.ExecuteNonQuery();
            }
            catch { }
            finally { Connection.Close(); }

            return AffectedRows > 0;
        }

        public List<LicenseDto> GetAllLocalLicenses(int DriverId)
        {
            List<LicenseDto> licenses = new List<LicenseDto>();

            string Query = "SELECT * FROM Licenses WHERE DriverId = @Id";

            SqlConnection Connection = new SqlConnection(clsDataSettings.ConncetionString);
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Id", DriverId);

            DataTable dt = new DataTable();

            try
            {
                Connection.Open();
                dt.Load(Command.ExecuteReader());

                foreach (DataRow row in dt.Rows)
                {
                    licenses.Add(new LicenseDto
                    {
                        Id = (int)row["LicenseId"],
                        ApplicationId = (int)row["ApplicationId"],
                        DriverId = (int)row["DriverId"],
                        LicenseClassId = (int)row["LicenseClassID"],
                        CreatedByUserId = (int)row["CreatedByUserId"],
                        IssueDate = (DateTime)row["IssueDate"],
                        ExpirationDate = (DateTime)row["ExpirationDate"],
                        Notes = row["Notes"] == DBNull.Value ? null : (string)row["Notes"],
                        PaidFees = (decimal)row["PaidFees"],
                        IsActive = (bool)row["IsActive"],
                        IssueReason = (LicenseDto.enIssueReason)(byte)row["IssueReason"]
                    });
                }
            }
            catch{}
            finally
            {
                Connection.Close();
            }

            return licenses;
        }

        public List<InternationalLicenseDto> GetAllInternationalLicenses(int DriverId)
        {
            List<InternationalLicenseDto> licenses = new List<InternationalLicenseDto>();

            string Query = "SELECT * FROM InternationalLicenses WHERE DriverId = @DriverId";

            SqlConnection Connection = new SqlConnection(clsDataSettings.ConncetionString);
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DriverId", DriverId);

            DataTable dt = new DataTable();

            try
            {
                Connection.Open();
                dt.Load(Command.ExecuteReader());

                foreach (DataRow row in dt.Rows)
                {
                    licenses.Add(new InternationalLicenseDto
                    {
                        Id = (int)row["InternationalLicenseId"],
                        ApplicationId = (int)row["ApplicationId"],
                        DriverId = (int)row["DriverId"],
                        IssuedUsingLocalLicenseId = (int)row["IssuedUsingLocalLicenseId"],
                        CreatedByUserId = (int)row["CreatedByUserId"],
                        IssueDate = (DateTime)row["IssueDate"],
                        ExpirationDate = (DateTime)row["ExpirationDate"],
                        IsActive = (bool)row["IsActive"]
                    });
                }
            }
            catch {}
            finally
            {
                Connection.Close();
            }

            return licenses;
        }
    }
}