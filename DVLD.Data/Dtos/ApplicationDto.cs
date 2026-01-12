using System;

namespace DVLD_Data.Dtos
{
    public class ApplicationDto
    {

        public int Id { get; set; }
        
        public int ApplicantPersonId {get; set; }

        public int ApplicationTypeId { get; set; }

        public int CreatedByUserId { get; set; }

        public enum enApplicationStatus { New = 1, Cancelled =2 , Completed = 3}
        public enApplicationStatus Status { get; set; }

        public DateTime Date { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }


    }
}
