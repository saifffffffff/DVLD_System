
using DVLD_Data.Dtos;
using DVLD_Data.Interfaces;
using DVLD_Data.Repositries;

namespace DVLD_Application.Entities
{
    public class clsTest : clsEntity
    {
        private static ITestRepository _repo = new TestRepository();

        public int Id { get; set; } = -1;

        public int TestAppointmentId { get; set; } = -1;
        public clsTestAppointment TestAppointment { get; set; }

        public int CreatedByUserId { get; set; } = -1;
        public clsUser CreatedByUser { get; set; }

        public bool TestResult { get; set; } = false;

        public string Notes { get; set; } = string.Empty;

        // Constructors 

        public clsTest()
        {
            _Mode = enMode.Add;
        }

        private clsTest(TestDto dto)
        {
            _FromDto(dto);
            _Mode = enMode.Update;
        }

        TestDto _ToDto()
        {

            return new TestDto() { 
                Id = this.Id ,
                TestAppointmentId = this.TestAppointmentId ,
                CreatedByUserId = this.CreatedByUserId ,
                TestResult = this.TestResult ,
                Notes = this.Notes 
            };

        }

        void _FromDto(TestDto dto)
        {
            
            Id =dto.Id;
            
            TestAppointmentId = dto.TestAppointmentId;
            CreatedByUserId = dto.CreatedByUserId;
            TestResult = dto.TestResult;
            Notes = dto.Notes;
            
            TestAppointment = clsTestAppointment.GetById(TestAppointmentId);
            CreatedByUser = clsUser.GetById(CreatedByUserId);

        }

        protected override bool _Add()
        {
            Id = _repo.Add(_ToDto());
            
            if ( Id != -1)
            {
                CreatedByUser = clsUser.GetById(CreatedByUserId);
                TestAppointment = clsTestAppointment.GetById(TestAppointmentId);
                return true;
            }

            return false;
        }

        protected override bool _Update() => _repo.Update(_ToDto());
        
        public static clsTest GetById(int Id) {
            var dto = _repo.GetById(Id);
            
            if ( dto == null) return null;

            return new clsTest(dto);
        }
        
        public static clsTest GetByTestAppointmentId(int AppointmentId)
        {
            var dto = _repo.GetByTestAppointmentId(AppointmentId);

            if (dto == null ) return null;

            return new clsTest(dto);

        }
   
    }
}
