using Logins.Model;
using Logins.Model.DTO;

namespace Logins.ApiService.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResult<List<LookupDto>>> GetUserTypeList();
        Task<ServiceResult<List<LookupDto>>> GetUserPositionList();
        Task<ServiceResult<List<UserListDto>>> GetUsers();
        Task<ServiceResult<UpdateUserDto>> GetUserProfile(string id);
        Task<ServiceResult<CreateUserDto>> AddNewUser();
        Task<ServiceResult<bool>> CreateUser(CreateUserDto input);
        Task<ServiceResult<bool>> UpdateUser(UpdateUserDto input);
        Task<ServiceResult<bool>> DeleteUser(string id);
        Task<ServiceResult<bool>> ChangePassowrd(ChangePasswordDto password);

    }
}
