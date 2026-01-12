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
    public class TestTypeRepository : ITestTypeRepository
    {


        public int Add(TestTypeDto dto) => -1;
        public bool DeleteById(int Id) => false;
        public bool IsExist(int Id) => false;
        

        public DataTable GetAll()
        {
            string Query = "Select * from TestTypes";

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

        public TestTypeDto GetById(int Id)
        {
            string Query = "Select * From TestTypes where TestTypeID = @id";

            var Conn = new SqlConnection(clsDataSettings.ConncetionString);

            var Comm = new SqlCommand(Query, Conn);

            Comm.Parameters.AddWithValue("@id", Id);

            TestTypeDto dto = null;

            try
            {
                Conn.Open();


                var reader = Comm.ExecuteReader();

                if (reader.Read())
                {
                    dto = new TestTypeDto();
                    dto.Id = (int)reader["TestTypeId"];
                    dto.Fees = (decimal)reader["TestTypeFees"];
                    dto.Title = reader["TestTypeTitle"].ToString();
                    dto.Description = reader["TestTypeDescription"].ToString();
                }

                reader.Close();

            }
            catch { }
            finally { Conn.Close(); }

            return dto;
        }


        public bool Update(TestTypeDto dto)
        {
            int AffectedRows = 0;

            string Query = @"Update TestTypes
                             set TestTypeTitle = @title , TestTypeFees = @fees , TestTypeDescription = @desc
                             where TestTypeId = @id;";

            var Conn = new SqlConnection(clsDataSettings.ConncetionString);

            var Comm = new SqlCommand(Query, Conn);

            Comm.Parameters.AddWithValue("@id", dto.Id);
            Comm.Parameters.AddWithValue("@title", dto.Title);
            Comm.Parameters.AddWithValue("@fees", dto.Fees);
            Comm.Parameters.AddWithValue("@desc", dto.Description);

            try
            {
                Conn.Open();

                AffectedRows = Comm.ExecuteNonQuery();
            }
            catch { }
            finally { Conn.Close(); }

            return AffectedRows > 0;


        }
    }
}
