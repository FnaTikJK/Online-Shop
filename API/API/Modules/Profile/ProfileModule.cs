using API.Modules.Profile.Adapters;
using API.Modules.Profile.Mapper;
using API.Modules.Profile.Ports;

namespace API.Modules.Profile
{
    public class ProfileModule : IModule
    {
        public IServiceCollection RegisterModule(IServiceCollection services)
        {
            services.AddScoped<IProfilesRepository, ProfilesRepository>();
            services.AddScoped<IProfilesService, ProfilesService>();
            services.AddAutoMapper(typeof(ProfileMappingProfile));
            return services;
        }
    }
}
