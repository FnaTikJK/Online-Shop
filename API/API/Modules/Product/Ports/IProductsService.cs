using API.Infrastructure;
using API.Modules.Product.DTO;

namespace API.Modules.Product.Ports
{
    public interface IProductsService
    {
        public Task<Result<IEnumerable<ProductDTO>>> GetAllAsync();
        public Task<Result<ProductDTO>> GetByIdAsync(Guid id);
        public Task<Result<bool>> AddAsync(ProductAddDTO productDto);
        public Task<Result<bool>> UpdateAsync(ProductDTO productDto);
        public Task<Result<bool>> DeleteAsync(Guid id);
    }
}
