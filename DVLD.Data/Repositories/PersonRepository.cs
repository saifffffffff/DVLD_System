using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data.Dtos;
namespace DVLD_Data.Repositries
{
    public class PersonRepository : IPersonRepository
    {
        public DataTable GetAll()
        {
            var DT = new DataTable();

            var Conn = new SqlConnection(clsDataSettings.ConncetionString);

            string Query = @"select P.* ,
                                    C.CountryName ,
                                    case 
                                        When P.Gendor = 0 then 'Male'
                                        else 'Female'
                                    end as GendorCaption
                              from People P join Countries C on C.CountryID = P.NationalityCountryID";

            var Command = new SqlCommand(Query, Conn);

            try
            {
                Conn.Open();

                SqlDataReader reader = Command.ExecuteReader();

                DT.Load(reader);

                reader.Close();
            }

            catch { }

            finally
            {
                Conn.Close();
            }

            return DT;
        }

        // returns PersonDto if found , returns null if not found
        public PersonDto GetById(int Id)
        {
            string Query = "Select * From People Where PersonId = @Id";

            var Conn = new SqlConnection(clsDataSettings.ConncetionString);

            var Command = new SqlCommand(Query, Conn);

            Command.Parameters.AddWithValue("@Id", Id);

            var dto = new PersonDto();

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
                dto.Id = (int)reader["PersonId"];
                dto.FirstName = reader["FirstName"].ToString();
                dto.SecondName = reader["SecondName"].ToString();
                dto.ThirdName = reader["ThirdName"] == DBNull.Value ? null : reader["ThirdName"].ToString();
                dto.LastName = reader["LastName"].ToString();
                dto.NationalNo = reader["NationalNo"].ToString();
                dto.DateOfBirth = (DateTime)reader["DateOfBirth"];
                dto.Gendor = (PersonDto.enGendor)((byte)reader["Gendor"]);
                dto.Address = reader["Address"].ToString();
                dto.Phone = reader["Phone"].ToString();
                dto.Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString();
                dto.ImagePath = reader["ImagePath"] == DBNull.Value ? null : reader["ImagePath"].ToString();
                dto.NationalityCountryId = (int)reader["NationalityCountryID"];
                reader.Close();

            }
            catch { }
            finally
            {
                Conn.Close();
            }

            return dto;
        }

        public PersonDto GetByFirstSecondLastName(string FirstName, string SecondName, string LastName)
        {
            string Query = "Select * From People Where FirstName = @FN and SecondName = @SN and LastName = @LN ";

            var Conn = new SqlConnection(clsDataSettings.ConncetionString);

            var Command = new SqlCommand(Query, Conn);

            Command.Parameters.AddWithValue("@FN", FirstName);
            Command.Parameters.AddWithValue("@SN", SecondName);
            Command.Parameters.AddWithValue("@LN", LastName);

            var dto = new PersonDto();

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
                dto.Id = (int)reader["PersonId"];
                dto.FirstName = reader["FirstName"].ToString();
                dto.SecondName = reader["SecondName"].ToString();
                dto.ThirdName = reader["ThirdName"] == DBNull.Value ? null : reader["ThirdName"].ToString();
                dto.LastName = reader["LastName"].ToString();
                dto.NationalNo = reader["NationalNo"].ToString();
                dto.DateOfBirth = (DateTime)reader["DateOfBirth"];
                dto.Gendor = (PersonDto.enGendor)((byte)reader["Gendor"]);
                dto.Address = reader["Address"].ToString();
                dto.Phone = reader["Phone"].ToString();
                dto.Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString();
                dto.ImagePath = reader["ImagePath"] == DBNull.Value ? null : reader["ImagePath"].ToString();
                dto.NationalityCountryId = (int)reader["NationalityCountryID"];

                reader.Close();

            }
            catch { }
            finally
            {
                Conn.Close();
            }

            return dto;
        }

        public PersonDto GetByNationalNo(string NationalNo)
        {

            string Query = "Select * From People Where NationalNo = @NationalNo";

            var Connection = new SqlConnection(clsDataSettings.ConncetionString);

            var Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            PersonDto dto = new PersonDto();

            try
            {
                Connection.Open();

                var reader = Command.ExecuteReader();

                if (!reader.HasRows)
                {
                    Connection.Close();
                    return null;
                }

                reader.Read();
                var countryRepo = new CountryRepository();

                dto.Id = (int)reader["PersonId"];
                dto.FirstName = reader["FirstName"].ToString();
                dto.SecondName = reader["SecondName"].ToString();
                dto.ThirdName = reader["ThirdName"] == DBNull.Value ? null : reader["ThirdName"].ToString();
                dto.LastName = reader["LastName"].ToString();
                dto.NationalNo = reader["NationalNo"].ToString();
                dto.DateOfBirth = (DateTime)reader["DateOfBirth"];
                dto.Gendor = (PersonDto.enGendor)((byte)reader["Gendor"]);
                dto.Address = reader["Address"].ToString();
                dto.Phone = reader["Phone"].ToString();
                dto.Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString();
                dto.ImagePath = reader["ImagePath"] == DBNull.Value ? null : reader["ImagePath"].ToString();
                dto.NationalityCountryId = (int)reader["NationalityCountryID"];
                reader.Close();

            }
            catch { }
            finally
            {
                Connection.Close();
            }

            return dto;
        }


        public int Add(PersonDto dto)
        {
            int GeneratedId = -1;

            var Conn = new SqlConnection(clsDataSettings.ConncetionString);

            string Query =
                @"INSERT INTO People
               ([NationalNo]
               ,[FirstName]
               ,[SecondName]
               ,[ThirdName]
               ,[LastName]
               ,[DateOfBirth]
               ,[Gendor]
               ,[Address]
               ,[Phone]
               ,[Email]
               ,[NationalityCountryID]
               ,[ImagePath])
                VALUES
               (@NationalNo,
                @FirstName, 
                @SecondName, 
                @ThirdName,
                @LastName,
                @DateOfBirth, 
                @Gendor, 
                @Address, 
                @Phone, 
                @Email, 
                @NationalityCountryId,
                @ImagePath
                ); Select Scope_Identity();";

            var Command = new SqlCommand(Query, Conn);

            Command.Parameters.AddWithValue("@NationalNo", dto.NationalNo);
            Command.Parameters.AddWithValue("@FirstName", dto.FirstName);
            Command.Parameters.AddWithValue("@SecondName", dto.SecondName);
            Command.Parameters.AddWithValue("@LastName", dto.LastName);
            Command.Parameters.AddWithValue("@Phone", dto.Phone);
            Command.Parameters.AddWithValue("@Address", dto.Address);
            Command.Parameters.AddWithValue("@Gendor", dto.Gendor);
            Command.Parameters.AddWithValue("@DateOfBirth", dto.DateOfBirth);
            Command.Parameters.AddWithValue("@NationalityCountryId", dto.NationalityCountryId);
            Command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(dto.ThirdName) ? (object)DBNull.Value : dto.ThirdName);
            Command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(dto.ImagePath) ? (object)DBNull.Value : dto.ImagePath);
            Command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(dto.Email) ? (object)DBNull.Value : dto.Email);

            


            try
            {
                Conn.Open();

                object Result = Command.ExecuteScalar();

                GeneratedId = Result == null ? -1 : Convert.ToInt32(Result);

                Conn.Close();

            }
            catch { }
            finally { Conn.Close(); }




            return GeneratedId;

        }

        public bool DeleteById(int Id)
        {
            var Connection = new SqlConnection(clsDataSettings.ConncetionString);

            string Query = "Delete From People Where PersonID = @ID";

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

        public bool Update(PersonDto dto)
        {
            int AffectedRows = 0;
            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            string Query = @"
                UPDATE People
                SET NationalNo = @NationalNo,
                    FirstName = @FirstName,
                    SecondName = @SecondName,
                    ThirdName = @ThirdName,
                    LastName = @LastName,
                    DateOfBirth = @DateOfBirth,
                    Gendor = @Gendor,
                    Address = @Address,
                    Phone = @Phone,
                    Email = @Email,
                    NationalityCountryID = @NationalityCountryId,
                    ImagePath = @ImagePath
                WHERE PersonID = @Id";
            var Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@Id", dto.Id);
            Command.Parameters.AddWithValue("@NationalNo", dto.NationalNo);
            Command.Parameters.AddWithValue("@FirstName", dto.FirstName);
            Command.Parameters.AddWithValue("@SecondName", dto.SecondName);
            Command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(dto.ThirdName) ? (object)DBNull.Value : dto.ThirdName);
            Command.Parameters.AddWithValue("@LastName", dto.LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", dto.DateOfBirth);
            Command.Parameters.AddWithValue("@Gendor", dto.Gendor);
            Command.Parameters.AddWithValue("@Address", dto.Address);
            Command.Parameters.AddWithValue("@Phone", dto.Phone);
            Command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(dto.Email) ? (object)DBNull.Value : dto.Email);
            Command.Parameters.AddWithValue("@NationalityCountryId", dto.NationalityCountryId);
            Command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(dto.ImagePath) ? (object)DBNull.Value : dto.ImagePath);

            try
            {
                Connection.Open();

                AffectedRows = Command.ExecuteNonQuery();

            }
            catch { }

            finally { Connection.Close(); }

            return AffectedRows > 0;
        }

        public bool IsExist(int Id)
        {
            bool IsFound = false;

            var Connection = new SqlConnection(clsDataSettings.ConncetionString);

            string Query = "Select 1 from People Where PersonID = @Id";

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

        public bool IsNationalNoExist (string NationalNo)
        {
            bool IsFound;
            
            string Query = "Select 1 From People where NationalNo = @NationalNo";

            var Connection = new SqlConnection(clsDataSettings.ConncetionString);

            var Command = new SqlCommand(Query , Connection);

            Command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                Connection.Open();

                object result = Command.ExecuteScalar();

                IsFound = result is null ? false : true;

            }
            catch
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsFound;
        }

        
    }
}
