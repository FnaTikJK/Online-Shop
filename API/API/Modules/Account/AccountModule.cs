using API.Modules.Account.Adapters;
using API.Modules.Account.Mapper;
using API.Modules.Account.Ports;

namespace API.Modules.Account
{
    public class AccountModule : IModule
    {
        public IServiceCollection RegisterModule(IServiceCollection services)
        {
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddAutoMapper(typeof(UserMappingProfile));
            return services;
        }
    }
}
