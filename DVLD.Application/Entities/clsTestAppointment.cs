using System;
using System.Data;
using DVLD_Data.Dtos;
using DVLD_Data.Interfaces;
using DVLD_Data.Repositries;

namespace DVLD_Application.Entities
{
    public class clsTestAppointment : clsEntity
    {
        private static ITestAppointmentRepository _repo = new TestAppointmentRepository();

        // Properties
        public int Id { get; private set; } = -1;
        public int TestTypeId { get; set; } = -1;
        public clsTestType TestType { get; private set; }

        public int LocalDrivingLicenseApplicationId { get; set; } = -1;
        public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication { get; private set; }

        public int CreatedByUserId { get; set; } = -1;
        public clsUser CreatedByUser { get; private set; }

        public int RetakeTestApplicationId { get; set; } = -1;
        public clsApplication RetakeTestApplication { get; private set; }

        public bool IsLocked { get; set; }
        public decimal PaidFees { get; set; }
        public DateTime AppointmentDate { get; set; } = DateTime.MinValue;

        public clsTestAppointment()
        {
            _Mode = enMode.Add;
        }

        private clsTestAppointment(TestAppointmentDto dto) : this()
        {
            LoadFromDto(dto);
            _Mode = enMode.Update;
        }

        private void LoadFromDto(TestAppointmentDto dto)
        {
            if (dto == null) return;

            Id = dto.Id;
            TestTypeId = dto.TestTypeId;
            LocalDrivingLicenseApplicationId = dto.LocalDrivingLicenseApplicationId;
            CreatedByUserId = dto.CreatedByUserId;
            RetakeTestApplicationId = dto.RetakeTestApplicationId;
            IsLocked = dto.IsLocked;
            PaidFees = dto.PaidFees;
            AppointmentDate = dto.AppointmentDate;

            TestType =  clsTestType.GetById(TestTypeId);
            
            CreatedByUser = clsUser.GetById(CreatedByUserId);

            LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetById(LocalDrivingLicenseApplicationId);

            RetakeTestApplication = clsApplication.GetById(RetakeTestApplicationId);
                
        }

        private TestAppointmentDto ToDto()
        {
            return new TestAppointmentDto
            {
                Id = Id,
                TestTypeId = TestTypeId,
                LocalDrivingLicenseApplicationId = LocalDrivingLicenseApplicationId,
                CreatedByUserId = CreatedByUserId,
                RetakeTestApplicationId = RetakeTestApplicationId,
                IsLocked = IsLocked,
                PaidFees = PaidFees,
                AppointmentDate = AppointmentDate
            };
        }

        // Entity Management Methods
        protected override bool _Add()
        {
            Id = _repo.Add(ToDto());

            if (Id != -1)
            {
                TestType = clsTestType.GetById(TestTypeId);
                LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetById(LocalDrivingLicenseApplicationId);
                CreatedByUser = clsUser.GetById(CreatedByUserId);
                RetakeTestApplication = RetakeTestApplicationId != -1
                    ? clsApplication.GetById(RetakeTestApplicationId)
                    : null;

                _Mode = enMode.Update;
                return true;
            }

            return false;
        }

        protected override bool _Update()
        {
             return _repo.Update(ToDto());
        }

        public static DataTable GetAll() => _repo.GetAll();

        public static clsTestAppointment GetById(int Id)
        {
            var dto = _repo.GetById(Id);
            return dto != null ? new clsTestAppointment(dto) : null;
        }

        public static int GetTestTrials(int LocalDrivingLicenseApplicationId, int TestTypeId)
            => _repo.GetTestTrials(LocalDrivingLicenseApplicationId, TestTypeId);

        public static DataTable GetAllByLocalDrivingLicenseAppIdAndTestTypeId(
            int LocalDrivingLicenseApplicationId,
            int TestTypeId)
            => _repo.GetAllByLocalDrivingLicenseAppIdAndTestTypeId(LocalDrivingLicenseApplicationId, TestTypeId);
    }
}