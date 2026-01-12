using System;
using System.Data;
using System.Data.SqlClient;
using DVLD_Data.Dtos;
using DVLD_Data.Interfaces;
using static DVLD_Data.Dtos.ApplicationDto;

namespace DVLD_Data.Repositries
{
    public class ApplicationRepository : IApplicationRepository
    {

        public bool IsExist(int Id)
        {
            bool IsFound = false;

            var Connection = new SqlConnection(clsDataSettings.ConncetionString);

            string Query = "Select 1 from Applications Where ApplicationID = @Id";

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

            string Query = "Select * From Applications";

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
        public ApplicationDto GetById(int Id)
        {
            string Query = "Select * From Applications where ApplicationID = @id";

            var Conn = new SqlConnection(clsDataSettings.ConncetionString);

            var Comm = new SqlCommand(Query, Conn);

            Comm.Parameters.AddWithValue("@id", Id);

            ApplicationDto dto = null;

            try
            {
                Conn.Open();


                var reader = Comm.ExecuteReader();

                if (reader.Read())
                {
                    IPersonRepository personRepo = new PersonRepository();
                    IUserRepository userRepo = new UserRepository();
                    IApplicationTypeRepository applicationTypeRepo = new ApplicationTypeRepository();
                    
                    dto = new ApplicationDto();
                    dto.Id = reader.GetInt32(0);
                    dto.ApplicantPersonId = reader.GetInt32(1);
                    dto.Date = reader.GetDateTime(2);
                    dto.ApplicationTypeId = reader.GetInt32(3);
                    dto.Status = (enApplicationStatus)reader.GetByte(4);
                    dto.LastStatusDate = reader.GetDateTime(5);
                    dto.PaidFees = reader.GetDecimal(6);
                    dto.CreatedByUserId = reader.GetInt32(7);

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

            string Query = "Delete From Applications Where ApplicationID = @ID";

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
        public int Add(ApplicationDto dto)
        {
            int GeneratedId = -1;

            var Conn = new SqlConnection(clsDataSettings.ConncetionString);

            string Query = @"
                    INSERT INTO Applications 
                    (
                        ApplicantPersonID,
                        ApplicationDate,
                        ApplicationTypeID,
                        ApplicationStatus,
                        LastStatusDate,
                        PaidFees,
                        CreatedByUserID
                    )
                    VALUES 
                    (
                        @ApplicantPersonID,
                        @ApplicationDate,
                        @ApplicationTypeID,
                        @ApplicationStatus,
                        @LastStatusDate,
                        @PaidFees,
                        @CreatedByUserID
                    );
                    SELECT SCOPE_IDENTITY();";

            var Command = new SqlCommand(Query, Conn);

            Command.Parameters.AddWithValue("@ApplicantPersonID", dto.ApplicantPersonId);
            Command.Parameters.AddWithValue("@ApplicationDate", dto.Date);
            Command.Parameters.AddWithValue("@ApplicationTypeID", dto.ApplicationTypeId);
            Command.Parameters.AddWithValue("@ApplicationStatus", dto.Status); // tinyint → use byte or int
            Command.Parameters.AddWithValue("@LastStatusDate", dto.LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", dto.PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", dto.CreatedByUserId);


            try
            {
                Conn.Open();

                object Result = Command.ExecuteScalar();

                GeneratedId = Result is null ? -1 : Convert.ToInt32(Result);

                Conn.Close();



            }
            catch { }
            finally { Conn.Close(); }

            return GeneratedId;


        }
        public bool Update(ApplicationDto dto)
        {
            int AffectedRows = 0;
            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = @"
                UPDATE Applications
                SET 
                    ApplicantPersonID    = @ApplicantPersonID,
                    ApplicationDate      = @ApplicationDate,
                    ApplicationTypeID    = @ApplicationTypeID,
                    ApplicationStatus    = @ApplicationStatus,
                    LastStatusDate       = @LastStatusDate,
                    PaidFees             = @PaidFees,
                    CreatedByUserID      = @CreatedByUserID
                WHERE ApplicationID = @ApplicationID";

            var Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", dto.Id);
            Command.Parameters.AddWithValue("@ApplicantPersonID", dto.ApplicantPersonId);
            Command.Parameters.AddWithValue("@ApplicationDate", dto.Date);
            Command.Parameters.AddWithValue("@ApplicationTypeID", dto.ApplicationTypeId);
            Command.Parameters.AddWithValue("@ApplicationStatus", dto.Status);  // tinyint in DB
            Command.Parameters.AddWithValue("@LastStatusDate", dto.LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", dto.PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", dto.CreatedByUserId);

            try
            {
                Connection.Open();

                AffectedRows = Command.ExecuteNonQuery();

            }
            catch { }

            finally { Connection.Close(); }

            return AffectedRows > 0;
        }
        
        public bool DoesPersonHaveActiveApplication (int ApplicantPersonId , int ApplicationTypeId)
        {
            return GetActiveApplicationID(ApplicantPersonId, ApplicationTypeId) != -1;
        }
        public int GetActiveApplicationID (int ApplicantPersonId , int ApplicationTypeId)
        {
            int ActiveApplicationId = -1;

            string Query = "select ApplicationId from applications where applicantPersonId = @personId and applicationTypeId = @applicationTypeId and applicationStatus = 1";
            
            var Conn = new SqlConnection(clsDataSettings.ConncetionString);
            var Comm = new SqlCommand(Query, Conn); 

            Comm.Parameters.AddWithValue("@personId", ApplicantPersonId);
            Comm.Parameters.AddWithValue("@applicationTypeId", ApplicationTypeId);

            try
            {
                object result = Comm.ExecuteScalar();

                ActiveApplicationId = result == null ? -1 : Convert.ToInt32(result);

            }

            catch { }
            finally { Conn.Close(); }

            return ActiveApplicationId;

        }

        public bool CancelApplication(int ApplicationId)
        {
            int AffectedRows = 0;   
            string Query = "Update Applications Set ApplicationStatus = 2 Where ApplicationId = @Id";
            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            var Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Id", ApplicationId);

            try
            {
                Connection.Open();

                AffectedRows = Command.ExecuteNonQuery();

            }
            catch { throw new Exception("From CancelApplication"); }
            finally { Connection.Close(); }

            return AffectedRows > 0;
        }
    }
}
