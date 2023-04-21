using API.Modules.Account.Core;
using API.Modules.Account.DTO;
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
        }
    }
}
