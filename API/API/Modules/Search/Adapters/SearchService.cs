using API.Infrastructure;
using API.Modules.Search.Core;
using API.Modules.Search.DTO;
using API.Modules.Search.Ports;
using AutoMapper;

namespace API.Modules.Search.Adapters
{
    public class SearchService : ISearchService
    {
        private readonly IMapper mapper;
        private readonly ISearchRepository searchRepository;

        public SearchService(ISearchRepository searchRepository, IMapper mapper)
        {
            this.searchRepository = searchRepository;
            this.mapper = mapper;
        }

        public async Task<Result<SearchResponse>> SearchAsync(SearchRequest request)
        {
            var result = await searchRepository.SearchInProducts(request);

            return Result.Ok(new SearchResponse()
            {
                Items = mapper.Map<IEnumerable<ProductShortDTO>>(result.items),
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = result.totalCount
            });
        }
    }
}
