using API.Modules.Favorites.Adapters;
using API.Modules.Favorites.Ports;

namespace API.Modules.Favorites
{
    public class FavoriteModule : IModule
    {
        public IServiceCollection RegisterModule(IServiceCollection services)
        {
            services.AddScoped<IFavoritesRepository, FavoritesRepository>();
            services.AddScoped<IFavoritesService, FavoritesService>();

            return services;
        }
    }
}
