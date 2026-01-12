using DVLD_Data.Dtos;

namespace DVLD_Data.Interfaces
{
    public interface ILicenseRepository : IGenericRepository<LicenseDto>    
    {
        LicenseDto GetByApplicationId (int ApplicationId);
        bool DeActivateById(int LicenseId);
        bool IsLicenseDetained(int LicenseId);
    }
}
