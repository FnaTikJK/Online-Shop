using API.Modules.Category.Adapters;
using API.Modules.Category.Mapper;
using API.Modules.Category.Ports;

namespace API.Modules.Category
{
    public class CategoryModule : IModule
    {
        public IServiceCollection RegisterModule(IServiceCollection services)
        {
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddAutoMapper(typeof(CategoriesMappingProfile));
            return services;
        }
    }
}
