using API.Modules.Category.DTO;

namespace API.Modules.Category.Mapper
{
    public class CategoriesMappingProfile : AutoMapper.Profile
    {
        public CategoriesMappingProfile()
        {
            CreateMap<Core.Category, CategoryDTO>().ReverseMap();
            CreateMap<CategoryAddDTO, Core.Category>();
        }
    }
}
