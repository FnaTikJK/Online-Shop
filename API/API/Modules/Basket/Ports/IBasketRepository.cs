using API.Modules.Basket.Core;

namespace API.Modules.Basket.Ports
{
    public interface IBasketRepository
    {
        public IEnumerable<BasketItem> GetAllByBuyer(Guid buyerId);
        public Task<BasketItem?> GetByBuyerAndProduct(Guid buyerId, Guid productId);
        public Task AddAsync(BasketItem item);
        public Task RemoveByProductAndBuyerAsync(Guid buyerId, Guid productId);
        public Task SaveChangesAsync();
    }
}
