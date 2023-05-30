namespace API.Modules.Product.DTO
{
    public class ProductAddDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public HashSet<Guid> Categories { get; set; }
        public string? Image { get; set; }
    }
}
