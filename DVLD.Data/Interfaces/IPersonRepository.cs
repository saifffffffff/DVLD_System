using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data.Dtos;

namespace DVLD_Data.Repositries
{
    public interface IPersonRepository : IGenericRepository<PersonDto>
    {
        bool IsNationalNoExist(string NationalNo);
        PersonDto GetByFirstSecondLastName(string f, string s, string l);
        PersonDto GetByNationalNo(string NationalNo);
        
    }
}
