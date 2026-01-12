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
    public class LicenseClassRepository : ILicenseClassRepository
    {
        public int Add(LicenseClassDto dto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int Id)
        {
            throw new NotImplementedException();
        }



        public bool IsExist(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(LicenseClassDto dto)
        {
            throw new NotImplementedException();
        }
    
        // implemented
        public DataTable GetAll()
        {
            var DataTable = new DataTable();

            var Conn = new SqlConnection(clsDataSettings.ConncetionString);

            string Query = "Select * From LicenseClasses";

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
    
        public LicenseClassDto GetById(int Id)
        {
            string Query = "Select * From LicenseClasses Where LicenseClassID = @Id";

            var Conn = new SqlConnection(clsDataSettings.ConncetionString);

            var Command = new SqlCommand(Query, Conn);

            Command.Parameters.AddWithValue("@Id", Id);

            LicenseClassDto dto= null;

            try
            {
                Conn.Open();

                var reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    dto = new LicenseClassDto();
                    dto.Id = (int)reader["LicenseClassID"];
                    dto.Name = reader["ClassName"].ToString();
                    dto.Description = reader["ClassDescription"].ToString();
                    dto.Fees = (decimal)reader["ClassFees"];
                    dto.DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    dto.MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                }

                reader.Close();

            }
            catch { }
            finally
            {
                Conn.Close();
            }

            return dto;
        }
    
        public decimal GetClassFeesByName(string name)
        {
            string Query = "Select ClassFees From LicenseClasses Where ClassName = @Name";
            
            var Conn = new SqlConnection(clsDataSettings.ConncetionString);
            
            var Command = new SqlCommand(Query, Conn);
            
            Command.Parameters.AddWithValue("@Name", name);
            
            decimal fees = -1;
            
            try
            {
                Conn.Open();
                                
                fees = Command.ExecuteScalar() != null ? (decimal)Command.ExecuteScalar() : -1;

            }
            catch { }
            finally
            {
                Conn.Close();
            }

            return fees;
        }
    
        public LicenseClassDto GetClassByName(string name)
        {
            string Query = "Select * From LicenseClasses Where ClassName = @Name";

            var Conn = new SqlConnection(clsDataSettings.ConncetionString);
            var Command = new SqlCommand(Query, Conn);
            
            Command.Parameters.AddWithValue("@Name", name);
            
            LicenseClassDto dto = null;
            
            try
            {
                Conn.Open();
                var reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    dto = new LicenseClassDto();
                    dto.Id = (int)reader["LicenseClassID"];
                    dto.Name = reader["ClassName"].ToString();
                    dto.Description = reader["ClassDescription"].ToString();
                    dto.Fees = (decimal)reader["ClassFees"];
                    dto.DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    dto.MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                }
                reader.Close();
            }
            catch { }
            finally
            {
                Conn.Close();
            }
            return dto;
        }
    }
}
