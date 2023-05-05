using System.Collections;
using API.Modules.Category.Mapper;
using API.Modules.Product.DTO;

namespace API.Modules.Product.Mapper
{
    public class ProductMappingProfile : AutoMapper.Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductAddDTO, Core.Product>()
                .ForMember(dest => dest.Categories, opt => 
                    opt.ConvertUsing<CategoriesMappingConverter, IEnumerable<Guid>>(src => src.Categories));
            CreateMap<Core.Product, ProductDTO>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories));
        }
    }
}
