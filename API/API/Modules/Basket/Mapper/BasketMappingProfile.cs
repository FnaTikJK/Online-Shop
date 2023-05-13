using API.Modules.Basket.Core;
using API.Modules.Basket.DTO;
using API.Modules.Product.Mapper;

namespace API.Modules.Basket.Mapper
{
    public class BasketMappingProfile : AutoMapper.Profile
    {
        public BasketMappingProfile()
        {
            CreateMap<BasketItemAddDTO, BasketItem>()
                .ForMember(dest => dest.Product,
                    opt => opt.ConvertUsing<ProductMappingConverter, Guid>(src => src.ProductId));
            CreateMap<BasketItem, BasketItemDTO>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product));
        }
    }
}
