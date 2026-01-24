using System;
using System.Data;
using DVLD_Data.Dtos;
using System.IO;
using DVLD_Data.Repositries;

namespace DVLD_Application.Entities
{
    public class clsPerson : clsEntity
    {
        protected static IPersonRepository _repo = new PersonRepository();

        // Properties
        public int Id { get; private set; } = -1;
        public string NationalNo { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string ThirdName { get; set; } // nullable
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public enum enGendor { Male, Female }
        public enGendor Gendor { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } // nullable
        public int NationalityCountryId { get; set; } = -1;
        public string ImagePath { get; set; } // nullable

        public string FullName =>
            $"{FirstName} {SecondName} {(string.IsNullOrEmpty(ThirdName) ? "" : ThirdName + " ")}{LastName}".Trim();

        public clsCountry Country { get; private set; }

        // Constructors
        public clsPerson()
        {
            _Mode = enMode.Add;
        }

        private clsPerson(PersonDto dto) : this()
        {
            LoadFromDto(dto);
            _Mode = enMode.Update;
        }


        private void LoadFromDto(PersonDto dto)
        {
            if (dto == null) return;

            Id = dto.Id;
            NationalNo = dto.NationalNo ?? string.Empty;
            FirstName = dto.FirstName ?? string.Empty;
            SecondName = dto.SecondName ?? string.Empty;
            ThirdName = dto.ThirdName;
            LastName = dto.LastName ?? string.Empty;
            DateOfBirth = dto.DateOfBirth;
            Gendor = dto.Gendor == PersonDto.enGendor.Male ? enGendor.Male : enGendor.Female;
            Address = dto.Address ?? string.Empty;
            Phone = dto.Phone ?? string.Empty;
            Email = dto.Email;
            NationalityCountryId = dto.NationalityCountryId;
            ImagePath = dto.ImagePath;

            Country = clsCountry.GetById(NationalityCountryId);
        }
        private PersonDto ToDto()
        {
            return new PersonDto
            {
                Id = Id,
                NationalNo = NationalNo,
                FirstName = FirstName,
                SecondName = SecondName,
                ThirdName = ThirdName,
                LastName = LastName,
                DateOfBirth = DateOfBirth,
                Gendor = Gendor == enGendor.Male ? PersonDto.enGendor.Male : PersonDto.enGendor.Female,
                Address = Address,
                Phone = Phone,
                Email = Email,
                NationalityCountryId = NationalityCountryId,
                ImagePath = ImagePath
            };
        }

        // Entity Management Methods
        protected override bool _Add()
        {
            Id = _repo.Add(ToDto());

            if (Id != -1)
            {
                Country = clsCountry.GetById(NationalityCountryId);
                return true;
            }
            return false;
        }

        protected override bool _Update() => _repo.Update(ToDto());

        public static bool Delete(int Id)
        {
            string ImagePath = _repo.GetById(Id).ImagePath;
            
            if (_repo.DeleteById(Id))
            {
                if (  !string.IsNullOrEmpty(ImagePath) )
                    File.Delete(ImagePath);
                return true;
            }

            return false;
                
                
            
        }
        
        public static bool IsExist(int Id) => _repo.IsExist(Id);

        public static clsPerson GetById(int Id)
        {
            var dto = _repo.GetById(Id);
            return dto != null ? new clsPerson(dto) : null;
        }

        public static clsPerson GetByNationalNo(string NationalNo)
        {
            var dto = _repo.GetByNationalNo(NationalNo);
            return dto != null ? new clsPerson(dto) : null;
        }

        public static DataTable GetAll() => _repo.GetAll();

        public static bool IsNationalNumberExist(string NationalNo)
            => _repo.IsNationalNoExist(NationalNo);
    }
}