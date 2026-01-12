using System;
using System.Data;
using System.Data.SqlClient;
using DVLD_Data.Dtos;
using DVLD_Data.Interfaces;

namespace DVLD_Data.Repositories
{
    public class InternationalLicenseRepository : IInternationalLicenseRepository
    {
        public bool IsExist(int Id)
        {
            bool IsFound = false;
            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = "Select 1 from InternationalLicenses Where InternationalLicenseID = @Id";
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
            string Query = "Select * From InternationalLicenses";
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

        public InternationalLicenseDto GetById(int Id)
        {
            string Query = "SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @id";
            var Conn = new SqlConnection(clsDataSettings.ConncetionString);
            var Comm = new SqlCommand(Query, Conn);
            Comm.Parameters.AddWithValue("@id", Id);

            InternationalLicenseDto dto = null;

            try
            {
                Conn.Open();
                var reader = Comm.ExecuteReader();

                if (reader.Read())
                {
                    dto = new InternationalLicenseDto();

                    dto.Id = Convert.ToInt32(reader["InternationalLicenseID"]);
                    dto.ApplicationId = Convert.ToInt32(reader["ApplicationID"]);
                    dto.DriverId = Convert.ToInt32(reader["DriverID"]);
                    dto.IssuedUsingLocalLicenseId = Convert.ToInt32(reader["IssuedUsingLocalLicenseID"]);
                    dto.CreatedByUserId = Convert.ToInt32(reader["CreatedByUserID"]);
                    dto.IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    dto.ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                    dto.IsActive = Convert.ToBoolean(reader["IsActive"]);
                }

                reader.Close();
            }
            catch
            {
                // Log exception if needed in the future
                dto = null;
            }
            finally
            {
                Conn.Close();
            }

            return dto;
        }

        public bool DeleteById(int Id)
        {
            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = "Delete From InternationalLicenses Where InternationalLicenseID = @ID";
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
            return AffectedRows > 0; // Changed to > 0 for consistency with Update pattern
        }

        public int Add(InternationalLicenseDto dto)
        {
            int GeneratedId = -1;
            var Conn = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = @"
                    
                    Update InternationalLicenses Set IsActive = 0 Where DriverId = @DriverId

                    INSERT INTO InternationalLicenses
                    (
                        ApplicationID,
                        DriverID,
                        IssuedUsingLocalLicenseID,
                        CreatedByUserID,
                        IssueDate,
                        ExpirationDate,
                        IsActive
                    )
                    VALUES
                    (
                        @ApplicationID,
                        @DriverID,
                        @IssuedUsingLocalLicenseID,
                        @CreatedByUserID,
                        @IssueDate,
                        @ExpirationDate,
                        @IsActive
                    );
                    SELECT SCOPE_IDENTITY();";
            var Command = new SqlCommand(Query, Conn);
            Command.Parameters.AddWithValue("@ApplicationID", dto.ApplicationId);
            Command.Parameters.AddWithValue("@DriverID", dto.DriverId);
            Command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", dto.IssuedUsingLocalLicenseId);
            Command.Parameters.AddWithValue("@CreatedByUserID", dto.CreatedByUserId);
            Command.Parameters.AddWithValue("@IssueDate", dto.IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", dto.ExpirationDate);
            Command.Parameters.AddWithValue("@IsActive", dto.IsActive);

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

        public bool Update(InternationalLicenseDto dto)
        {
            int AffectedRows = 0;
            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = @"
                UPDATE InternationalLicenses
                SET
                    ApplicationID = @ApplicationID,
                    DriverID = @DriverID,
                    IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID,
                    CreatedByUserID = @CreatedByUserID,
                    IssueDate = @IssueDate,
                    ExpirationDate = @ExpirationDate,
                    IsActive = @IsActive
                WHERE InternationalLicenseID = @InternationalLicenseID";
            var Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@InternationalLicenseID", dto.Id);
            Command.Parameters.AddWithValue("@ApplicationID", dto.ApplicationId);
            Command.Parameters.AddWithValue("@DriverID", dto.DriverId);
            Command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", dto.IssuedUsingLocalLicenseId);
            Command.Parameters.AddWithValue("@CreatedByUserID", dto.CreatedByUserId);
            Command.Parameters.AddWithValue("@IssueDate", dto.IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", dto.ExpirationDate);
            Command.Parameters.AddWithValue("@IsActive", dto.IsActive);

            try
            {
                Connection.Open();
                AffectedRows = Command.ExecuteNonQuery();
            }
            catch { }
            finally { Connection.Close(); }
            return AffectedRows > 0;
        }

        public int GetActiveInternationalLicenseIdByDriverId(int DriverId)
        {
            int ActiveInternationalLicenseId = -1;

            string Query = "select top 1 InternationalLicenseID from InternationalLicenses where DriverId = @DriverId and GETDATE() <= ExpirationDate ";
            
            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            
            var Command = new SqlCommand(Query, Connection);    
            
            Command.Parameters.AddWithValue("@DriverId" , DriverId);

            try
            {
                Connection.Open();
                var result = Command.ExecuteScalar();

                if (result != null)
                    ActiveInternationalLicenseId = (int)result;


            }
            catch { }
            finally { Connection.Close(); }

            return ActiveInternationalLicenseId;
        }
    }
}