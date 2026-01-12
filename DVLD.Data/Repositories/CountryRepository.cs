using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data.Dtos;
using DVLD_Data.Interfaces;

namespace DVLD_Data.Repositries
{
    public class CountryRepository : ICountryRepository
    {
        public int Add(CountryDto dto)
        {
            int GeneratedId = -1;

            var Conn = new SqlConnection(clsDataSettings.ConncetionString);

            string Query =
                @"INSERT INTO Countries (CountryName) Values (@CountryName);
                Select Scope_Identity();";

            var Command = new SqlCommand(Query, Conn);

            Command.Parameters.AddWithValue("@CountryName", dto.Name);



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

        public bool DeleteById(int Id)
        {
            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            
            string Query = "Delete From Countries Where CountryID = @ID";

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

        public DataTable GetAll()
        {
            var DataTable = new DataTable();

            var Conn = new SqlConnection(clsDataSettings.ConncetionString);

            string Query = "Select * From Countries";

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

        public CountryDto GetById(int Id)
        {
            string Query = "Select * From Countries Where CountryID = @Id";

            var Conn = new SqlConnection(clsDataSettings.ConncetionString);

            var Command = new SqlCommand(Query, Conn);

            Command.Parameters.AddWithValue("@Id", Id);

            var CountryDto = new CountryDto();

            try
            {
                Conn.Open();

                var reader = Command.ExecuteReader();


                if (!reader.HasRows)
                {
                    Conn.Close();
                    return null;
                }

                reader.Read();
                CountryDto.Id = (int)reader["CountryID"];
                CountryDto.Name = (string)reader["CountryName"];
                reader.Close();

            }
            catch { }
            finally
            {
                Conn.Close();
            }

            return CountryDto;
        }

        public bool IsExist(int Id)
        {
            bool IsFound = false;

            var Connection = new SqlConnection(clsDataSettings.ConncetionString);

            string Query = "Select 1 from Countries Where CountryID = @Id";

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

        public bool Update(CountryDto dto)
        {
            int AffectedRows = 0;
            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = @"
                UPDATE Countries
                SET CountryName = @CountryName
                WHERE CountryID = @Id";
           
            var Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@Id", dto.Id);
            Command.Parameters.AddWithValue("@CountryName", dto.Name);
            
            try
            {
                Connection.Open();

                AffectedRows = Command.ExecuteNonQuery();

            }
            catch { }

            finally { Connection.Close(); }

            return AffectedRows > 0;
        }

        public string GetCountryName (int Id)
        {
            string Query = "Select CountryName From Countries Where CountryID = @Id";

            var Conn = new SqlConnection(clsDataSettings.ConncetionString);

            var Command = new SqlCommand(Query, Conn);

            Command.Parameters.AddWithValue("@Id", Id);

            string CountryName = null;

            try
            {
                Conn.Open();

                object result = Command.ExecuteScalar();

                if (result != null)
                {
                    CountryName = (string)result;
                }


            }
            catch { }
            finally
            {
                Conn.Close();
            }

            return CountryName;
        }

        public int GetCountryId(string Name)
        {
            string Query = "Select CountryId From Countries Where CountryName = @Name";

            var Conn = new SqlConnection(clsDataSettings.ConncetionString);

            var Command = new SqlCommand(Query, Conn);

            Command.Parameters.AddWithValue("@Name", Name);

            int CountryId = -1;

            try
            {
                Conn.Open();

                object result = Command.ExecuteScalar();

                if (result != null)
                {
                    CountryId = (int)result;
                }


            }
            catch { }
            finally
            {
                Conn.Close();
            }

            return CountryId;
        }
    }
}
