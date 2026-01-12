using System.Collections.Generic;
using System.Data;
using DVLD_Data.Dtos;

namespace DVLD_Data.Interfaces
{
    public interface IDriverRepository : IGenericRepository<DriverDto>
    {
        
        DriverDto GetByPersonId(int PersonId);

        List<LicenseDto> GetAllLocalLicenses(int DriverId);

        List<InternationalLicenseDto> GetAllInternationalLicenses(int DriverId);

    }
}
