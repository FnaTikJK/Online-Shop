namespace API.Modules.Favorites.Ports
{
    public interface IFavoritesRepository
    {
        public IEnumerable<Product.Core.Product> GetFavoriteProducts(Guid buyerId);
        public Task AddFavoriteAsync(Guid buyerId, Guid productId);
        public Task RemoveFavoriteAsync(Guid productId);
        public Task SaveChangesAsync();
    }
}
