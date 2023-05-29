using API.Modules.Account.Core;
using API.Modules.Basket.Core;
using API.Modules.Category.Core;
using API.Modules.Favorites.Core;
using API.Modules.Product.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace API.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        public void Init()
        {
            DataInitiator.InitDb(this);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>()
                .HasMany(e => e.Favorites)
                .WithMany(e => e.FavoritedBy)
                .UsingEntity<Favorite>();
        }

        public DbSet<Buyer> Buyers => Set<Buyer>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Favorite> Favorites => Set<Favorite>();
        public DbSet<BasketItem> BasketItems => Set<BasketItem>();
    }
}
