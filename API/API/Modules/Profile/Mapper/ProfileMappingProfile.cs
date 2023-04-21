using API.Modules.Account.Core;
using API.Modules.Profile.DTO;

namespace API.Modules.Profile.Mapper
{
    public class ProfileMappingProfile : AutoMapper.Profile
    {
        public ProfileMappingProfile()
        {
            CreateMap<Buyer, ProfileDTO>()
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.BirthDate)));
        }
    }
}
