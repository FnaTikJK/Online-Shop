using API.Infrastructure;
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

        public async Task<Result<bool>> AddFavoriteAsync(Guid buyerId, Guid productId)
        {
            await favoriteRepository.AddFavoriteAsync(buyerId, productId);
            await favoriteRepository.SaveChangesAsync();
            return Result.Ok(true);
        }

        public async Task<Result<bool>> RemoveFavoriteAsync(Guid productId)
        {
            await favoriteRepository.RemoveFavoriteAsync(productId);
            await favoriteRepository.SaveChangesAsync();
            return Result.Ok(true);
        }
    }
}
