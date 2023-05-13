using API.Modules.Account.Core;

namespace API.Modules.Basket.Core
{
    public class BasketItem
    {
        public Guid Id { get; set; }
        public Buyer Buyer { get; set; }
        public Product.Core.Product Product { get; set; }
        public int Count { get; set; }
    }
}
