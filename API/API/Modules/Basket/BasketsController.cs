using API.Infrastructure.Extensions;
using API.Modules.Basket.DTO;
using API.Modules.Basket.Ports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Basket
{
    [Route("back/api/[controller]")]
    [ApiController]
    [Authorize]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService basketService;

        public BasketsController(IBasketService basketService)
        {
            this.basketService = basketService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BasketItemDTO>> GetBasket()
        {
            var response = basketService.GetBasket(Guid.Parse(User.GetId()));

            return response.IsSuccess
                ? Ok(response.Value)
                : BadRequest(response.Error);
        }

        [HttpGet("Count")]
        public ActionResult<IEnumerable<BasketItemDTO>> GetBasketCount()
        {
            var response = basketService.GetBasketCount(Guid.Parse(User.GetId()));

            return response.IsSuccess
                ? Ok(response.Value)
                : BadRequest(response.Error);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateOrAddItemToBasketAsync(BasketItemAddDTO addDto)
        {
            var response = await basketService.UpdateOrAddItemAsync(Guid.Parse(User.GetId()), addDto);

            return response.IsSuccess
                ? Ok(response.Value)
                : BadRequest(response.Error);
        }

        [HttpDelete("{productId:Guid}")]
        public async Task<ActionResult> RemoveItemFromBasketAsync(Guid productId)
        {
            var response = await basketService.RemoveByProductAndBuyerAsync(Guid.Parse(User.GetId()), productId);

            return response.IsSuccess
                ? Ok(response.Value)
                : BadRequest(response.Error);
        }
    }
}
