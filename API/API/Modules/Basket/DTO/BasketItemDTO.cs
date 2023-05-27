using API.Modules.Account.Core;
using API.Modules.Search.DTO;

namespace API.Modules.Basket.DTO
{
    public class BasketItemDTO
    {
        public ProductShortDTO Product { get; set; }
        public int Count { get; set; }
    }
}
