
using DVLD_Data.Dtos;

namespace DVLD_Data.Interfaces
{
    public interface IInternationalLicenseRepository : IGenericRepository<InternationalLicenseDto>
    {
        int GetActiveInternationalLicenseIdByDriverId(int DriverId);
    }
}
