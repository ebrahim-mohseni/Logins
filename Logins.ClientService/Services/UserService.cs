using Logins.ClientService.Interfaces;
using Logins.Model.DTO;
using System.Net.Http.Json;

namespace Logins.ClientService.Services
{
    public class UserService : IUserService
    {
        private enum EnumLookupItems
        {
            UserType = 1,
            Position = 3
        }
        private readonly HttpClient _http;
        //private readonly NavigationManager _navigationManager;

        public List<UserListDto> Users { get; set; } = new List<UserListDto>();
        public UpdateUserDto UserProfile { get; set; } = new UpdateUserDto();

        public List<LookupDto> UserType { get; set; } = new List<LookupDto>();
        public List<LookupDto> Position { get; set; } = new List<LookupDto>();

        public UserService(HttpClient http
            //,NavigationManager navigationManager
            )
        {

            _http = http;
            //_navigationManager = navigationManager;
        }


        public async Task GetUserType()
        {
            var result = await _http.GetFromJsonAsync<List<LookupDto>>($"api/lookupitems?id={(int)EnumLookupItems.UserType}");
            if (result != null)
                UserType = result;
        }

        public async Task GetPosition()
        {
            var result = await _http.GetFromJsonAsync<List<LookupDto>>($"api/lookupitems?id={(int)EnumLookupItems.Position}");
            if (result != null)
                Position = result;
        }

        public async Task GetUsers()
        {
            var result = await _http.GetFromJsonAsync<List<UserListDto>>("api/users");
            if (result != null)
                Users = result;
        }

        public async Task GetUserProfile(int id)
        {

            var result = await _http.GetFromJsonAsync<UpdateUserDto>($"api/UserProfile?id={id}");
            if (result != null)
                UserProfile = result;
            else
                throw new InvalidOperationException("the is an error");
        }

        public async Task CreateUser(CreateUserDto input)
        {
            var result = await _http.PostAsJsonAsync("api/CreateUser", input);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
               throw new InvalidOperationException("the is an error"); //_navigationManager.NavigateTo("Users");
            else if (result.StatusCode == System.Net.HttpStatusCode.NotFound || result.StatusCode == System.Net.HttpStatusCode.BadRequest)
                throw new InvalidOperationException("the is an error");
        }

        public async Task UpdateUser(UpdateUserDto input)
        {
            var result = await _http.PostAsJsonAsync("api/UpdateUser", input);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
               throw new InvalidOperationException("the is an error"); //_navigationManager.NavigateTo("Users");
            else if (result.StatusCode == System.Net.HttpStatusCode.NotFound || result.StatusCode == System.Net.HttpStatusCode.BadRequest)
                throw new InvalidOperationException("the is an error");
        }

        public async Task DeleteUser(int id)
        {
            var result = await _http.GetAsync($"api/DeleteUser?id={id}");
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
               throw new InvalidOperationException("the is an error"); //_navigationManager.NavigateTo("Users");
        }

        public async Task ChangePassword(ChangePasswordDto input)
        {
            var result = await _http.PostAsJsonAsync($"api/ChangePassword", input);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
               throw new InvalidOperationException("the is an error"); //_navigationManager.NavigateTo("Users");
        }

        public async Task UnlockUser(int id)
        {
            var result = await _http.GetAsync($"api/UnlockUser?id={id}");
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
               throw new InvalidOperationException("the is an error"); //_navigationManager.NavigateTo("Users");
        }
    }

}
