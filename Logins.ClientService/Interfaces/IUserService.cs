using Logins.Model.DTO;

namespace Logins.ClientService.Interfaces
{
    public interface IUserService
    {
        List<UserListDto> Users { get; set; }
        UpdateUserDto UserProfile { get; set; }
        List<LookupDto> UserType { get; set; }
        List<LookupDto> Position { get; set; }

        Task GetUserType();
        Task GetPosition();

        Task GetUsers();
        Task GetUserProfile(int id);
        Task CreateUser(CreateUserDto input);
        Task UpdateUser(UpdateUserDto input);
        Task DeleteUser(int id);
        Task ChangePassword(ChangePasswordDto input);
        Task UnlockUser(int id);



    }
}
