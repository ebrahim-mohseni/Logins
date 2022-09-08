using AutoMapper;
using Logins.ApiService.Interfaces;
using Logins.ApiService.Models;
using Logins.ApiService.Properties;
using Logins.Data;
using Logins.Domain.Classes;
using Logins.Helper;
using Logins.Model;
using Logins.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace Logins.ApiService.Services
{
    public class LoginService : DataService, ILoginService
    {
        private readonly IMapper _mapper;

        public LoginService(IMapper mapper, DataContext contex) : base(contex)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResult<string>> Login(LoginDto input)
        {
            var output = new ServiceResult<string>();
            try
            {
                var login = _mapper.Map<Login>(input);
                Users? user =
                    await Context.Users.Where(p => p.Email == login.Email && p.Password == login.Password).FirstOrDefaultAsync();

                if (user == null)
                {
                    output.SetDebug("Login", Resources.InvalidLoginMessage, $"LoginModel: {input}");
                }
                else
                {
                    output.Data = GlobalExtensions.CreateJWTToken(user.UserId, input.Email);
                    output.SeInformation("Login");
                }
            }
            catch (Exception ex)
            {
                output.SetException(ex, "Login");
            }

            return output;
        }
    }

}
