using API.Infrastructure;
using API.Modules.Category.DTO;
using API.Modules.Category.Ports;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Modules.Category.Adapters
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository categoriesRepository;
        private readonly IMapper mapper;
        public CategoriesService(ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            this.categoriesRepository = categoriesRepository;
            this.mapper = mapper;
        }

        public async Task<Result<IEnumerable<CategoryDTO>>> GetAllAsync()
        {
            return Result.Ok(
                mapper.Map<IEnumerable<CategoryDTO>>(await categoriesRepository.GetAllAsync()));
        }

        public async Task<Result<CategoryDTO>> GetByIdAsync(Guid id)
        {
            var category = await categoriesRepository.GetByIdAsync(id);
            if (category == null)
                return Result.Fail<CategoryDTO>("Такой категории не существует");

            return Result.Ok(mapper.Map<CategoryDTO>(category));
        }

        public async Task<Result<bool>> AddAsync(CategoryAddDTO categoryAddDto)
        {
            await categoriesRepository.AddAsync(mapper.Map<Core.Category>(categoryAddDto));
            await categoriesRepository.SaveChangesAsync();
            return Result.Ok(true);
        }

        public async Task<Result<bool>> DeleteAsync(Guid id)
        {
            await categoriesRepository.DeleteAsync(id);
            await categoriesRepository.SaveChangesAsync();
            return Result.Ok(true);
        }
    }
}
