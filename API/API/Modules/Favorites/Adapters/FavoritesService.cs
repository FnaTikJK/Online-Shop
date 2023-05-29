using API.Infrastructure;
using API.Modules.Account.Core;
using API.Modules.Basket.Ports;
using API.Modules.Favorites.Ports;
using API.Modules.Search.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Modules.Favorites.Adapters
{
    public class FavoritesService : IFavoritesService
    {
        private readonly IFavoritesRepository favoriteRepository;
        private readonly IMapper mapper;
        private readonly IBasketService basketService;

        public FavoritesService(IMapper mapper, IFavoritesRepository favoriteRepository, IBasketService basketService)
        {
            this.mapper = mapper;
            this.favoriteRepository = favoriteRepository;
            this.basketService = basketService;
        }

        public Result<IEnumerable<ProductShortDTO>> GetFavoriteProducts(Guid buyerId)
        {
            var products = favoriteRepository.GetFavoriteProducts(buyerId);
            var items = mapper.Map<IEnumerable<ProductShortDTO>>(products);
            foreach (var item in items)
            {
                item.IsFavorited = true;
                item.CountInBasket = basketService.GetCountInBasket(buyerId, item.Id);
            }
            return Result.Ok(items);
        }

        public bool IsFavorited(Guid buyerId, Guid productId)
        {
            return favoriteRepository.IsFavorited(buyerId, productId);
        }

        public async Task<Result<int>> AddFavoriteAsync(Guid buyerId, Guid productId)
        {
            await favoriteRepository.AddFavoriteAsync(buyerId, productId);
            await favoriteRepository.SaveChangesAsync();
            var count = favoriteRepository.GetFavoriteProducts(buyerId).Count();
            return Result.Ok(count);
        }

        public async Task<Result<int>> RemoveFavoriteAsync(Guid buyerId, Guid productId)
        {
            await favoriteRepository.RemoveFavoriteAsync(buyerId, productId);
            await favoriteRepository.SaveChangesAsync();
            var count = favoriteRepository.GetFavoriteProducts(buyerId).Count();
            return Result.Ok(count);
        }
    }
}
