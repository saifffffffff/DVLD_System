using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data.Dtos;

namespace DVLD_Data.Interfaces
{
    public interface ITestAppointmentRepository : IGenericRepository<TestAppointmentDto>
    {
        int GetTestTrials(int LocalDrivingLicenseApplicationId , int TestTypeId); 
        DataTable GetAllByLocalDrivingLicenseAppIdAndTestTypeId (int LocalDrivingLicenseApplicationId , int TestTypeId);
    }
}
