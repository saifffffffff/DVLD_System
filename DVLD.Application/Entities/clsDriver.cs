
using System;
using System.Collections.Generic;
using System.Data;
using DVLD_Data.Dtos;
using DVLD_Data.Interfaces;
using DVLD_Data.Repositries;

namespace DVLD_Application.Entities
{
    public class clsDriver : clsEntity
    {

        private static IDriverRepository _repo = new DriverRepository();

        public int Id { get; set; } = -1;

        public int PersonId { get; set; } = -1;

        public int CreatedByUserId { get; set; } = -1;

        public DateTime CreatedDate { get; set; } = DateTime.MinValue;

        public clsDriver()
        {
            _Mode = enMode.Add;
        }

        private clsDriver(DriverDto dto)
        {
            _FromDto(dto);
            _Mode = enMode.Update;
        }

        private void _FromDto(DriverDto dto)
        {
            if (dto == null) return;

            Id = dto.Id;
            PersonId = dto.PersonId;
            CreatedDate = dto.CreatedDate;
            CreatedByUserId = dto.CreatedByUserId;

        }
        private DriverDto _ToDto()
        {
            return new DriverDto { Id = this.Id, PersonId = this.PersonId, CreatedDate = this.CreatedDate  ,CreatedByUserId  = this.CreatedByUserId };
        }

        protected override bool _Add()
        {
            Id = _repo.Add(_ToDto());
            return Id != -1;
        }

        protected override bool _Update()
        {
            throw new System.NotImplementedException();
        }

        public static DataTable GetAll() => _repo.GetAll();

        public static clsDriver GetById( int Id)
        {
            var dto = _repo.GetById(Id);
            
            if ( dto == null) return null;

            return new clsDriver(dto);
        }

        public static clsDriver GetByPersonId(int PersonId)
        {
            var dto = _repo.GetByPersonId(PersonId);
            if ( dto == null) return null;

            return new clsDriver(dto);
        }

        public List<clsLicense> GetAllLocalLicenses() {
            
            var licenseDtos =  _repo.GetAllLocalLicenses(Id);
            
            List<clsLicense> licenses = new List<clsLicense>();
            
            foreach (var dto in licenseDtos) 
                licenses.Add(new clsLicense(dto));

            return licenses;

        }

        public List<clsInternationalLicense> GetAllInternationalLicenses()
        {
            var internationalLicenseDtos = _repo.GetAllInternationalLicenses(Id);

            List<clsInternationalLicense> internationalLicenses = new List<clsInternationalLicense>();

            foreach (var dto in internationalLicenseDtos)
                internationalLicenses.Add(new clsInternationalLicense(dto));
            

            return internationalLicenses;
        }

        public static bool IsExists(int DriverId ) => _repo.IsExist(DriverId);
    }
}
