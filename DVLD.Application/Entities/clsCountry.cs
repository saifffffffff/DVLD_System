using System;
using System.Data;
using DVLD_Data.Dtos;
using DVLD_Data.Interfaces;
using DVLD_Data.Repositries;

namespace DVLD_Application
{
    public class clsCountry : clsEntity
    {
        private static ICountryRepository _repo = new CountryRepository();

        // properites
        public int Id { get; private set; }
        public string Name { get; set; } = string.Empty;

        // constructors
        public clsCountry()
        {
            _Mode = enMode.Add;
        }
        private clsCountry(CountryDto dto) 
        {
            _LoadFromDto(dto);
            _Mode = enMode.Update;
        }


        private void _LoadFromDto(CountryDto dto)
        {
            if (dto == null) return;

            Id = dto.Id;
            Name = dto.Name ?? string.Empty;
        }
        private CountryDto _ToDto()
        {
            return new CountryDto
            {
                Id = Id,
                Name = Name
            };
        }


        // Entity Management Methods

        protected override bool _Add()
        {
            Id = _repo.Add(_ToDto());
            return Id != -1;
        }
        protected override bool _Update() => _repo.Update(_ToDto());

        public static bool Delete(int Id) => _repo.DeleteById(Id);

        public static DataTable GetAll() => _repo.GetAll();

        public static clsCountry GetById(int Id)
        {
            var dto = _repo.GetById(Id);
            return dto != null ? new clsCountry(dto) : null;
        }

        public static string GetCountryName(int Id) => _repo.GetCountryName(Id);

        public static int GetCountryId(string Name) => _repo.GetCountryId(Name);
    }
}