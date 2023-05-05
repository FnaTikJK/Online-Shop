using API.Modules.Account.Core;
using API.Modules.Category.Core;
using API.Modules.Product.Core;
using Microsoft.EntityFrameworkCore;

namespace API.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            //DataInitiator.InitDb(this);
        }

        public DbSet<Buyer> Buyers => Set<Buyer>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
    }
}
