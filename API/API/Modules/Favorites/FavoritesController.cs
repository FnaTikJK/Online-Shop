using API.Infrastructure;
using API.Modules.Favorites.DTO;
using API.Modules.Favorites.Ports;
using API.Modules.Search.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Favorites
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoritesService favoritesService;

        public FavoritesController(IFavoritesService favoritesService)
        {
            this.favoritesService = favoritesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductShortDTO>>> GetFavoritesAsync()
        {
            var response = favoritesService.GetFavoriteProducts(Guid.Parse(User.GetId()));

            return response.IsSuccess ?
            Ok(response.Value) : BadRequest(response.Error);
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult> AddFavoriteAsync([FromBody]AddFavoriteDTO addFavoriteDto)
        {
            var response = await favoritesService.AddFavoriteAsync(Guid.Parse(User.GetId()), addFavoriteDto.ProductId);
          
            return response.IsSuccess ?
                Ok(response.Value) : BadRequest(response.Error);
        }

        [HttpDelete("{productId:Guid}")]
        public async Task<ActionResult> RemoveFavoriteAsync(Guid productId)
        {
            var response = await favoritesService.RemoveFavoriteAsync(productId);

            return response.IsSuccess ?
                Ok(response.Value) : BadRequest(response.Error);
        }
    }


}
