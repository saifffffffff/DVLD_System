using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data.Dtos;
using DVLD_Data.Interfaces;
using DVLD_Data.Repositries;

namespace DVLD_Application.Entities
{
    public class clsLicense : clsEntity
    {

        private static ILicenseRepository _repo = new LicenseRepository();

        public int Id { get; private set; } = -1;

        public int ApplicationId { get; set; } = -1;
        public clsApplication Application { get; set; }

        public int DriverId { get; set; } = -1;
        public clsDriver Driver { get; set; }

        public int LicenseClassId { get; set; } = -1;
        public clsLicenseClass LicenseClass { get; set; }

        public int CreatedByUserId { get; set; } = -1;

        public DateTime IssueDate { get; set; } = DateTime.MinValue;

        public DateTime ExpirationDate { get; set; } = DateTime.MinValue;

        public string Notes { get; set; } // nullable

        public decimal PaidFees { get; set; }

        public bool IsActive { get; set; }

        public enum enIssueReason { FirstTime = 1, Renew, ReplacementForDamaged, ReplacementForLost }

        public enIssueReason IssueReason { get; set; }

        public bool IsExpired => ExpirationDate <= DateTime.Now;
        
        public bool IsDetained => _repo.IsLicenseDetained(Id);

        // Constructors
        public clsLicense()
        {
            _Mode = enMode.Add;
        }
        internal clsLicense(LicenseDto dto)
        {
            _FromDto(dto);
            _Mode = enMode.Update;
        }

        // Entity Management Methods

        private void _FromDto(LicenseDto dto)
        {
            if (dto == null) return;
            Id = dto.Id;
            ApplicationId = dto.ApplicationId;
            DriverId = dto.DriverId;
            LicenseClassId = dto.LicenseClassId;
            CreatedByUserId = dto.CreatedByUserId;
            IssueDate = dto.IssueDate;
            ExpirationDate = dto.ExpirationDate;
            Notes = dto.Notes;
            PaidFees = dto.PaidFees;
            IsActive = dto.IsActive;
            IssueReason = (enIssueReason)dto.IssueReason;
            Application = clsApplication.GetById(ApplicationId);
            LicenseClass = clsLicenseClass.GetById(LicenseClassId);
            Driver = clsDriver.GetById(DriverId);
        }
        private LicenseDto _ToDto()
        {
            return new LicenseDto {
                Id = this.Id,
                ApplicationId = this.ApplicationId,
                CreatedByUserId = this.CreatedByUserId,
                DriverId = this.DriverId,
                ExpirationDate = this.ExpirationDate,
                IsActive = this.IsActive,
                IssueDate = this.IssueDate,
                IssueReason = (LicenseDto.enIssueReason)this.IssueReason,
                LicenseClassId = this.LicenseClassId,
                Notes = this.Notes,
                PaidFees = this.PaidFees
            };
        }

        protected override bool _Add()
        {
            Id = _repo.Add(_ToDto());

            if (Id != -1)
            {
                Application = clsApplication.GetById(ApplicationId);
                LicenseClass = clsLicenseClass.GetById(LicenseClassId);
                return true;
            }

            return false;
        }

        protected override bool _Update() => _repo.Update(_ToDto());

        public static DataTable GetAll() => _repo.GetAll();

        public static clsLicense GetById(int Id)
        {
            var dto = _repo.GetById(Id);
            if (dto == null) return null;

            return new clsLicense(dto);
        }

        public static clsLicense GetByApplicationId(int ApplicationId)
        {
            var dto = _repo.GetByApplicationId(ApplicationId);
            if (dto == null) return null;
            return new clsLicense(dto);
        }

        public static bool IsExist(int Id) => _repo.IsExist(Id);

        public static bool Delete(int Id) => _repo.DeleteById(Id);

        public bool DeActivate() => DeActivate(Id);

        public static bool DeActivate(int LicenseId) => _repo.DeActivateById(LicenseId);

        public clsLicense Renew (string Notes , int CreatedByUserId)
        {

            if (!this.IsActive) return null;

            var RenewApplication = new clsApplication();
            RenewApplication.Status = clsApplication.enApplicationStatus.New;
            RenewApplication.ApplicantPersonId = this.Application.ApplicantPersonId;
            RenewApplication.ApplicationTypeId = (int)clsApplicationType.enApplicationType.RenewDrivingLicenseService;
            RenewApplication.Date = DateTime.Now;
            RenewApplication.LastStatusDate = DateTime.Now;
            RenewApplication.CreatedByUserId = CreatedByUserId;
            RenewApplication.PaidFees = clsApplicationType.GetById((int)clsApplicationType.enApplicationType.RenewDrivingLicenseService).Fees;

            if (!RenewApplication.Save()) return null;

            var NewLicense = new clsLicense()
            {
                ApplicationId = RenewApplication.Id,
                IsActive = true,
                CreatedByUserId = CreatedByUserId,
                IssueDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears(LicenseClass.DefaultValidityLength),
                DriverId = this.DriverId,
                Notes = Notes,
                PaidFees = this.PaidFees,
                LicenseClassId = this.LicenseClassId,
                IssueReason = enIssueReason.Renew
            };

            if (!NewLicense.Save())
            {
                clsApplication.Delete(RenewApplication.Id);
                return null;
            }

            DeActivate();

            return NewLicense;

        }

        private clsLicense _Replace( int CreatedByUserId , clsApplicationType.enApplicationType applicationType , clsLicense.enIssueReason issueReason)
       {

            if (!IsActive) return null;

            var ReplacementApplication = new clsApplication();
            ReplacementApplication.Status = clsApplication.enApplicationStatus.New;
            ReplacementApplication.ApplicantPersonId = this.Application.ApplicantPersonId;
            ReplacementApplication.ApplicationTypeId = (int)applicationType;
            ReplacementApplication.Date = DateTime.Now;
            ReplacementApplication.LastStatusDate = DateTime.Now;
            ReplacementApplication.CreatedByUserId = CreatedByUserId;
            ReplacementApplication.PaidFees = clsApplicationType.GetById((int)clsApplicationType.enApplicationType.RenewDrivingLicenseService).Fees;

            if (!ReplacementApplication.Save()) return null;

            clsLicense NewLicense = new clsLicense()
            {
                ApplicationId = ReplacementApplication.Id,
                IsActive = true,
                CreatedByUserId = CreatedByUserId,
                IssueDate = this.IssueDate,
                ExpirationDate = this.ExpirationDate,
                DriverId = this.DriverId,
                Notes = this.Notes,
                PaidFees = this.PaidFees,
                LicenseClassId = this.LicenseClassId,
                IssueReason = issueReason
            };

            if(!NewLicense.Save())
            {
                clsApplication.Delete(ReplacementApplication.Id); // rollback   
                return null;
            }

            this.DeActivate();

            return NewLicense;

       }
        public clsLicense ReplaceForDamaged( int CreatedByUserId) => _Replace(CreatedByUserId, clsApplicationType.enApplicationType.ReplacementForDamagedDrivingLicense, enIssueReason.ReplacementForDamaged);
        public clsLicense ReplaceForLost(int CreatedByUserId) => _Replace(CreatedByUserId , clsApplicationType.enApplicationType.ReplacementForLostDrivingLicense , enIssueReason.ReplacementForLost);
       
        public static int DetainLicense(int LicenseId , decimal FineFees , int CreatedByUserId)
        {
            clsDetainedLicense detainedLicense = new clsDetainedLicense()
            {
                LicenseId = LicenseId,
                DetainDate = DateTime.Now,
                FineFees = FineFees,
                CreatedByUserId = CreatedByUserId,
                IsReleased = false,
                ReleasedByUserId = null,
                ReleaseApplicationId = null,
                ReleaseDate = null
            };

            if (detainedLicense.Save())
                return detainedLicense.Id;
            
            return -1;

        }
        
        public int Detain(decimal FineFees , int CreatedByUserId) => DetainLicense(this.Id , FineFees , CreatedByUserId);

        


    }
}
