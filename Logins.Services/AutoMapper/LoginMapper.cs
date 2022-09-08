using AutoMapper;
using Logins.ApiService.Models;
using Logins.Helper;
using Logins.Model.DTO;

namespace Logins.ApiService.AutoMapper
{
    public class LoginMapper : Profile
    {
        public LoginMapper()
        {
            CreateMap<LoginDto, Login>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => EncryptHelper.PasswordHash(src.Password)));

        }
    }
}
