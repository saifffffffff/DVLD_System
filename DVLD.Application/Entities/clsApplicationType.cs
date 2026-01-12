using System.Data;
using DVLD_Data.Dtos;
using DVLD_Data.Interfaces;
using DVLD_Data.Repositries;

namespace DVLD_Application.Entities
{
    public class clsApplicationType : clsEntity
    {
        private static IApplicationTypeRepository _repo = new ApplicationTypeRepository();

        public int Id { get; private set; }
        public string Title { get; set; } = string.Empty;
        public decimal Fees { get; set; }

        public enum enApplicationType { NewLocalDrivingLicenseService = 1 , RenewDrivingLicenseService , ReplacementForLostDrivingLicense , ReplacementForDamagedDrivingLicense , ReleaseDetainedDrivingLicense , NewInternationalLicense , RetakeTest};
        
        // Constructors
        public clsApplicationType()
        {
            _Mode = enMode.Update;
        }
        private clsApplicationType(ApplicationTypeDto dto) : this()
        {
            LoadFromDto(dto);
            _Mode = enMode.Update;
        }

        private void LoadFromDto(ApplicationTypeDto dto)
        {
            if (dto == null) return;

            Id = dto.Id;
            Title = dto.Title ?? string.Empty;
            Fees = dto.Fees;
        }

        private ApplicationTypeDto ToDto()
        {
            return new ApplicationTypeDto
            {
                Id = Id,
                Title = Title,
                Fees = Fees
            };
        }

        // Entity Management Methods

        protected override bool _Add() => false;
        protected override bool _Update() => _repo.Update(ToDto());

        public static DataTable GetAll() => _repo.GetAll();

        public static clsApplicationType GetById(int Id)
        {
            var dto = _repo.GetById(Id);
            return dto != null ? new clsApplicationType(dto) : null;
        }
    }
}