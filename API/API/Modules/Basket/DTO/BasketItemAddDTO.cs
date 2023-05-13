using API.Modules.Search.DTO;

namespace API.Modules.Basket.DTO
{
    public class BasketItemAddDTO
    {
        public Guid ProductId { get; set; }
        public int Count { get; set; }
    }
}
