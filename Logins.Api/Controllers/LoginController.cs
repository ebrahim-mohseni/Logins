using Logins.ApiService.Interfaces;
using Logins.Model.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Logins.Api.Controllers
{
    public class LoginController : BaseController<ILoginService>
    {
        public LoginController(ILoginService service) : base(service)
        {

        }

        [AllowAnonymous]
        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> Login(LoginDto input)
        {
            var result = await Service.Login(input);

            if (result.HasError)
                return NotFound(result);
            else
                return Ok(result);
        }


    }
}