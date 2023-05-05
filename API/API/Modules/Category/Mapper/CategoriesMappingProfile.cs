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
        : IValueConverter<IEnumerable<Guid>, HashSet<Core.Category>>
    {
        private readonly ICategoriesRepository categoriesRepository;

        public CategoriesMappingConverter(ICategoriesRepository categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public HashSet<Core.Category> Convert(IEnumerable<Guid> sourceMember, ResolutionContext context)
        {
            return sourceMember
                .Select(id => categoriesRepository.GetByIdAsync(id).Result)
                .Where(x => x != null)
                .ToHashSet();
        }
    }
}
