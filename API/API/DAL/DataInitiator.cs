using System.Data.Entity;
using API.Modules.Category.Core;
using API.Modules.Product.Core;

namespace API.DAL
{
    public class DataInitiator
    {
        public static void InitDb(DataContext dataContext)
        {
            dataContext.Database.EnsureDeleted();
            dataContext.Database.EnsureCreated();

            AddCategories(dataContext, 10);
            AddProducts(dataContext, 10);
            dataContext.SaveChanges();
        }

        private static void AddCategories(DataContext dataContext, int count)
        {
            for (int i = 0; i < count; i++)
            {
                dataContext.Categories.Add(Category.GetStandardCategory(i));
                dataContext.SaveChanges();
            }
        }

        private static void AddProducts(DataContext dataContext, int count)
        {
            for (int i = 0; i < count; i++)
            {
                AddStandardProduct(i, dataContext);
                dataContext.SaveChanges();
                
            }
        }

        private static void AddStandardProduct(int id, DataContext dataContext)
        {
            var rnd = new Random();
            var categories = dataContext.Categories.ToList();
            dataContext.Products.Add(new Product()
            {
                Id = new Guid(),
                Name = $"Product {id}",
                Description = $"Description of Product {id}",
                Price = new Random().Next(10, 1000),
                Categories = new[]
                {
                    categories[rnd.Next(categories.Count)],
                    categories[rnd.Next(categories.Count)]
                }.Distinct().ToHashSet(),
                Image = null
            });
            dataContext.SaveChanges();
        }
    }
}
