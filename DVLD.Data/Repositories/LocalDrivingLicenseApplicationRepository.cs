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
    public class LocalDrivingLicenseApplicationRepository : ILocalDrivingLicenseApplicationRepository
    {
        public int Add(LocalDrivingLicenseApplicationDto dto)
        {
            int GeneratedId = -1;
            var Conn = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = @"
                INSERT INTO LocalDrivingLicenseApplications
                (
                    ApplicationID,
                    LicenseClassID
                )
                VALUES
                (
                    @ApplicationID,
                    @LicenseClassID
                );
                SELECT SCOPE_IDENTITY();";
            var Command = new SqlCommand(Query, Conn);
            Command.Parameters.AddWithValue("@ApplicationID", dto.ApplicationId);
            Command.Parameters.AddWithValue("@LicenseClassID", dto.LicenseClassID);
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
        public bool DeleteById(int Id)
        {
            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = "DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @ID";
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
            return AffectedRows > 0;
        }
        public LocalDrivingLicenseApplicationDto GetById(int Id)
        {
            string Query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @id";
            var Conn = new SqlConnection(clsDataSettings.ConncetionString);
            var Comm = new SqlCommand(Query, Conn);
            Comm.Parameters.AddWithValue("@id", Id);
            LocalDrivingLicenseApplicationDto dto = null;
            try
            {
                Conn.Open();
                var reader = Comm.ExecuteReader();
                if (reader.Read())
                {
                    IApplicationRepository appRepo = new ApplicationRepository();
                    ILicenseClassRepository licenseRepo = new LicenseClassRepository();

                    dto = new LocalDrivingLicenseApplicationDto();
                    dto.Id = reader.GetInt32(0);
                    dto.ApplicationId = reader.GetInt32(1);
                    dto.LicenseClassID = reader.GetInt32(2);

                }
                reader.Close();
            }
            catch { }
            finally { Conn.Close(); }
            return dto;
        }
        public bool IsExist(int Id)
        {
            bool IsFound = false;
            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = "SELECT 1 FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @Id";
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
        public bool Update(LocalDrivingLicenseApplicationDto dto)
        {
            int AffectedRows = 0;
            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = @"
                UPDATE LocalDrivingLicenseApplications
                SET
                    ApplicationID = @ApplicationID,
                    LicenseClassID = @LicenseClassID
                WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            var Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", dto.Id);
            Command.Parameters.AddWithValue("@ApplicationID", dto.ApplicationId);
            Command.Parameters.AddWithValue("@LicenseClassID", dto.LicenseClassID);
            try
            {
                Connection.Open();
                AffectedRows = Command.ExecuteNonQuery();
            }
            catch { }
            finally { Connection.Close(); }
            return AffectedRows > 0;
        }
        public DataTable GetAll()
        {
            var DataTable = new DataTable();
            var Conn = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = "select * from LocalDrivingLicenseApplications_View Order By Status DESC, ApplicationDate DESC";

            var Command = new SqlCommand(Query, Conn);
            
            try
            {
                Conn.Open();
                SqlDataReader reader = Command.ExecuteReader();
                DataTable.Load(reader);
                reader.Close();
            }
            catch { }
            finally { Conn.Close(); }
            return DataTable;
        }

        public byte PassedTestsCount(int localDrivingLicenseApplicationId)
        {

            byte PassedTestsCount = 0;

            string Query = @"
                Select count(*) 
                From LocalDrivingLicenseApplications LA
                Join TestAppointments TA ON TA.LocalDrivingLicenseApplicationID = LA.LocalDrivingLicenseApplicationID
                Join Tests T ON T.TestAppointmentID = TA.TestAppointmentID
                where LA.LocalDrivingLicenseApplicationID = @id and T.TestResult = 1
                ";

            var Conn = new SqlConnection(clsDataSettings.ConncetionString);
            var Command = new SqlCommand(Query, Conn);

            Command.Parameters.AddWithValue("@id", localDrivingLicenseApplicationId);

            try
            {
                Conn.Open();
                object result = Command.ExecuteScalar();

                PassedTestsCount = result == null ? (byte)(int)0 : (byte)(int)result; // you have to unbox the object first then converting it to byte


            }
            catch { }
            finally { Conn.Close(); }


            return PassedTestsCount;
        }
    }
}
