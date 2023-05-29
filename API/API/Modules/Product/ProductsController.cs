using API.Infrastructure.Extensions;
using API.Modules.Product.DTO;
using API.Modules.Product.Ports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllAsync()
        {
            var response = await productsService.GetAllAsync();

            return response.IsSuccess ? Ok(response.Value)
                : BadRequest(response.Error);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ProductDTO>> GetByIdAsync(Guid id)
        {
            var response = await productsService.GetByIdAsync(id);

            return response.IsSuccess ? Ok(response.Value)
                : BadRequest(response.Error);
        }

        [HttpGet("{id:Guid}/Auth")]
        public async Task<ActionResult<ProductDTO>> GetByIdWithInfoAsync(Guid id)
        {
            var response = await productsService.GetByIdWithInfoAsync(Guid.Parse(User.GetId()), id);

            return response.IsSuccess ? Ok(response.Value)
                : BadRequest(response.Error);
        }

        [HttpPost]
        public async Task<ActionResult> AddASync(ProductAddDTO productAddDto)
        {
            var response = await productsService.AddAsync(productAddDto);

            return response.IsSuccess ? NoContent()
                : BadRequest(response.Error);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(ProductDTO productDto)
        {
            var response = await productsService.UpdateAsync(productDto);

            return response.IsSuccess ? NoContent()
                : BadRequest(response.Error);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var response = await productsService.DeleteAsync(id);

            return response.IsSuccess ? NoContent()
                : BadRequest(response.Error);
        }
    }
}
