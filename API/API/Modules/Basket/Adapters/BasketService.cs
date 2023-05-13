using API.Infrastructure;
using API.Modules.Account.Ports;
using API.Modules.Basket.Core;
using API.Modules.Basket.DTO;
using API.Modules.Basket.Ports;
using AutoMapper;

namespace API.Modules.Basket.Adapters
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;
        private readonly IUsersRepository usersRepository;

        public BasketService(IMapper mapper, IBasketRepository basketRepository, IUsersRepository usersRepository)
        {
            this.mapper = mapper;
            this.basketRepository = basketRepository;
            this.usersRepository = usersRepository;
        }

        public Result<IEnumerable<BasketItemDTO>> GetBasket(Guid buyerId)
        {
            return Result.Ok(mapper.Map<IEnumerable<BasketItemDTO>>(basketRepository.GetAllByBuyer(buyerId)));
        }

        public async Task<Result<bool>> UpdateOrAddItemAsync(Guid buyerId, BasketItemAddDTO addDto)
        {
            var existed = await basketRepository.GetByBuyerAndProduct(buyerId, addDto.ProductId);

            if (existed == null)
            {
                var item = mapper.Map<BasketItem>(addDto);
                item.Buyer = await usersRepository.GetBuyerByIdAsync(buyerId);
                await basketRepository.AddAsync(item);
                await basketRepository.SaveChangesAsync();
            }
            else
            {
                if (addDto.Count <= 0)
                    await basketRepository.RemoveByProductAndBuyerAsync(buyerId, addDto.ProductId);
                else
                    existed.Count = addDto.Count;
                await basketRepository.SaveChangesAsync();
            }

            return Result.Ok(true);
        }

        public async Task<Result<bool>> RemoveByProductAndBuyerAsync(Guid buyerId, Guid productId)
        {
            await basketRepository.RemoveByProductAndBuyerAsync(buyerId, productId);
            await basketRepository.SaveChangesAsync();

            return Result.Ok(true);
        }
    }
}
