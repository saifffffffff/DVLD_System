using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data.Dtos
{
    public class DetainedLicenseDto
    {
        public int Id { get; set; }

        public int LicenseId { get; set; }

        public decimal FineFees { get; set; }

        public int CreatedByUserId { get; set; }

        public bool IsReleased { get; set; }

        public DateTime DetainDate { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int? ReleasedByUserId { get; set; }

        public int? ReleaseApplicationId { get; set; }

    }
}
