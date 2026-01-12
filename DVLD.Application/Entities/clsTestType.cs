using System.Data;
using DVLD_Data.Dtos;
using DVLD_Data.Interfaces;
using DVLD_Data.Repositries;

namespace DVLD_Application.Entities
{
    public class clsTestType : clsEntity
    {
        private static ITestTypeRepository _repo = new TestTypeRepository();

        // Properties
        public int Id { get; private set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Fees { get; set; }

        public enum enTestTypes { VisionTest = 1 , WrittenTest = 2 , PracticalTest = 3 }

        // constructors
        public clsTestType()
        {
            _Mode = enMode.Update;
        }

        private clsTestType(TestTypeDto dto) : this()
        {
            LoadFromDto(dto);
            _Mode = enMode.Update;
        }

        private void LoadFromDto(TestTypeDto dto)
        {
            if (dto == null) return;

            Id = dto.Id;
            Title = dto.Title ?? string.Empty;
            Description = dto.Description ?? string.Empty;
            Fees = dto.Fees;
        }

        private TestTypeDto ToDto()
        {
            return new TestTypeDto
            {
                Id = Id,
                Title = Title,
                Description = Description,
                Fees = Fees
            };
        }

        // Entity Management Methods

        // Usually test types are not added through the application (predefined data)
        // So _Add() returns false or throws — keeping it disabled as in your original
        protected override bool _Add() => false;

        protected override bool _Update() => _repo.Update(ToDto());

        public static DataTable GetAll() => _repo.GetAll();

        public static clsTestType GetById(int Id)
        {
            var dto = _repo.GetById(Id);
            return dto != null ? new clsTestType(dto) : null;
        }
    }
}