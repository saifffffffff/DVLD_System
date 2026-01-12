using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data.Dtos;

namespace DVLD_Data
{

    public interface IGenericRepository<TDto>
    {
        DataTable GetAll();

        TDto GetById(int Id);


        /// <returns>
        /// The ID of the newly added person if the operation succeeds; otherwise, -1 if the insertion fails.
        /// </returns>
         int Add(TDto dto);

        bool DeleteById(int Id);

        bool IsExist(int Id);
        
        bool Update(TDto dto);
    }

     
}
