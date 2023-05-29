using API.Infrastructure;
using API.Modules.Basket.Ports;
using API.Modules.Favorites.Ports;
using API.Modules.Product.DTO;
using API.Modules.Product.Ports;
using AutoMapper;

namespace API.Modules.Product.Adapters
{
    public class ProductsService : IProductsService
    {
        private readonly IMapper mapper;
        private readonly IProductsRepository productsRepository;
        private readonly IBasketService basketService;
        private readonly IFavoritesService favoritesService;

        public ProductsService(IMapper mapper, IProductsRepository productsRepository, IFavoritesService favoritesService,
            IBasketService basketService)
        {
            this.mapper = mapper;
            this.productsRepository = productsRepository;
            this.favoritesService = favoritesService;
            this.basketService = basketService;
        }

        public async Task<Result<IEnumerable<ProductDTO>>> GetAllAsync()
        {
            return Result.Ok(mapper.Map<IEnumerable<ProductDTO>>(await productsRepository.GetAllAsync()));
        }

        public Result<(double from, double to)> GetPrices()
        {
            var prices = productsRepository.GetPrices();

            return Result.Ok(prices);
        }

        public async Task<Result<ProductDTO>> GetByIdAsync(Guid id)
        {
            var existed = await productsRepository.GetByIdAsync(id);
            if (existed == null)
                return Result.Fail<ProductDTO>("Такого продукта не существует");

            return Result.Ok(mapper.Map<ProductDTO>(existed));
        }

        public async Task<Result<ProductDTO>> GetByIdWithInfoAsync(Guid buyerId, Guid productId)
        {
            var existed = await productsRepository.GetByIdAsync(productId);
            if (existed == null)
                return Result.Fail<ProductDTO>("Такого продукта не сущесвтует");

            var mapped = mapper.Map<ProductDTO>(existed);
            mapped.IsFavorited = favoritesService.IsFavorited(buyerId, productId);
            mapped.CountInBasket = basketService.GetCountInBasket(buyerId, productId);
            return Result.Ok(mapped);
        }

        public async Task<Result<bool>> AddAsync(ProductAddDTO productDto)
        {
            await productsRepository.AddAsync(mapper.Map<Core.Product>(productDto));

            return Result.Ok(true);
        }

        public async Task<Result<bool>> UpdateAsync(ProductDTO productDto)
        {
            var existed = productsRepository.GetByIdAsync(productDto.Id);
            if (existed == null)
                return Result.Fail<bool>("Такого продукта не сущесвтует");
            mapper.Map(productDto, existed);

            return Result.Ok(true);
        }

        public async Task<Result<bool>> DeleteAsync(Guid id)
        {
            await productsRepository.DeleteAsync(id);

            return Result.Ok(true);
        }
    }
}
