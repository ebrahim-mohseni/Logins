using Logins.Model.DTO;

namespace Logins.ClientService.Interfaces
{
    public interface ILoginService
    {
        public string? Token { get; set; }

        Task Signin(LoginDto input);
    }
}
