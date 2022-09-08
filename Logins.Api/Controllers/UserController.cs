using Logins.ApiService.Interfaces;
using Logins.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Logins.Api.Controllers
{
    public class UserController : BaseController<IUserService>
    {
        public UserController(IUserService service) : base(service)
        {

        }


        [HttpGet]
        [ActionName("UserType")]
        public async Task<IActionResult> GetUserTypeList()
        {            
            var result = await Service.GetUserTypeList();
            if (result.HasError)
                return NotFound(result);
            else
                return Ok(result);
        }

        [HttpGet]
        [ActionName("UserPosition")]
        public async Task<IActionResult> GetUserPositionList()
        {
            var result = await Service.GetUserPositionList();
            if (result.HasError)
                return NotFound(result);
            else
                return Ok(result);
        }

        [HttpGet]
        [ActionName("Users")]
        public async Task<IActionResult> GetUserList()
        {
            var result = await Service.GetUsers();
            if (result.HasError)
                return NotFound(result);
            else
                return Ok(result);
        }

        [HttpGet]
        [ActionName("UsersProfile")]
        public async Task<IActionResult> GetUserProfile(string id)
        {
            var result = await Service.GetUserProfile(id);

            if (result.HasError)
                return NotFound(result);
            else
                return Ok(result);
        }

        [HttpGet]
        [ActionName("NewUser")]
        public async Task<IActionResult> AddNewUser()
        {
            var result = await Service.AddNewUser();
            if (result.HasError)
                return NotFound(result);
            else
                return Ok(result);
        }

        [HttpPost]
        [ActionName("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserDto input)
        {
            var result = await Service.CreateUser(input);
            if (result.HasError)
                return NotFound(result);
            else
                return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserDto input)
        {
            var result = await Service.UpdateUser(input);
            if (result.HasError)
                return NotFound(result);
            else
                return Ok(result);
        }


        [HttpGet]
        [ActionName("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await Service.DeleteUser(id);

            if (result.HasError)
                return NotFound(result);
            else
                return Ok(result);
        }

        [HttpPost]
        [ActionName("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto input)
        {
            var result = await Service.ChangePassowrd(input);
            if (result.HasError)
                return NotFound(result);
            else
                return Ok(result);
        }
    }
}
