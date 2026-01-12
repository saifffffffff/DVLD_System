using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data.Dtos
{
    public class LocalDrivingLicenseApplicationDto
    {
        public int Id { get; set; }

        public int ApplicationId { get; set; }

        public int LicenseClassID { get; set; }
    }
}
