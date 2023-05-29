using API.Infrastructure;
using API.Modules.Basket.Ports;
using API.Modules.Category.Ports;
using API.Modules.Favorites.Ports;
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
        private readonly IBasketService basketService;
        private readonly IFavoritesService favoritesService;

        public SearchService(ISearchRepository searchRepository, IMapper mapper, 
            IProductsService productsService, ICategoriesService categoriesService, 
            IFavoritesService favoritesService, IBasketService basketService)
        {
            this.searchRepository = searchRepository;
            this.mapper = mapper;
            this.productsService = productsService;
            this.categoriesService = categoriesService;
            this.favoritesService = favoritesService;
            this.basketService = basketService;
        }

        public async Task<Result<SearchResponse>> SearchAsync(SearchRequest request)
        {
            var result = await searchRepository.SearchInProducts(request);

            return Result.Ok(new SearchResponse()
            {
                Items = mapper.Map<IEnumerable<ProductShortDTO>>(result.items),
                PageNumber = request.pageNumber,
                PageSize = request.pageSize,
                TotalPageCount = result.totalCount
            });
        }

        public async Task<Result<SearchResponse>> SearchAuthAsync(Guid buyerId, SearchRequest request)
        {
            var searchResult = await searchRepository.SearchInProducts(request);

            var items = mapper.Map<IEnumerable<ProductShortDTO>>(searchResult.items);
            foreach (var item in items)
            {
                item.IsFavorited = favoritesService.IsFavorited(buyerId, item.Id);
                item.CountInBasket = basketService.GetCountInBasket(buyerId, item.Id);
            }

            return Result.Ok(new SearchResponse()
            {
                Items = items,
                PageNumber = request.pageNumber,
                PageSize = request.pageSize,
                TotalPageCount = searchResult.totalCount,
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
