using API.Infrastructure;
using API.Modules.Account.Core;
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

        public FavoritesService(IMapper mapper, IFavoritesRepository favoriteRepository)
        {
            this.mapper = mapper;
            this.favoriteRepository = favoriteRepository;
        }

        public Result<IEnumerable<ProductShortDTO>> GetFavoriteProducts(Guid buyerId)
        {
            var products = favoriteRepository.GetFavoriteProducts(buyerId);
            return Result.Ok(mapper.Map<IEnumerable<ProductShortDTO>>(products));
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
