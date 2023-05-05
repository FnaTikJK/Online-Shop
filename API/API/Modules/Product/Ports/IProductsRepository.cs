namespace API.Modules.Product.Ports
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<Core.Product>> GetAllAsync();
        public Task<Core.Product?> GetByIdASync(Guid id);
        public Task AddAsync(Core.Product product);
        public Task DeleteAsync(Guid id);
        public Task SaveChangesAsync();
    }
}
