using API.DAL;
using API.Modules.Account.Ports;
using API.Modules.Favorites.Core;
using API.Modules.Favorites.Ports;
using API.Modules.Product.Ports;
using Microsoft.EntityFrameworkCore;

namespace API.Modules.Favorites.Adapters
{
    public class FavoritesRepository : Repository<Favorite>, IFavoritesRepository
    {
        private readonly IProductsRepository productRepository;
        private readonly IUsersRepository userRepository;

        public FavoritesRepository(DataContext dataContext, IUsersRepository userRepository, IProductsRepository productRepository) 
            : base(dataContext)
        {
            this.userRepository = userRepository;
            this.productRepository = productRepository;
        }

        public IEnumerable<Product.Core.Product> GetFavoriteProducts(Guid buyerId)
        {
            return Set
                .Include(e => e.Product)
                .ThenInclude(p => p.Categories)
                .Where(e => e.Buyer.Id == buyerId)
                .Select(e => e.Product);
        }

        public async Task AddFavoriteAsync(Guid buyerId, Guid productId)
        {
            var buyer = await userRepository.GetBuyerByIdAsync(buyerId);
            var product = await productRepository.GetByIdAsync(productId);

            if (product != null && buyer != null
                && await Set.FirstOrDefaultAsync(e => e.Buyer.Id == buyerId && e.Product.Id == productId) == null)
            {
                await Set.AddAsync(new Favorite() { Buyer = buyer, Product = product });
            }
        }

        public async Task RemoveFavoriteAsync(Guid productId)
        {
            var favorite = await Set.FirstOrDefaultAsync(e => e.Product.Id == productId);

            if (favorite != null)
                Set.Remove(favorite);
        }
    }
}
