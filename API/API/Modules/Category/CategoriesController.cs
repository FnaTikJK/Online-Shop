using API.Modules.Category.DTO;
using API.Modules.Category.Ports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Category
{
    [Route("back/api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService categoriesService;
        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryShortDTO>>> GetAllAsync()
        {
            var response = await categoriesService.GetAllAsync();

            return response.IsSuccess
                ? Ok(response.Value)
                : BadRequest(response.Error);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<CategoryDTO>> GetByIdAsync(Guid id)
        {
            var response = await categoriesService.GetByIdAsync(id);

            return response.IsSuccess ? 
                Ok(response.Value) 
                : BadRequest(response.Error);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(CategoryAddDTO categoryAddDto)
        {
            var response = await categoriesService.AddAsync(categoryAddDto);

            return response.IsSuccess
                ? Ok(response.Value)
                : BadRequest(response.Error);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var response = await categoriesService.DeleteAsync(id);

            return response.IsSuccess
                ? Ok(response.Value)
                : BadRequest(response.Error);
        }
    }
}
