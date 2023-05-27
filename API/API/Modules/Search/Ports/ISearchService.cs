using API.Infrastructure;
using API.Modules.Search.Core;

namespace API.Modules.Search.Ports
{
    public interface ISearchService
    {
        public Task<Result<SearchResponse>> SearchAsync(SearchRequest request);
    }
}
