using Logins.Model;
using Logins.Model.DTO;

namespace Logins.ApiService.Interfaces
{
    public interface IUserService
    {

        Task<ServiceResult<List<UserListDto>>> GetUsers();
        Task<ServiceResult<UpdateUserDto>> GetUserProfile(string id);
        Task<ServiceResult<bool>> CreateUser(NewUserDto input);
        Task<ServiceResult<bool>> UpdateUser(UserDto input);
        Task<ServiceResult<bool>> DeleteUser(string id);
        Task<ServiceResult<bool>> ChangePassowrd(ChangePasswordDto password);

    }
}
