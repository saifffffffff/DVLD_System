using DVLD_Data.Dtos;


namespace DVLD_Data.Interfaces
{
    public interface IUserRepository : IGenericRepository<UserDto>
    {
        bool IsExist(string Username, string Password);
        bool IsExist(string Username);
        bool IsPersonLinkedToUser(int PersonId);
        UserDto GetByUsername(string Username);
        UserDto GetByUsernameAndPassword(string Username, string Password);
    }
}
