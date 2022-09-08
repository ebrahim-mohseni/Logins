using Logins.ApiService.Services;
using Logins.ClientService.Interfaces;
using Logins.Helper;
using Logins.Model;
using Logins.Model.DTO;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Logins.ClientService.Services
{
    public class LoginClientService : HttpClientService, ILoginClientService
    {       
        public LoginClientService(HttpClient httpClient) : base(httpClient)
        {          
        }

        public string? Token { get; set; }

        public async Task<ServiceResult<string>> Login(LoginDto input)
        {
            var result = await ApiUrl.PostAsJsonAsync($"{BaseInfo.ServerApiUrl}api/Login", input);
            return JsonConvert.DeserializeObject<ServiceResult<string>>(result.Content.ReadAsStringAsync().Result);

        }
    }

}
