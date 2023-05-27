namespace API.Modules.Category.Ports
{
    public interface ICategoriesRepository
    {
        public Task<IEnumerable<Core.Category>> GetAllAsync();
        public Task<Core.Category?> GetByIdAsync(Guid id);
        public Task AddAsync(Core.Category  category);
        public Task DeleteAsync(Guid id);
        public Task SaveChangesAsync();
    }
}
