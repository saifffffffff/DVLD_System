using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data.Dtos
{
    public class PersonDto
    {

        public int Id { get; set; }
        
        public string NationalNo { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string ThirdName { get; set; } // nullable

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public enum enGendor { Male , Female}
        public enGendor Gendor { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int NationalityCountryId { get; set; }

        public string ImagePath { get; set; } // nullable



    }
}
