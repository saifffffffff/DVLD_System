
using DVLD_Data.Interfaces;
using DVLD_Data.Repositries;
using DVLD_Data.Dtos;
using System.Data;

namespace DVLD_Application.Entities
{
    public class clsUser : clsEntity
    {

        protected static IUserRepository _repo = new UserRepository();

        // properities
        public int Id { get; set; } = -1;
        public string Password { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
        public int PersonId { get; set; } = -1;
        public clsPerson Person { get; set; }
    
        // Constructors
        public clsUser()
        {
            _Mode = enMode.Add;
        }

        private clsUser(UserDto dto)
        {
            _FromDto(dto);
            _Mode = enMode.Update;
        }

        // methods
        protected override bool _Add() 
        {

            this.Id = _repo.Add(_ToDto());
            
            if (Id != -1)
            {
                this.Person = clsPerson.GetById(this.PersonId);
                return true;
            }

            return false;
            
        }
        
        protected override bool _Update() => _repo.Update(_ToDto());
        

        
        public static bool Delete (int Id) => _repo.DeleteById(Id);
        
        
        private UserDto _ToDto()
        {
            return new UserDto { Id = this.Id , Username = this.Username , IsActive = this.IsActive , Password = this.Password , PersonId = this.PersonId};
        }
        private  void _FromDto(UserDto userDto)
        {
            Id = userDto.Id;
            Username = userDto.Username;
            Password = userDto.Password;

            PersonId = userDto.PersonId;
            Person = clsPerson.GetById(PersonId);

            IsActive = userDto.IsActive;
        }
        
        public static DataTable GetAll() => _repo.GetAll();
        
        public static clsUser GetById(int Id)
        {
            var dto = _repo.GetById(Id);
            
            return dto == null ? null : new clsUser(dto);

        }
        public static clsUser GetByUsername(string Username) {
            var dto = _repo.GetByUsername(Username);
            if ( dto == null) return null;
            return new clsUser(dto);
        }
        public static clsUser GetByUsernameAndPassword(string Username , string Password)
        {
            var dto = _repo.GetByUsernameAndPassword(Username, Password);
            if ( dto == null) return null;
            return new clsUser(dto);
        }
        
        
        public static bool IsExist(string Username, string Password) => _repo.IsExist(Username, Password);
        
        
        public static bool IsExist(string Username) => _repo.IsExist(Username);
        
        public static bool IsUserExistForPersonId(int PersonId) => _repo.IsPersonLinkedToUser(PersonId);
    
    }
}
