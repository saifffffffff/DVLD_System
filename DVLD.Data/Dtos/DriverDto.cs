using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data.Dtos
{
    public class DriverDto
    {
        public int Id { get; set; }
        
        public int PersonId {get ;set;}
        
        public int CreatedByUserId { get; set; }
        
        public DateTime CreatedDate { get; set; }


    }
}
