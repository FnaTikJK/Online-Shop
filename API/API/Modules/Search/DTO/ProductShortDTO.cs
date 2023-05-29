using API.Modules.Category.DTO;

namespace API.Modules.Search.DTO
{
    public class ProductShortDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public HashSet<CategoryShortDTO> Categories { get; set; }
        public byte[]? Image { get; set; }
        public bool IsFavorited { get; set; } = false;
        public int CountInBasket { get; set; } = 0;
    }
}
