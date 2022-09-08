using Logins.Model;
using Logins.Model.DTO;

namespace Logins.ClientService.Interfaces
{
    public interface ILoginClientService
    {
        Task<ServiceResult<string>> Login(LoginDto input);
    }
}
