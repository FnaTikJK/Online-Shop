using API.Infrastructure;
using API.Modules.Profile.DTO;
using API.Modules.Profile.Ports;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Profile
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class ProfileController : ControllerBase
    {
        private readonly IProfilesService profilesService;

        public ProfileController(IProfilesService profilesService)
        {
            this.profilesService = profilesService;
        }

        [HttpGet]
        public async Task<ActionResult<ProfileDTO>> GetProfileAsync()
        {
            var response = await profilesService.GetProfileAsync(User.GetLogin());

            return response.IsSuccess
                ? Ok(response)
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
