using API.Infrastructure;
using API.Modules.Basket.DTO;

namespace API.Modules.Basket.Ports
{
    public interface IBasketService
    {
        public Result<IEnumerable<BasketItemDTO>> GetBasket(Guid buyerId);
        public Result<int> GetBasketCount(Guid buyerId);
        public Task<Result<int>> UpdateOrAddItemAsync(Guid buyerId, BasketItemAddDTO addDto);
        public Task<Result<int>> RemoveByProductAndBuyerAsync(Guid buyerId, Guid productId);
    }
}
