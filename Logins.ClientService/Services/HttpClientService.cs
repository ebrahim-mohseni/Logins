namespace Logins.ApiService.Services
{
    public class HttpClientService
    {
        public HttpClient ApiUrl;
        public HttpClientService(HttpClient HttpClient)
        {
            ApiUrl = HttpClient;
        }
    }
}
