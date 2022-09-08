using Logins.Model;
using Logins.Model.DTO;

namespace Logins.ClientService.Interfaces
{
    public interface IUserClientService
    {
        List<LookupDto> UserTypeList { get; set; }
        List<LookupDto> PositionList { get; set; }

        Task GetUserType();
        Task GetPosition();

        Task<ServiceResult<List<UserListDto>>> GetUsers();
        Task<ServiceResult<UpdateUserDto>> GetUserProfile(string id);
        Task<ServiceResult<CreateUserDto>> AddNewUser();
        Task<ServiceResult<bool>> CreateUser(CreateUserDto input);
        Task<ServiceResult<bool>> UpdateUser(UpdateUserDto input);
        Task<ServiceResult<bool>> DeleteUser(string id);
        Task<ServiceResult<bool>> ChangePassowrd(ChangePasswordDto input);

    }
}
