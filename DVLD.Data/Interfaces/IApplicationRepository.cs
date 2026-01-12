using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data.Dtos;

namespace DVLD_Data.Interfaces
{
    public interface IApplicationRepository : IGenericRepository<ApplicationDto>
    {
        bool DoesPersonHaveActiveApplication(int ApplicantPersonId, int ApplicationTypeId);
        int GetActiveApplicationID(int ApplicantPersonId, int ApplicationTypeId);
        bool CancelApplication(int ApplicationId);
        
    }
}
