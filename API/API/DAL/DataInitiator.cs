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

            AddNormalRecords(dataContext);
            //AddCategories(dataContext, 50);
            //AddProducts(dataContext, 25);
            dataContext.SaveChanges();
        }

        private static void AddNormalRecords(DataContext dataContext)
        {
            var categories = new Category[]
            {
                new Category() {Name = "Мужчины", Description = ""},
                new Category() {Name = "Женщины", Description = ""},
                new Category() {Name = "Дети", Description = ""},
                new Category() {Name = "Спорт", Description = ""},
                new Category() {Name = "Одежда", Description = ""},
                new Category() {Name = "Развлечение", Description = ""},
                new Category() {Name = "Электроника", Description = ""},
                new Category() {Name = "Мебель", Description = ""},
            };
            dataContext.Categories.AddRange(categories);
            dataContext.SaveChanges();

            var rnd = new Random();
            //categories = dataContext.Categories.ToArray();
            var products = new Product[]
            {
                new Product() {Name = "Кроссовки мужские Nike Air Zoom Pegasus 37", Description = "Кроссовки мужские для бега", Price = rnd.Next(100,10000), Image = "https://cdn.sportmaster.ru/upload/resize_cache/iblock/85c/800_800_1/76745360299.jpg"},
                new Product() {Name = "Кроссовки женские Nike Downshifter 11", Description = "Кроссовки женские для бега", Price = rnd.Next(100,10000), Image = "https://cdn.sportmaster.ru/upload/resize_cache/iblock/2d2/800_800_1/58340730299.jpg"},
                new Product() {Name = "Кроссовки для мальчиков Nike Air Max Motion 2 Mc", Description = "Кроссовки детские, мужские для бега", Price = rnd.Next(100,10000), Image = "https://cdn.sportmaster.ru/upload/resize_cache/iblock/19b/800_800_1/80337710299.jpg"},
                new Product() {Name = "Кроссовки для девочек Nike Downshifter 11 Gs", Description = "Кроссовки детские, женские для бега", Price = rnd.Next(100,10000), Image = "https://cdn.sportmaster.ru/upload/resize_cache/iblock/a14/800_800_1/74399210299.jpg"},
                new Product() {Name = "Носки Nike Multiplier", Description = "Носки универсальные Nike", Price = rnd.Next(100,10000), Image = "https://cdn.sportmaster.ru/upload/resize_cache/iblock/20e/800_800_1/53973710299.jpg"},
                new Product() {Name = "АК-47 Автомат Калашникова Игрушечный детский", Description = "АК-47 Автомат Калашникова Игрушечный детский оружие с пульками", Price = rnd.Next(100,10000), Image = "https://ir.ozone.ru/s3/multimedia-9/wc700/6632780517.jpg"},
                new Product() {Name = "Игрушечная фигурка L.O.L", Description = "Коллекционная игрушечная фигурка L.O.L", Price = rnd.Next(100,10000), Image = "https://ir.ozone.ru/s3/multimedia-u/wc700/6586180554.jpg"},
                new Product() {Name = "Ноутбук Huawei MateBook", Description = "Ноутбук Huawei MateBook D 15 BOD-WDI9, 15.6\", IPS, Intel Core i3 1115G4 3ГГц, 2-ядерный, 8ГБ DDR4, 256ГБ SSD, Intel UHD Graphics , без операционной системы, серый космос [53013sdv]", Price = rnd.Next(10000,100000), Image = "https://cdn.citilink.ru/XnMTn15mQg4MFAzMUmw1s4c4rEY7nmLQAh1jOxsyCD8/resizing_type:fit/gravity:sm/width:1200/height:1200/plain/items/1926552_v01_b.jpg"},
                new Product() {Name = "Смартфон Samsung Galaxy A14", Description = "Смартфон Samsung Galaxy A14 4/128Gb, SM-A145, светло-зеленый", Price = rnd.Next(10000,20000), Image = "https://cdn.citilink.ru/nRucWb-f6OBsvuyBWgsyuLdrBTm-o6UVQwSarDoHyLk/resizing_type:fit/gravity:sm/width:1200/height:1200/plain/items/1911787_v01_b.jpg"},
                new Product() {Name = "Игровое компьютерное кресло Mega", Description = "Игровое компьютерное кресло, Детское компьютерное кресло Mega мебель 212f, Серый\r\n", Price = rnd.Next(10000,20000), Image = "https://ir.ozone.ru/s3/multimedia-4/wc700/6620231200.jpg"},
                new Product() {Name = "Шкаф-купе", Description = "Шкаф-купе (1200), 120х60х220 см, МАЛЬТА", Price = rnd.Next(1000,10000), Image = "https://ir.ozone.ru/s3/multimedia-d/wc700/6562940653.jpg"},
                new Product() {Name = "Игрушка говорящий хомяк", Description = "Интерактивная игрушка говорящий хомяк (повторюшка) серый", Price = rnd.Next(100,1000), Image = "https://ir.ozone.ru/s3/multimedia-j/wc700/6280466587.jpg"},
            };
            products[0].Categories = new HashSet<Category>() {categories[0], categories[3], categories[4] };
            products[1].Categories = new HashSet<Category>() { categories[1], categories[3], categories[4] };
            products[2].Categories = new HashSet<Category>() {categories[0], categories[2], categories[4]};
            products[3].Categories = new HashSet<Category>() {categories[1], categories[2], categories[4]};
            products[4].Categories = new HashSet<Category>() {categories[0], categories[1], categories[4]};
            products[5].Categories = new HashSet<Category>() {categories[0], categories[2], categories[5]};
            products[6].Categories = new HashSet<Category>() {categories[1], categories[2], categories[5]};
            products[7].Categories = new HashSet<Category>() {categories[5], categories[6]};
            products[8].Categories = new HashSet<Category>() {categories[5], categories[6]};
            products[9].Categories = new HashSet<Category>() { categories[5], categories[7]};
            products[10].Categories = new HashSet<Category>() {categories[7]};
            products[11].Categories = new HashSet<Category>() {categories[2], categories[5], categories[6]};
            dataContext.Products.AddRange(products);
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
