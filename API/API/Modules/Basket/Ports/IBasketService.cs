using API.Infrastructure;
using API.Modules.Basket.DTO;

namespace API.Modules.Basket.Ports
{
    public interface IBasketService
    {
        public Result<IEnumerable<BasketItemDTO>> GetBasket(Guid buyerId);
        public Task<Result<bool>> UpdateOrAddItemAsync(Guid buyerId, BasketItemAddDTO addDto);
        public Task<Result<bool>> RemoveByProductAndBuyerAsync(Guid buyerId, Guid productId);
    }
}
