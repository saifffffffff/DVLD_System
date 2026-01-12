

namespace DVLD_Data.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
                 
        public int PersonId { get; set;}
        
        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }
    }
}
