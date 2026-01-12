using DVLD_Data.Dtos;

namespace DVLD_Data.Interfaces
{
    public interface ITestRepository : IGenericRepository<TestDto>
    {
        TestDto GetByTestAppointmentId(int Id);
    }
}
