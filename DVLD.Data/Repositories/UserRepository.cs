using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DVLD_Data.Dtos;
using DVLD_Data.Interfaces;

namespace DVLD_Data.Repositries
{
    public class UserRepository : IUserRepository
    {
        public int Add(UserDto dto)
        {
            // Note : instead of loading person object into the RAM just pass its personId
            int UserId = -1;

            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            
            //string Query = @"
            //    Insert Into Users
            //    (Username , Password , IsActive , PersonId)
            //    Values (@username ,@password  , @IsActive , @PersonId);
            //    Select Scope_Identity();";
            string Query = @"INSERT INTO Users (PersonID,UserName,Password,IsActive)
                             VALUES (@PersonID, @UserName,@Password,@IsActive);
                             SELECT SCOPE_IDENTITY();";

            var Command = new SqlCommand(Query , Connection);

            Command.Parameters.AddWithValue("@username" , dto.Username);
            Command.Parameters.AddWithValue("@password" , dto.Password);
            Command.Parameters.AddWithValue("@IsActive" , dto.IsActive);
            //Command.Parameters.AddWithValue("@PersonId" , dto.Person.Id);
            Command.Parameters.AddWithValue("@PersonId", dto.PersonId);

            try
            {
                Connection.Open();
                
                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int GeneratedId))
                    UserId = GeneratedId;

            }
            catch { }
            
            finally
            {
                Connection.Close();
            }

            return UserId;
        
        }

        public bool DeleteById(int Id)
        {
            int AffectedRows = 0 ;

            string Query = "Delete From Users Where UserId = @Id";

            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            
            var Command = new SqlCommand(Query , Connection);

            Command.Parameters.AddWithValue("@Id", Id);

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
            string Query = @"select u.* ,
                            FullName = p.FirstName + ' ' + p.SecondName + ' ' + IsNull( p.ThirdName , '') + ' ' + p.LastName
                            from users u
                            join People p on p.PersonID = u.PersonID 
                            ";

            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            
            var Command = new SqlCommand(Query, Connection);

            DataTable DT = new DataTable();

            try
            {
                Connection.Open();

                var reader = Command.ExecuteReader();

                DT.Load(reader);

                reader.Close();
            }
            catch { }
            finally
            {
                Connection.Close();
            }

            return DT;
        }

        public UserDto GetById(int Id)
        {
            string Query = "Select * From Users where UserId = @Id";

            var Connection = new SqlConnection(clsDataSettings.ConncetionString);

            var Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@Id", Id);

            UserDto dto = new UserDto();

            try
            {
                Connection.Open();

                var reader = Command.ExecuteReader();

                if(!reader.HasRows)
                {
                    Connection.Close();
                    return null;
                }

                reader.Read();
                dto.Id = Id;
                dto.Username = (string)reader["UserName"];
                dto.Password = (string)reader["Password"];
                dto.IsActive = (bool)reader["IsActive"];
                dto.PersonId = (int)reader["PersonId"];
                reader.Close();

            }
            catch { }
            finally
            {
                Connection.Close();
            }

            return dto;
        }

        public UserDto GetByUsername(string Username)
        {
            
            string Query = "Select * From Users where username = @username";
            
            var Connection = new SqlConnection(clsDataSettings.ConncetionString);
            
            var Command = new SqlCommand(Query , Connection);

            Command.Parameters.AddWithValue("@username", Username);

            UserDto dto = new UserDto();

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
                dto.Id = (int)reader["UserId"];
                dto.Username = (string)reader["UserName"];
                dto.Password = (string)reader["Password"];
                dto.IsActive = (bool)reader["IsActive"];

                reader.Close();

            }
            catch { return null; }
            finally { Connection.Close(); }

            return dto;

        }

        public bool IsExist(int Id)
        {
            bool IsFound = false;
            
            string Query = "Select 1 From Users Where UserId =  @Id";

            var Connection = new SqlConnection(clsDataSettings.ConncetionString);

            var Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@Id", Id);

            try
            {
                Connection.Open();

                object result  = Command.ExecuteScalar();

                if (result != null) IsFound = true;

            }
            catch { IsFound = false; }
            finally
            { Connection.Close(); }


            return IsFound;

        }

        public bool IsExist(string Username)
        {
            bool IsFound = false;

            string Query = "Select 1 From Users Where Username =  @Username";

            var Connection = new SqlConnection(clsDataSettings.ConncetionString);

            var Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@Username", Username);

            try
            {
                Connection.Open();

                object result = Command.ExecuteScalar();

                if (result != null) IsFound = true;

            }
            catch { IsFound = false; }
            finally
            { Connection.Close(); }


            return IsFound;
        }

        public bool IsExist(string Username, string Password)
        {
            bool IsFound = false;

            string Query = "Select 1 From Users Where Username = @username and Password = @password";

            var Connection = new SqlConnection(clsDataSettings.ConncetionString);

            var Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@username", Username);
            Command.Parameters.AddWithValue("@password", Password);

            try
            {
                Connection.Open();

                object result = Command.ExecuteScalar();

                IsFound = result is null ? false : true;

            }
            catch { IsFound = false; }
            finally { Connection.Close(); }


            return IsFound;
        }

        public bool Update(UserDto dto)
        {
            int AffectedRows = 0;

            string Query = @"Update Users Set 
                            Username = @Username,
                            Password = @Password,
                            IsActive = @IsActive,
                            PersonId = @PersonId
                            Where UserId = @UserId";

            var Connection = new SqlConnection(clsDataSettings.ConncetionString);

            var Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserId", dto.Id);
            Command.Parameters.AddWithValue("@username", dto.Username);
            Command.Parameters.AddWithValue("@password", dto.Password);
            Command.Parameters.AddWithValue("@IsActive", dto.IsActive);
            Command.Parameters.AddWithValue("@PersonId", dto.PersonId);


            try
            {
                Connection.Open();

                AffectedRows = Command.ExecuteNonQuery();


            }

            catch {
                return false;
            }
            finally { Connection.Close(); }

            return AffectedRows > 0;

        }

        public bool IsPersonLinkedToUser(int PersonId)
        {
            bool IsFound = false;

            string Query = "Select 1 From Users Where PersonId = @PersonId";

            var Connection = new SqlConnection(clsDataSettings.ConncetionString);

            var Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonId", PersonId);

            try
            {
                Connection.Open();

                IsFound= Command.ExecuteScalar() != null;

            }
            
            finally { Connection.Close(); }


            return IsFound;

        }

        public UserDto GetByUsernameAndPassword(string Username, string Password)
        {
            string Query = "Select * From Users where username = @username and password = @password";

            var Connection = new SqlConnection(clsDataSettings.ConncetionString);

            var command = new SqlCommand(Query  ,Connection);

            command.Parameters.AddWithValue("@username", Username);
            command.Parameters.AddWithValue("@password", Password);

            UserDto dto = new UserDto();

            try
            {
                Connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    dto.Id = (int)reader["UserID"];
                    dto.Username = (string)reader["UserName"];
                    dto.Password = (string)reader["Password"];
                    dto.PersonId = (int)reader["PersonID"];
                    dto.IsActive = (bool)reader["IsActive"];
                }

                else
                    dto = null;



            }


            catch { }

            finally { Connection.Close(); }

            return dto;
        }
    }
}
