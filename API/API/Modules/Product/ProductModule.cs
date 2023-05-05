using API.Modules.Product.Adapters;
using API.Modules.Product.Mapper;
using API.Modules.Product.Ports;

namespace API.Modules.Product
{
    public class ProductModule : IModule
    {
        public IServiceCollection RegisterModule(IServiceCollection services)
        {
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddAutoMapper(typeof(ProductMappingProfile));
            return services;
        }
    }
}
