using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace DVLD_Data.Dtos
{
    public class TestDto
    {
        public int Id { get; set; }
        
        public int TestAppointmentId { get; set; }

        public int CreatedByUserId { get; set; }

        public bool TestResult { get; set; }

        public string Notes { get; set; }
    }
}
