using API.Modules.Category.DTO;

namespace API.Modules.Product.DTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public HashSet<CategoryShortDTO> Categories { get; set; }
        public byte[]? Image { get; set; }
    }
}
