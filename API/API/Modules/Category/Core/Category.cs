namespace API.Modules.Category.Core
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[]? Image { get; set; }

        public List<Product.Core.Product> Products { get; set; }
    }
}
