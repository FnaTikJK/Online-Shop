using API.Infrastructure;
using API.Modules.Account.Core;
using API.Modules.Account.DTO;
using API.Modules.Account.Ports;
using AutoMapper;

namespace API.Modules.Account.Mapper
{
    public class UserMappingProfile : AutoMapper.Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RegDTO, Buyer>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToDateTime(new TimeOnly())));
            CreateMap<AuthDTO, Buyer>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
            CreateMap<RegDTO, AuthDTO>();

            CreateMap<Guid, Product.Core.Product>()
                .ConvertUsing(typeof(BuyerConverter));
        }

        private class BuyerConverter : ITypeConverter<Guid, Buyer>
        {
            private readonly IUsersRepository usersRepository;

            public BuyerConverter(IUsersRepository usersRepository)
            {
                this.usersRepository = usersRepository;
            }

            public Buyer Convert(Guid source, Buyer destination, ResolutionContext context)
            {
                var task = usersRepository.GetBuyerByIdAsync(source);
                task.Wait();

                return task.Result 
                       ?? throw new NotFoundException();
            }
        }
    }
}
