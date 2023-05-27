using API.DAL;
using API.Modules.Basket.Core;
using API.Modules.Basket.Ports;
using Microsoft.EntityFrameworkCore;

namespace API.Modules.Basket.Adapters
{
    public class BasketRepository : Repository<BasketItem>, IBasketRepository
    {
        public BasketRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public IEnumerable<BasketItem> GetAllByBuyer(Guid buyerId)
        {
            return Set
                .Include(e => e.Product)
                .Where(e => e.Buyer.Id == buyerId);
        }

        public async Task<BasketItem?> GetByBuyerAndProduct(Guid buyerId, Guid productId)
        {
            return await Set.FirstOrDefaultAsync(e => e.Buyer.Id == buyerId && e.Product.Id == productId);
        }

        public async Task AddAsync(BasketItem item)
        {
            var existed = await GetByBuyerAndProduct(item.Buyer.Id, item.Product.Id);

            if (existed == null)
            {
                await Set.AddAsync(item);
            }
        }

        public async Task RemoveByProductAndBuyerAsync(Guid buyerId, Guid productId)
        {
            var existed =
                await Set.Include(e => e.Product).FirstOrDefaultAsync(e => e.Product.Id == productId && e.Buyer.Id == buyerId);

            if (existed != null)
            {
                Set.Remove(existed);
            }
        }
    }
}
