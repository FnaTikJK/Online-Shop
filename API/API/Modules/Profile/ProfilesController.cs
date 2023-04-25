using API.Infrastructure;
using API.Modules.Profile.DTO;
using API.Modules.Profile.Ports;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Profile
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProfilesController : ControllerBase
    {
        private readonly IProfilesService profilesService;

        public ProfilesController(IProfilesService profilesService)
        {
            this.profilesService = profilesService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ProfileDTO>> GetProfileAsync()
        {
            var response = await profilesService.GetProfileAsync(User.GetLogin());

            return response.IsSuccess
                ? Ok(response.Value)
                : BadRequest(response.Error);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Post()
        {
            var a = 10;
            return Ok();
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
