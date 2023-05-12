using API.DAL;
using API.Modules.Product.Ports;
using Microsoft.EntityFrameworkCore;

namespace API.Modules.Product.Adapters
{
    public class ProductsRepository : Repository<Core.Product>, IProductsRepository
    {
        public ProductsRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<IEnumerable<Core.Product>> GetAllAsync()
        {
            return await Set.Include(e => e.Categories).ToListAsync();
        }

        public async Task<Core.Product?> GetByIdAsync(Guid id)
        {
            return await Set.Include(e => e.Categories).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(Core.Product product)
        {
            await Set.AddAsync(product);
        }

        public async Task DeleteAsync(Guid id)
        {
            var existed = await Set.FindAsync(id);
            if (existed != null)
                Set.Remove(existed);
        }
    }
}
