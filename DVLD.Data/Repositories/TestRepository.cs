using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data.Dtos;
using DVLD_Data.Interfaces;

namespace DVLD_Data.Repositries
{
    public class TestRepository : ITestRepository
    {
        public int Add(TestDto dto)
        {
            int GeneratedId = -1;

            SqlConnection Conn = new SqlConnection(clsDataSettings.ConncetionString);

            string Query = @"
            INSERT INTO Tests
                (TestAppointmentID
               ,TestResult
               ,Notes
               ,CreatedByUserID)
            VALUES
               (@TestAppointmentID,
                @TestResult,
                @Notes,
                @CreatedByUserID);

            Update TestAppointments Set IsLocked = 1 Where TestAppointmentId = @TestAppointmentID

             SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Conn);

            Command.Parameters.AddWithValue("@TestAppointmentID", dto.TestAppointmentId);
            Command.Parameters.AddWithValue("@TestResult", dto.TestResult);
            Command.Parameters.AddWithValue("@CreatedByUserID", dto.CreatedByUserId);

            if (string.IsNullOrEmpty(dto.Notes) )
                Command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@Notes", dto.Notes);
                

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

        public bool DeleteById(int Id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            throw new NotImplementedException();
        }

        public TestDto GetByTestAppointmentId(int Id)
        {
            string Query = "Select * from Tests Where TestAppointmentId = @Id";

            var connection = new SqlConnection(clsDataSettings.ConncetionString);

            var command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@Id", Id);

            TestDto dto = null;

            try
            {
                connection.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {

                    dto = new TestDto();
                    dto.Id = (int)reader["TestId"];
                    dto.CreatedByUserId = (int)reader["CreatedByUserId"];
                    dto.Notes = reader["Notes"] == DBNull.Value ? string.Empty : reader["Notes"].ToString();
                    dto.TestAppointmentId = (int)reader["TestAppointmentId"];
                    dto.TestResult = (bool)reader["TestResult"];

                }


            }
            catch { }
            finally { connection.Close(); }

            return dto;

        }

        public TestDto GetById(int Id)
        {
           
            string Query = "Select * from Tests Where TestId = @Id";

            var connection = new SqlConnection(clsDataSettings.ConncetionString);

            var command = new SqlCommand(Query , connection);

            command.Parameters.AddWithValue("@Id", Id);

            TestDto dto = null;

            try
            {
                connection.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {

                    dto = new TestDto();
                    dto.Id = (int)reader["TestId"];
                    dto.CreatedByUserId = (int)reader["CreatedByUserId"];
                    dto.Notes = reader["Notes"] == DBNull.Value ? string.Empty : reader["Notes"].ToString();
                    dto.TestAppointmentId = (int)reader["TestAppointmentId"];
                    dto.TestResult = (bool)reader["TestResult"];


                }
                

            }
            catch{ }
            finally { connection.Close(); }

            return dto;

        }

        public bool IsExist(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TestDto dto)
        {
            int AffectedRows = 0;
            
            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            
            string Query = @"
                UPDATE Tests
                SET Notes = @Notes
                WHERE TestId = @Id";

            var Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@Id", dto.Id);
            Command.Parameters.AddWithValue("@Notes", dto.Notes);
            
            try
            {
                Connection.Open();

                AffectedRows = Command.ExecuteNonQuery();

            }
            catch { }

            finally { Connection.Close(); }

            return AffectedRows > 0;
        }

     
    }
}
