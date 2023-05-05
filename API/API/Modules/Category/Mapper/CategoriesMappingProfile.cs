using API.Modules.Category.DTO;
using API.Modules.Category.Ports;
using AutoMapper;

namespace API.Modules.Category.Mapper
{
    public class CategoriesMappingProfile : AutoMapper.Profile
    {
        public CategoriesMappingProfile()
        {
            CreateMap<Core.Category, CategoryDTO>().ReverseMap();
            CreateMap<CategoryAddDTO, Core.Category>();
            CreateMap<Core.Category, CategoryShortDTO>();
        }
    }

    public class CategoriesMappingConverter 
        : IValueConverter<IEnumerable<Guid>, List<Core.Category>>
    {
        private readonly ICategoriesRepository categoriesRepository;

        public CategoriesMappingConverter(ICategoriesRepository categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public List<Core.Category> Convert(IEnumerable<Guid> sourceMember, ResolutionContext context)
        {
            return sourceMember
                .Select(id => categoriesRepository.GetByIdAsync(id).Result)
                .Where(x => x != null)
                .ToList();
        }
    }
}
