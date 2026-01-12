using System;
using System.Data;
using DVLD_Data.Dtos;
using DVLD_Data.Interfaces;
using DVLD_Data.Repositries;

namespace DVLD_Application.Entities
{
    public class clsApplication : clsEntity
    {
        private static IApplicationRepository _repo = new ApplicationRepository();

        // properities
        public int Id { get; protected set; } = -1;
        public int ApplicantPersonId { get; set; } = -1;
        public clsPerson ApplicantPerson { get; protected set; }
        public int ApplicationTypeId { get; set; } = -1;
        public clsApplicationType ApplicationType { get; protected set; }
        public int CreatedByUserId { get; set; } = -1;
        public clsUser CreatedByUser { get; protected set; }

        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 }
        public enApplicationStatus Status { get; set; } = enApplicationStatus.New;

        public DateTime Date { get; set; } = DateTime.Now;
        public DateTime LastStatusDate { get; set; } = DateTime.Now;
        public decimal PaidFees { get; set; }

        // Constructors

        public clsApplication()
        {
            _Mode = enMode.Add;
        }
        private clsApplication(ApplicationDto dto) : this()
        {
            _LoadFromDto(dto);
            _Mode = enMode.Update;
        }

        private void _LoadFromDto(ApplicationDto dto)
        {
            if (dto == null) return;

            Id = dto.Id;
            ApplicantPersonId = dto.ApplicantPersonId;
            ApplicationTypeId = dto.ApplicationTypeId;
            CreatedByUserId = dto.CreatedByUserId;
            Status = (enApplicationStatus)dto.Status;
            Date = dto.Date;
            LastStatusDate = dto.LastStatusDate;
            PaidFees = dto.PaidFees;

            ApplicantPerson = ApplicantPersonId != -1 ? clsPerson.GetById(ApplicantPersonId) : null;
            ApplicationType = ApplicationTypeId != -1 ? clsApplicationType.GetById(ApplicationTypeId) : null;
            CreatedByUser = CreatedByUserId != -1 ? clsUser.GetById(CreatedByUserId) : null;
        }
        private ApplicationDto _ToDto()
        {
            return new ApplicationDto
            {
                Id = Id,
                ApplicantPersonId = ApplicantPersonId,
                ApplicationTypeId = ApplicationTypeId,
                CreatedByUserId = CreatedByUserId,
                Status = (ApplicationDto.enApplicationStatus)Status,
                Date = Date,
                LastStatusDate = LastStatusDate,
                PaidFees = PaidFees
            };
        }


        // Entity Management methods

        protected override bool _Add()
        {
            Id = _repo.Add(_ToDto());

            if (Id != -1)
            {
                ApplicantPerson = clsPerson.GetById(ApplicantPersonId);
                ApplicationType = clsApplicationType.GetById(ApplicationTypeId);
                CreatedByUser = clsUser.GetById(CreatedByUserId);
                return true;
            }

            return false;
        }

        protected override bool _Update() => _repo.Update(_ToDto());

        public static bool Delete(int Id) => _repo.DeleteById(Id);

        public static bool IsExist(int Id) => _repo.IsExist(Id);

        public static clsApplication GetById(int Id)
        {
            var dto = _repo.GetById(Id);
            return dto != null ? new clsApplication(dto) : null;
        }

        public static DataTable GetAll() => _repo.GetAll();

        public static bool DoesPersonHaveActiveApplication(int PersonId, int ApplicationTypeId)
            => _repo.DoesPersonHaveActiveApplication(PersonId, ApplicationTypeId);
        
        public bool Cancel()
        {
            if (Status == enApplicationStatus.Completed) return false;

            return _repo.CancelApplication(Id);
        }

    }
}