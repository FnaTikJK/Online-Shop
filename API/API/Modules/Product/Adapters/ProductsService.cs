using API.Infrastructure;
using API.Modules.Product.DTO;
using API.Modules.Product.Ports;
using AutoMapper;

namespace API.Modules.Product.Adapters
{
    public class ProductsService : IProductsService
    {
        private readonly IMapper mapper;
        private readonly IProductsRepository productsRepository;

        public ProductsService(IMapper mapper, IProductsRepository productsRepository)
        {
            this.mapper = mapper;
            this.productsRepository = productsRepository;
        }

        public async Task<Result<IEnumerable<ProductDTO>>> GetAllAsync()
        {
            return Result.Ok(mapper.Map<IEnumerable<ProductDTO>>(await productsRepository.GetAllAsync()));
        }

        public async Task<Result<ProductDTO>> GetByIdAsync(Guid id)
        {
            var existed = await productsRepository.GetByIdASync(id);
            if (existed == null)
                return Result.Fail<ProductDTO>("Такого продукта не сущесвтует");

            return Result.Ok(mapper.Map<ProductDTO>(existed));
        }

        public async Task<Result<bool>> AddAsync(ProductAddDTO productDto)
        {
            await productsRepository.AddAsync(mapper.Map<Core.Product>(productDto));

            return Result.Ok(true);
        }

        public async Task<Result<bool>> UpdateAsync(ProductDTO productDto)
        {
            var existed = productsRepository.GetByIdASync(productDto.Id);
            if (existed == null)
                return Result.Fail<bool>("Такого продукта не сущесвтует");
            mapper.Map(productDto, existed);

            return Result.Ok(true);
        }

        public async Task<Result<bool>> DeleteAsync(Guid id)
        {
            await productsRepository.DeleteAsync(id);

            return Result.Ok(true);
        }
    }
}
