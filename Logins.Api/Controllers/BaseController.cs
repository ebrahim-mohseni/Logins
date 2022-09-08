using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logins.Api.Controllers
{
    //[Authorize]
    [Route("api/[action]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        public T Service;
        public BaseController(T service)
        {
            Service = service;
        }
    }
}
