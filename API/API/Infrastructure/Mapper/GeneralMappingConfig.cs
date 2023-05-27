using AutoMapper;

namespace API.Infrastructure.Mapper
{
    public class GeneralMappingConfig : Profile
    {
        public GeneralMappingConfig()
        {
            CreateMap<DateTime, DateOnly>()
                .ConvertUsing(src => DateOnly.FromDateTime(src));
            CreateMap<DateOnly, DateTime>()
                .ConvertUsing(src => src.ToDateTime(TimeOnly.MinValue));
        }
    }
}
