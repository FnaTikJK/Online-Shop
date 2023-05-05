using API.Modules.Search.Adapters;
using API.Modules.Search.Mapper;
using API.Modules.Search.Ports;

namespace API.Modules.Search
{
    public class SearchModule : IModule
    {
        public IServiceCollection RegisterModule(IServiceCollection services)
        {
            services.AddScoped<ISearchRepository, SearchRepository>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddAutoMapper(typeof(SearchMappingProfile));
            return services;
        }
    }
}
