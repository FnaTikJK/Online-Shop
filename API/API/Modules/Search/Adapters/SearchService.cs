using API.Infrastructure;
using API.Modules.Category.Ports;
using API.Modules.Product.Ports;
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
        private readonly ICategoriesService categoriesService;
        private readonly IProductsService productsService;

        public SearchService(ISearchRepository searchRepository, IMapper mapper, 
            IProductsService productsService, ICategoriesService categoriesService)
        {
            this.searchRepository = searchRepository;
            this.mapper = mapper;
            this.productsService = productsService;
            this.categoriesService = categoriesService;
        }

        public async Task<Result<SearchResponse>> SearchAsync(SearchRequest request)
        {
            var result = await searchRepository.SearchInProducts(request);

            return Result.Ok(new SearchResponse()
            {
                Items = mapper.Map<IEnumerable<ProductShortDTO>>(result.items),
                PageNumber = request.pageNumber,
                PageSize = request.pageSize,
                TotalCount = result.totalCount
            });
        }

        public async Task<Result<FiltersDTO>> GetFilters()
        {
            var prices = productsService.GetPrices().Value;
            return Result.Ok(new FiltersDTO()
            {
                Categories = (await categoriesService.GetAllAsync()).Value,
                From = prices.from,
                To = prices.to,
            });
        }
    }
}
