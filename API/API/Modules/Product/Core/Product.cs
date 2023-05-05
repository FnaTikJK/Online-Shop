using API.DAL;
using API.Modules.Category.Core;

namespace API.Modules.Product.Core
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public HashSet<Category.Core.Category> Categories { get; set; }
        public byte[]? Image { get; set; }
    }
}
