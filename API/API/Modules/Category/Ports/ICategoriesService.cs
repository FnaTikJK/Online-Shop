using API.Infrastructure;
using API.Modules.Category.DTO;

namespace API.Modules.Category.Ports
{
    public interface ICategoriesService
    {
        public Task<Result<IEnumerable<CategoryDTO>>> GetAllAsync();
        public Task<Result<CategoryDTO>> GetByIdAsync(Guid id);
        public Task<Result<bool>> AddAsync(CategoryAddDTO categoryAddDto);
        public Task<Result<bool>> DeleteAsync(Guid id);
    }
}
