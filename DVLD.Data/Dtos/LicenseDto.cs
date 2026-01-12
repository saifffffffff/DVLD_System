using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data.Dtos
{
    public class LicenseDto
    {
        public int Id { get; set; }

        public int ApplicationId { get; set; }

        public int DriverId { get; set; }

        public int LicenseClassId { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Notes { get; set; }

        public decimal PaidFees { get; set; }

        public bool IsActive { get; set; }

        public enum enIssueReason { FirstTime = 1 , Renew , ReplacementForDamaged , ReplacementForLost}  // 1-FirstTime, 2-Renew, 3-Replacement for Damaged, 4- Replacement for Lost.
        public enIssueReason IssueReason { get; set; }


    }
}
