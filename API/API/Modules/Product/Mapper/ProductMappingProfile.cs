using API.Modules.Category.Mapper;
using API.Modules.Product.DTO;
using API.Modules.Product.Ports;
using AutoMapper;

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

    public class ProductMappingConverter : IValueConverter<Guid, Core.Product>
    {
        private readonly IProductsRepository productsRepository;

        public ProductMappingConverter(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public Core.Product Convert(Guid sourceMember, ResolutionContext context)
        {
            var task = productsRepository.GetByIdAsync(sourceMember);
            task.Wait();
            return task.Result;
        }
    }
}
