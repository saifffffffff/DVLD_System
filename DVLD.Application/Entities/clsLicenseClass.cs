using System;
using System.Data;
using DVLD_Data.Dtos;
using DVLD_Data.Interfaces;
using DVLD_Data.Repositries;

namespace DVLD_Application.Entities
{
    public class clsLicenseClass : clsEntity
    {
        private static ILicenseClassRepository _repo = new LicenseClassRepository();


        // properites
        public int Id { get; private set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal Fees { get; set; }
        
        public enum enLicenseClass {
            SmallMotorcycle = 1,
            HeavyMotorcycle,
            OrdinaryDiving,
            Commercial,
            Agricultural,
            SmallشndMediumBus,
            TruckAndHeavyVehicle
        };
        
        // constructors
        public clsLicenseClass()
        {
            _Mode = enMode.Update;
        }
        private clsLicenseClass(LicenseClassDto dto) : this()
        {
            LoadFromDto(dto);
            _Mode = enMode.Update;
        }

        private void LoadFromDto(LicenseClassDto dto)
        {
            if (dto == null) return;

            Id = dto.Id;
            Name = dto.Name ?? string.Empty;
            Description = dto.Description ?? string.Empty;
            MinimumAllowedAge = dto.MinimumAllowedAge;
            DefaultValidityLength = dto.DefaultValidityLength;
            Fees = dto.Fees;
        }

        private LicenseClassDto ToDto()
        {
            return new LicenseClassDto
            {
                Id = Id,
                Name = Name,
                Description = Description,
                MinimumAllowedAge = MinimumAllowedAge,
                DefaultValidityLength = DefaultValidityLength,
                Fees = Fees
            };
        }

        // Entity Management Methods
        
        protected override bool _Add() => false;

        protected override bool _Update() => false;

        public static DataTable GetAll() => _repo.GetAll();

        public static clsLicenseClass GetById(int Id)
        {
            var dto = _repo.GetById(Id);
            return dto != null ? new clsLicenseClass(dto) : null;
        }

        public static decimal GetClassFeesByName(string name) => _repo.GetClassFeesByName(name);

        public static clsLicenseClass GetClassByName(string name)
        {
            var dto = _repo.GetClassByName(name);
            return dto != null ? new clsLicenseClass(dto) : null;
        }
    }
}