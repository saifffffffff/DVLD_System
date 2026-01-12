using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data.Dtos;
using DVLD_Data.Interfaces;
using DVLD_Data.Repositories; // Adjust namespace if different

namespace DVLD_Application.Entities
{
    public class clsInternationalLicense : clsEntity
    {
        protected static IInternationalLicenseRepository _repo = new InternationalLicenseRepository();

        // Properties
        public int Id { get; private set; } = -1;
        public int ApplicationId { get; set; }
        public int DriverId { get; set; }
        public int IssuedUsingLocalLicenseId { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }

        // composition
        public clsApplication Application { get; set; }
        

        // Constructors
        public clsInternationalLicense()
        {
            _Mode = enMode.Add;
        }
        internal clsInternationalLicense(InternationalLicenseDto dto) : this()
        {
            LoadFromDto(dto);
            _Mode = enMode.Update;
        }

        private void LoadFromDto(InternationalLicenseDto dto)
        {
            if (dto == null) return;

            Id = dto.Id;
            ApplicationId = dto.ApplicationId;
            DriverId = dto.DriverId;
            IssuedUsingLocalLicenseId = dto.IssuedUsingLocalLicenseId;
            CreatedByUserId = dto.CreatedByUserId;
            IssueDate = dto.IssueDate;
            ExpirationDate = dto.ExpirationDate;
            IsActive = dto.IsActive;

             Application = clsApplication.GetById(ApplicationId);
            
        }

        private InternationalLicenseDto _ToDto()
        {
            return new InternationalLicenseDto
            {
                Id = Id,
                ApplicationId = ApplicationId,
                DriverId = DriverId,
                IssuedUsingLocalLicenseId = IssuedUsingLocalLicenseId,
                CreatedByUserId = CreatedByUserId,
                IssueDate = IssueDate,
                ExpirationDate = ExpirationDate,
                IsActive = IsActive
            };
        }

        // Entity Management Methods

        protected override bool _Add()
        {

            if (Application == null) return false ;

            if ( Application.Save())
            {
                ApplicationId = Application.Id;

                Id = _repo.Add(_ToDto());

                if ( Id != -1 )
                    return true;
                
                clsApplication.Delete(ApplicationId);
                Application = null;
                ApplicationId = -1;
                return false;
            }

            return false;

        }

        protected override bool _Update()
        {
            return _repo.Update(_ToDto());
        }

        public static bool Delete(int Id)
        {
            return _repo.DeleteById(Id);
        }

        public static clsInternationalLicense GetById(int Id)
        {
            var dto = _repo.GetById(Id);
            return dto != null ? new clsInternationalLicense(dto) : null;
        }

        public static DataTable GetAll()
        {
            return _repo.GetAll();
        }

        public static bool IsExist(int Id)
        {
            return _repo.IsExist(Id);
        }

        public static bool HasActiveInternationalDrivingLicense(int DriverId) => _repo.GetActiveInternationalLicenseIdByDriverId(DriverId) != -1;
        
        public static clsInternationalLicense GetActiveInternationalLicenseByDriverId(int DriverId)
        {
            int InternationalLicenseId = _repo.GetActiveInternationalLicenseIdByDriverId(DriverId);

            if (InternationalLicenseId != -1) { 
                return clsInternationalLicense.GetById(InternationalLicenseId);
            }

            return null;

        }

    }
}