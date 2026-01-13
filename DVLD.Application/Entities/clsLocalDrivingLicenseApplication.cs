using System;
using System.Data;
using System.Net.WebSockets;
using DVLD_Data.Dtos;
using DVLD_Data.Interfaces;
using DVLD_Data.Repositries;

namespace DVLD_Application.Entities
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        private static ILocalDrivingLicenseApplicationRepository _repo = new LocalDrivingLicenseApplicationRepository();

        public int ApplicationId { get => base.Id; set => base.Id = value; }
        public new int Id { get; set; } = -1;
        public int LicenseClassID { get; set; } = -1;
        public clsLicenseClass LicenseClass { get; private set; }
        public byte PassedTestsCount => _repo.PassedTestsCount(this.Id);

        public clsLocalDrivingLicenseApplication()
        {
            _Mode = enMode.Add;
        }

        private clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationDto dto) : this()
        {
            LoadFromDto(dto);
            _Mode = enMode.Update;
        }

        private void LoadFromDto(LocalDrivingLicenseApplicationDto dto)
        {
            if (dto == null) return;

            Id = dto.Id;
            ApplicationId = dto.ApplicationId;
            LicenseClassID = dto.LicenseClassID;

            base.Id = dto.ApplicationId;

            var baseApp = clsApplication.GetById(dto.ApplicationId);
            if (baseApp != null)
            {
                ApplicantPersonId = baseApp.ApplicantPersonId;
                ApplicantPerson = baseApp.ApplicantPerson;
                ApplicationTypeId = baseApp.ApplicationTypeId;
                ApplicationType = baseApp.ApplicationType;
                CreatedByUserId = baseApp.CreatedByUserId;
                CreatedByUser = baseApp.CreatedByUser;
                Date = baseApp.Date;
                LastStatusDate = baseApp.LastStatusDate;
                PaidFees = baseApp.PaidFees;
                Status = baseApp.Status;
            }

            LicenseClass = LicenseClassID != -1 ? clsLicenseClass.GetById(LicenseClassID) : null;
        }

        private LocalDrivingLicenseApplicationDto ToDto()
        {
            return new LocalDrivingLicenseApplicationDto
            {
                Id = Id,
                ApplicationId = ApplicationId,
                LicenseClassID = LicenseClassID
            };
        }

        protected new bool _Add()
        {
            Id = _repo.Add(ToDto());

            if (Id != -1)
            {
                LicenseClass = clsLicenseClass.GetById(LicenseClassID);
                return true;
            }
            return false;
        }

        protected new bool _Update() => _repo.Update(ToDto());

        public static new DataTable GetAll() => _repo.GetAll();

        public static new clsLocalDrivingLicenseApplication GetById(int Id)
        {
            var dto = _repo.GetById(Id);
            return dto != null ? new clsLocalDrivingLicenseApplication(dto) : null;
        }

        
        /// <returns> -1 if Local Driving license Application ID is not found </returns>
        public static sbyte CountPassedTests(int LocalDrivingLicenseApplicationId)
        {

            if ( !IsExist(LocalDrivingLicenseApplicationId)) { return -1; }

            return (sbyte)_repo.PassedTestsCount(LocalDrivingLicenseApplicationId);

        }

        public static new bool Delete(int Id) => _repo.DeleteById(Id);

        public static new bool IsExist(int Id) => _repo.IsExist(Id);

        public override bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    if (base.Save())
                    {
                        if (_Add())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        clsApplication.Delete(base.Id);
                    }
                    return false;

                case enMode.Update:
                    if (base.Save())
                    {
                        return _Update();
                    }
                    return false;

                default:
                    return false;
            }
        }

        public bool IsLicenseIssued()
        {
            // return clsLicense.GetActiveLicenseId(this.ApplicantPersonId, LicenseClassID) != -1;
            return clsLicense.GetByApplicationId(ApplicationId) != null;
        }

    }
}