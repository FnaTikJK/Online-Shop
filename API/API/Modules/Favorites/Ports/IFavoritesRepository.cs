namespace API.Modules.Favorites.Ports
{
    public interface IFavoritesRepository
    {
        public IEnumerable<Product.Core.Product> GetFavoriteProducts(Guid buyerId);
        public bool IsFavorited(Guid buyerId, Guid productId);
        public Task AddFavoriteAsync(Guid buyerId, Guid productId);
        public Task RemoveFavoriteAsync(Guid buyerId, Guid productId);
        public Task SaveChangesAsync();
    }
}
