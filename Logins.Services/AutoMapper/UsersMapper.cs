using AutoMapper;
using Logins.Domain.Classes;
using Logins.Helper;
using Logins.Model.DTO;

namespace Logins.ApiService.AutoMapper
{
    public class UsersMapper : Profile
    {
        public UsersMapper()
        {
            CreateMap<Users, UserListDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => EncryptHelper.Encrypt(src.UserId.ToString())));                

            CreateMap<Users, UpdateUserDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => EncryptHelper.Encrypt(src.UserId.ToString())));

            CreateMap<NewUserDto, Users>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => Convert.ToInt32(EncryptHelper.Decrypt(src.Id))))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => EncryptHelper.PasswordHash(src.ConfirmPassword)))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.ToLower()));
                

            CreateMap<UserDto, Users>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => Convert.ToInt32(EncryptHelper.Decrypt(src.Id))));

            CreateMap<ChangePasswordDto, Users>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => Convert.ToInt32(EncryptHelper.Decrypt(src.Id))))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => EncryptHelper.PasswordHash(src.ConfirmPassword)));
        }
    }
}
