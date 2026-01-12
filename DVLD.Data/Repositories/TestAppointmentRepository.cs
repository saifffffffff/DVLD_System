using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data.Dtos;
using DVLD_Data.Interfaces;

namespace DVLD_Data.Repositries
{
    public class TestAppointmentRepository : ITestAppointmentRepository
    {


        public bool DeleteById(int Id)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TestAppointmentDto dto)
        {
            int AffectedRows = 0;

            string Query = "Update TestAppointments Set AppointmentDate = @Date Where TestAppointmentID = @ID";

            var Connection = new SqlConnection(clsDataSettings.ConncetionString);

            var Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ID" , dto.Id);
            Command.Parameters.AddWithValue("@Date" , dto.AppointmentDate);

            try
            {
                Connection.Open();

                AffectedRows = Command.ExecuteNonQuery();

            }
            catch { throw new Exception("From TestAppointmentRepository");}
            
            finally { Connection.Close(); }

            return AffectedRows > 0;

        }

        // 
        public int Add(TestAppointmentDto dto)
        {
            int GeneratedId = -1;

            SqlConnection Conn = new SqlConnection(clsDataSettings.ConncetionString);

            string Query = @"
                INSERT INTO TestAppointments
                (
                    TestTypeID,
                    LocalDrivingLicenseApplicationID,
                    AppointmentDate,
                    PaidFees,
                    CreatedByUserID,
                    IsLocked,
                    RetakeTestApplicationID
                )
                VALUES
                (
                    @TestTypeID,
                    @LocalDrivingLicenseApplicationID,
                    @AppointmentDate,
                    @PaidFees,
                    @CreatedByUserID,
                    @IsLocked,
                    @RetakeTestApplicationID
                );
                SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Conn);

            Command.Parameters.AddWithValue("@TestTypeID", dto.TestTypeId);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", dto.LocalDrivingLicenseApplicationId);
            Command.Parameters.AddWithValue("@AppointmentDate", dto.AppointmentDate);
            Command.Parameters.AddWithValue("@PaidFees", dto.PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", dto.CreatedByUserId);
            Command.Parameters.AddWithValue("@IsLocked", dto.IsLocked);

            // RetakeTestApplicationID can be null
            if (dto.RetakeTestApplicationId == -1)
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            
            else
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", dto.RetakeTestApplicationId);

            try
            {
                Conn.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null)
                    GeneratedId = Convert.ToInt32(Result);
            }
            catch
            {
                GeneratedId = -1;
            }
            finally
            {
                Conn.Close();
            }

            return GeneratedId;
        }
        public DataTable GetAll()
        {
            string Query = "Select * from TestAppointments Order by TestAppointmentId DESC";

            var Conn = new SqlConnection(clsDataSettings.ConncetionString);

            var Comm = new SqlCommand(Query, Conn);

            DataTable dt = new DataTable();
            try
            {
                Conn.Open();

                var reader = Comm.ExecuteReader();

                dt.Load(reader);

            }
            catch { }

            finally
            {
                Conn.Close();
            }

            return dt;
        }
        
        public TestAppointmentDto GetById(int Id)
        {
            string Query = "Select * From TestAppointments where TestAppointmentID = @id";

            var Conn = new SqlConnection(clsDataSettings.ConncetionString);

            var Comm = new SqlCommand(Query, Conn);

            Comm.Parameters.AddWithValue("@id", Id);

            TestAppointmentDto dto = null;

            try
            {
                Conn.Open();


                var reader = Comm.ExecuteReader();

                if (reader.Read())
                {
                    
                    IUserRepository userRepo= new UserRepository();
                    IApplicationRepository applicationRepo = new ApplicationRepository();
                    ILocalDrivingLicenseApplicationRepository localAppRepo = new LocalDrivingLicenseApplicationRepository();
                    ITestTypeRepository testTypeRepo = new TestTypeRepository();

                    dto = new TestAppointmentDto();
                    dto.Id = (int)reader["TestAppointmentID"];
                    
                    dto.CreatedByUserId = (int)reader["CreatedByUserID"];

                    dto.RetakeTestApplicationId = reader["RetakeTestApplicationID"] == DBNull.Value ? -1 : (int)reader["RetakeTestApplicationID"];

                    dto.LocalDrivingLicenseApplicationId = (int)reader["LocalDrivingLicenseApplicationID"];

                    dto.TestTypeId = (int)reader["TestTypeID"];

                    dto.AppointmentDate = (DateTime)reader["AppointmentDate"];
                    dto.IsLocked = (bool)reader["IsLocked"];
                    dto.PaidFees = (decimal)reader["PaidFees"];

                }

                reader.Close();

            }
            catch { }
            finally { Conn.Close(); }

            return dto;
        }


        public int GetTestTrials(int LocalDrivingLicenseApplicationId, int TestTypeId)
        {

            int Trials = 0;

            string Query = @"select count(*)
                             from TestAppointments 
                             where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and TestTypeID = @TestTypeId and IsLocked = 1";

            var Conn = new SqlConnection(clsDataSettings.ConncetionString);

            var Comm = new SqlCommand(Query , Conn);

            Comm.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID" , LocalDrivingLicenseApplicationId);
            Comm.Parameters.AddWithValue("@TestTypeId ", TestTypeId);

            try
            {

                Conn.Open();

                var result = Comm.ExecuteScalar();

                Trials = result == null ? 0 : (int)result;   
                
            }
            catch
            {
                Trials = 0;
            }
            finally { 
                Conn.Close();
            }

            return Trials;
     
        }

        public DataTable GetAllByLocalDrivingLicenseAppIdAndTestTypeId(int LocalDrivingLicenseApplicationId, int TestTypeId)
        {
            string Query = @"select * 
                             from TestAppointments 
                             where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and TestTypeID = @TestTypeId Order By TestAppointmentId DESC";

            var Conn = new SqlConnection(clsDataSettings.ConncetionString);
            var Comm = new SqlCommand(Query, Conn); 
            Comm.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationId);
            Comm.Parameters.AddWithValue("@TestTypeId", TestTypeId);

            DataTable dt = new DataTable();

            try
            {
                Conn.Open();
                var reader = Comm.ExecuteReader();
                dt.Load(reader);
            }
            catch { }
            finally{ Conn.Close(); }

            return dt;
        }
    }
}
