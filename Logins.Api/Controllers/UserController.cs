using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Logins.Api.Controllers
{
    [Authorize]
    [Route("api/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController()
        {

        }
    }
}
