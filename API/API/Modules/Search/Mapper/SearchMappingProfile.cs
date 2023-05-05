using API.Modules.Search.DTO;

namespace API.Modules.Search.Mapper
{
    public class SearchMappingProfile : AutoMapper.Profile
    {
        public SearchMappingProfile()
        {
            CreateMap<Product.Core.Product, ProductShortDTO>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories));
        }
    }
}
