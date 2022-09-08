using Logins.ClientService.Interfaces;
using Logins.Model.DTO;
using System.Net.Http.Json;

namespace Logins.ClientService.Services
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _http;

        public LoginService(HttpClient http)
        {
            _http = http;
        }

        public string? Token { get; set; }

        public async Task Signin(LoginDto input)
        {
            var result = await _http.PostAsJsonAsync($"api/Login", input);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                Token = result.Content.ReadAsStringAsync().Result;
        }
    }

}
