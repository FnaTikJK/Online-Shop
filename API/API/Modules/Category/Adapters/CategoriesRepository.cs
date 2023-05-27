using Microsoft.EntityFrameworkCore;
using API.DAL;
using API.Modules.Category.Ports;

namespace API.Modules.Category.Adapters
{
    public class CategoriesRepository : Repository<Core.Category>, ICategoriesRepository
    {
        public CategoriesRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<IEnumerable<Core.Category>> GetAllAsync()
        {
            return await Set.ToListAsync();
        }

        public async Task<Core.Category?> GetByIdAsync(Guid id)
        {
            return await Set.FindAsync(id);
        }

        public async Task AddAsync(Core.Category category)
        {
            await Set.AddAsync(category);
        }

        public async Task DeleteAsync(Guid id)
        {
            var existed = await Set.FindAsync(id);
            if (existed != null) 
                Set.Remove(existed);
        }
    }
}
