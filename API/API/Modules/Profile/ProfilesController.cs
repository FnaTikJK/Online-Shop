using API.Infrastructure.Extensions;
using API.Modules.Profile.DTO;
using API.Modules.Profile.Ports;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Profile
{
    [Route("back/api/[controller]")]
    [ApiController]
    
    public class ProfilesController : ControllerBase
    {
        private readonly IProfilesService profilesService;

        public ProfilesController(IProfilesService profilesService)
        {
            this.profilesService = profilesService;
        }

        [Authorize]
        [HttpGet("Own")]
        public async Task<ActionResult<ProfileDTO>> GetOwnProfileAsync()
        {
            var response = await profilesService.GetProfileAsync(User.GetLogin());

            return response.IsSuccess
                ? Ok(response.Value)
                : BadRequest(response.Error);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProfileAsync(ProfileDTO profileDto)
        {
            var response = await profilesService.UpdateProfileAsync(User.GetLogin(), profileDto);

            return response.IsSuccess
                ? NoContent()
                : BadRequest(response.Error);
        }
    }
}
