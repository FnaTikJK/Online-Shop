using API.Modules.Account.Core;
using Microsoft.EntityFrameworkCore;

namespace API.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            //Init();
        }

        private void Init()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Buyer> Buyers => Set<Buyer>();
    }
}
