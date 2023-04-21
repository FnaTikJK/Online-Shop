using API.Infrastructure;
using API.Modules.Profile.DTO;

namespace API.Modules.Profile.Ports
{
    public interface IProfilesService
    {
        public Task<Result<ProfileDTO>> GetProfileAsync(string login);
        public Task<Result<bool>> UpdateProfileAsync(string login, ProfileDTO profileDto);
    }
}
