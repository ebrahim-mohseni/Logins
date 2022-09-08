using AutoMapper;

namespace Logins.ApiService.AutoMapper
{
    public class Configuration : Profile
    {
        public Configuration()
        {
            MapperConfiguration config = new(cfg =>
            {
                cfg.AddProfile<LoginMapper>();
                cfg.AddProfile<UsersMapper>();
            });

        }
    }
}
