using Logins.ApiService.Services;
using Logins.ClientService.Interfaces;
using Logins.Helper;
using Logins.Model;
using Logins.Model.DTO;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Logins.ClientService.Services
{
    public class UserClientService : HttpClientService, IUserClientService
    {
        public List<LookupDto> UserTypeList { get; set; } = new List<LookupDto>();
        public List<LookupDto> PositionList { get; set; } = new List<LookupDto>();
        public UserClientService(HttpClient httpClient) : base(httpClient)
        {     
        }
        public async Task GetUserType()
        {
            var result = await ApiUrl.GetFromJsonAsync<ServiceResult<List<LookupDto>>>($"{BaseInfo.ServerApiUrl}api/UserType");
            UserTypeList = result.Data;
        }

        public async Task GetPosition()
        {
            var result = await ApiUrl.GetFromJsonAsync<ServiceResult<List<LookupDto>>>($"{BaseInfo.ServerApiUrl}api/UserPosition");
            PositionList = result.Data;
        }

        public async Task<ServiceResult<List<UserListDto>>> GetUsers()
        {
            var result = await ApiUrl.GetFromJsonAsync<ServiceResult<List<UserListDto>>>($"{BaseInfo.ServerApiUrl}api/users");
            return result;
        }

        public async Task<ServiceResult<UpdateUserDto>> GetUserProfile(string id)
        {
            var result = await ApiUrl.GetFromJsonAsync<ServiceResult<UpdateUserDto>>($"{BaseInfo.ServerApiUrl}api/UsersProfile?id={id}");
            return result;
        }

        public async Task<ServiceResult<CreateUserDto>> AddNewUser()
        {
            var result = await ApiUrl.GetFromJsonAsync<ServiceResult<CreateUserDto>>($"{BaseInfo.ServerApiUrl}api/NewUser");
            return result;
        }

        public async Task<ServiceResult<bool>> CreateUser(CreateUserDto input)
        {
            var result = await ApiUrl.PostAsJsonAsync($"{BaseInfo.ServerApiUrl}api/CreateUser", input);
            return JsonConvert.DeserializeObject<ServiceResult<bool>>(result.Content.ReadAsStringAsync().Result);
        }

        public async Task<ServiceResult<bool>> UpdateUser(UpdateUserDto input)
        {
            var result = await ApiUrl.PostAsJsonAsync($"{BaseInfo.ServerApiUrl}api/UpdateUser", input);
            return JsonConvert.DeserializeObject<ServiceResult<bool>>(result.Content.ReadAsStringAsync().Result);
        }

        public async Task<ServiceResult<bool>> DeleteUser(string id)
        {
            var result = await ApiUrl.GetFromJsonAsync<ServiceResult<bool>>($"{BaseInfo.ServerApiUrl}api/DeleteUser?id={id}");
            return result;
        }

        public async Task<ServiceResult<bool>> ChangePassowrd(ChangePasswordDto input)
        {
            var result = await ApiUrl.PostAsJsonAsync($"{BaseInfo.ServerApiUrl}api/ChangePassword", input);
            return JsonConvert.DeserializeObject<ServiceResult<bool>>(result.Content.ReadAsStringAsync().Result);
        }
    }

}
