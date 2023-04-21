using API.Infrastructure;
using API.Modules.Profile.DTO;
using API.Modules.Profile.Ports;
using AutoMapper;

namespace API.Modules.Profile.Adapters
{
    public class ProfilesService : IProfilesService
    {
        private readonly IProfilesRepository profilesRepository;
        private readonly IMapper mapper;

        public ProfilesService(IProfilesRepository profilesRepository, IMapper mapper)
        {
            this.profilesRepository = profilesRepository;
            this.mapper = mapper;
        }

        public async Task<Result<ProfileDTO>> GetProfileAsync(string login)
        {
            var existed = await profilesRepository.GetProfileAsync(login);
            if (existed == null)
                return Result.Fail<ProfileDTO>("Такого профиля не существует");

            return Result.Ok(mapper.Map<ProfileDTO>(existed));
        }

        public async Task<Result<bool>> UpdateProfileAsync(string login, ProfileDTO profileDto)
        {
            var existed = await profilesRepository.GetProfileAsync(login);
            if (existed == null)
                return Result.Fail<bool>("Такого профиля не существует");

            mapper.Map(profileDto, existed);
            await profilesRepository.SaveChangesAsync();
            return Result.Ok(true);
        }
    }
}
