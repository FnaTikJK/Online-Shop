using API.Modules.Basket.Adapters;
using API.Modules.Basket.Mapper;
using API.Modules.Basket.Ports;

namespace API.Modules.Basket
{
    public class BasketsModule : IModule
    {
        public IServiceCollection RegisterModule(IServiceCollection services)
        {
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddAutoMapper(typeof(BasketMappingProfile));

            return services;
        }
    }
}
