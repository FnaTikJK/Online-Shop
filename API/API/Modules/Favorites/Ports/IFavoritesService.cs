using API.Infrastructure;
using API.Modules.Search.DTO;

namespace API.Modules.Favorites.Ports
{
    public interface IFavoritesService
    {
        public Result<IEnumerable<ProductShortDTO>> GetFavoriteProducts(Guid buyerId);
        public Task<Result<bool>> AddFavoriteAsync(Guid buyerId, Guid productId);
        public Task<Result<bool>> RemoveFavoriteAsync(Guid productId);
    }
}
