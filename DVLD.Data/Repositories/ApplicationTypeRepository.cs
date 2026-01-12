using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using DVLD_Data.Dtos;
using DVLD_Data.Interfaces;

namespace DVLD_Data.Repositries
{
    public class ApplicationTypeRepository : IApplicationTypeRepository
    {


        public DataTable GetAll()
        {
            string Query = "Select * from ApplicationTypes";

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
        public bool Update(ApplicationTypeDto dto)
        {
            int AffectedRows = 0;

            string Query = @"Update ApplicationTypes
                             set ApplicationTypeTitle = @title , ApplicationFees = @fees
                             where ApplicationTypeId = @id;";

            var Conn = new SqlConnection(clsDataSettings.ConncetionString);

            var Comm = new SqlCommand(Query, Conn);

            Comm.Parameters.AddWithValue("@title", dto.Title);
            Comm.Parameters.AddWithValue("@fees", dto.Fees);
            Comm.Parameters.AddWithValue("@id", dto.Id);

            try
            {
                Conn.Open();

                AffectedRows = Comm.ExecuteNonQuery();
            }
            catch { }
            finally { Conn.Close(); }

            return AffectedRows > 0;


        }
        public ApplicationTypeDto GetById(int Id)
        {
            string Query = "Select * From ApplicationTypes where ApplicationTypeId = @id";

            var Conn = new SqlConnection(clsDataSettings.ConncetionString);

            var Comm = new SqlCommand(Query , Conn);

            Comm.Parameters.AddWithValue("@id", Id);

            ApplicationTypeDto dto = null;

            try
            {
                Conn.Open();


                var reader = Comm.ExecuteReader();

                if (reader.Read())
                {
                    dto = new ApplicationTypeDto();
                    dto.Id = (int)reader["ApplicationTypeId"];
                    dto.Fees = (decimal)reader["ApplicationFees"];
                    dto.Title = reader["ApplicationTypeTitle"].ToString();
                }

                reader.Close();

            }
            catch { }
            finally { Conn.Close(); }

            return dto; 

        }
        
        // wont be implemented ( unnecessary in business logic )
        public int Add(ApplicationTypeDto dto)
        {
            return -1;
        }
        public bool DeleteById(int Id)
        {
            return false;
        }
        public bool IsExist(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
