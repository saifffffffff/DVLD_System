using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data.Dtos;

namespace DVLD_Data.Interfaces
{
    public interface ILicenseClassRepository : IGenericRepository<LicenseClassDto>
    {
        
        decimal GetClassFeesByName(string name);
        LicenseClassDto GetClassByName(string name);
    }
}
