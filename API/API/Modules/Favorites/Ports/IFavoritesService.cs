using API.Infrastructure;
using API.Modules.Search.DTO;

namespace API.Modules.Favorites.Ports
{
    public interface IFavoritesService
    {
        public Result<IEnumerable<ProductShortDTO>> GetFavoriteProducts(Guid buyerId);
        public bool IsFavorited(Guid buyerId, Guid productId);
        public Task<Result<int>> AddFavoriteAsync(Guid buyerId, Guid productId);
        public Task<Result<int>> RemoveFavoriteAsync(Guid buyerId, Guid productId);
    }
}
