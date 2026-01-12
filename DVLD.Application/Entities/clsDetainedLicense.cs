using System;
using System.Data;
using DVLD_Data.Dtos;
using DVLD_Data.Interfaces;
using DVLD_Data.Repositories;

namespace DVLD_Application.Entities
{
    public class clsDetainedLicense : clsEntity
    {
        protected static IDetainedLicenseRepository _repo = new DetainedLicenseRepository();

        public int Id { get; private set; } = -1;
        public int LicenseId { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserId { get; set; }
        public bool IsReleased { get; set; }
        public DateTime DetainDate { get; set; }

        public DateTime? ReleaseDate { get; set; }
        public int? ReleasedByUserId { get; set; }
        public int? ReleaseApplicationId { get; set; }

        public clsLicense License { get; set; }
        public clsApplication ReleaseApplication { get; set; }

        public clsDetainedLicense()
        {
            _Mode = enMode.Add;
        }

        internal clsDetainedLicense(DetainedLicenseDto dto) : this()
        {
            _LoadFromDto(dto);
            _Mode = enMode.Update;
        }

        private void _LoadFromDto(DetainedLicenseDto dto)
        {
            if (dto == null) return;

            Id = dto.Id;
            LicenseId = dto.LicenseId;
            FineFees = dto.FineFees;
            CreatedByUserId = dto.CreatedByUserId;
            IsReleased = dto.IsReleased;
            ReleaseDate = dto.ReleaseDate;
            ReleasedByUserId = dto.ReleasedByUserId;
            ReleaseApplicationId = dto.ReleaseApplicationId;
            DetainDate = dto.DetainDate;
            License = clsLicense.GetById(LicenseId);

            ReleaseApplication = ReleaseApplicationId != null ? clsApplication.GetById((int)ReleaseApplicationId) : null;

        }

        private DetainedLicenseDto _ToDto()
        {
            return new DetainedLicenseDto
            {
                Id = Id,
                LicenseId = LicenseId,
                FineFees = FineFees,
                CreatedByUserId = CreatedByUserId,
                IsReleased = IsReleased,
                ReleaseDate = ReleaseDate,
                ReleasedByUserId = ReleasedByUserId,
                ReleaseApplicationId = ReleaseApplicationId,
                DetainDate = DetainDate
            };
        }

        protected override bool _Add()
        {
            Id = _repo.Add(_ToDto());
            if (Id != -1)
            {
                License = clsLicense.GetById(LicenseId);
                ReleaseApplication = ReleaseApplicationId != null ? clsApplication.GetById((int)ReleaseApplicationId) : null;
                return true;
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

        public static clsDetainedLicense GetById(int Id)
        {
            var dto = _repo.GetById(Id);
            return dto != null ? new clsDetainedLicense(dto) : null;
        }

        public static DataTable GetAll()
        {
            return _repo.GetAll();
        }

        public static bool IsExist(int Id)
        {
            return _repo.IsExist(Id);
        }

        

        public static int GetDetainedLicenseIdByLicenseId(int LicenseId) => _repo.GetDetainedLicenseIdByLicenseId(LicenseId);

        public static clsDetainedLicense GetDetainedLicenseByLicenseId(int LicenseId) {
            int Id = _repo.GetDetainedLicenseIdByLicenseId(LicenseId);
            
            if ( Id != -1)
                return clsDetainedLicense.GetById(Id);
            return null;
    
         }

        public static bool Release( int detainedLicenseId, int ReleasedByUserId, ref int ReleaseApplicationId)
        {


            clsApplication ReleaseApplication = new clsApplication();

            ReleaseApplication.ApplicantPersonId = clsDetainedLicense.GetById(detainedLicenseId).License.Application.ApplicantPersonId;
            ReleaseApplication.ApplicationTypeId = (int)clsApplicationType.enApplicationType.ReleaseDetainedDrivingLicense;
            ReleaseApplication.CreatedByUserId = ReleasedByUserId;
            ReleaseApplication.Date = DateTime.Now;
            ReleaseApplication.Status = clsApplication.enApplicationStatus.New;
            ReleaseApplication.LastStatusDate = DateTime.Now;
            ReleaseApplication.PaidFees = clsApplicationType.GetById((int)clsApplicationType.enApplicationType.ReleaseDetainedDrivingLicense).Fees;

            if (!ReleaseApplication.Save()) return false;
            
            
            if (!_repo.Release( detainedLicenseId, ReleasedByUserId, ReleaseApplication.Id))
            {
                clsApplication.Delete(ReleaseApplication.Id);
                return false;
            }

            ReleaseApplicationId = ReleaseApplication.Id;
            return true;

        }

        public bool Release(int ReleasedByUserId, ref int ReleaseApplicationId)
        {

            if ( Release(this.Id, ReleasedByUserId, ref ReleaseApplicationId))
            {
                this.IsReleased = true;
                this.ReleaseDate = DateTime.Now;
                this.ReleaseApplicationId = ReleaseApplicationId;
                this.ReleasedByUserId = ReleasedByUserId;
                return true;
            }
            return false;
        }   
    }
}