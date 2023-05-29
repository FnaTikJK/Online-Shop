using API.Infrastructure;
using API.Modules.Search.Core;
using API.Modules.Search.DTO;

namespace API.Modules.Search.Ports
{
    public interface ISearchService
    {
        public Task<Result<SearchResponse>> SearchAsync(SearchRequest request);
        public Task<Result<FiltersDTO>> GetFilters();
    }
}
