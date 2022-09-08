using Logins.Model;
using Logins.Model.DTO;
using System.Threading.Tasks;

namespace Logins.ApiService.Interfaces
{
    public interface ILoginService
    {
        Task<ServiceResult<string>> Login(LoginDto input);
    }
}
