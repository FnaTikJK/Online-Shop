using API.Modules.Account.DTO;
using API.Modules.Account.Ports;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace API.Modules.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUsersService usersService;

        public AccountsController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> RegisterAsync([FromBody] RegDTO regDto)
        {
            var response = await usersService.RegisterUserAsync(regDto);
            if (!response.IsSuccess)
                return BadRequest(response.Error);

            Response.Cookies.Append("Auth", response.Value);
            return NoContent();
        }

        [HttpPost("Login")]
        public async Task<ActionResult> LoginAsync([FromBody] AuthDTO authDto)
        {
            var response = await usersService.LoginUserAsync(authDto);
            if (!response.IsSuccess)
                return BadRequest(response.Error);

            Response.Cookies.Append("Auth", response.Value);
            return NoContent();
        }

        [HttpPost("Logout")]
        public async Task LogoutAsync()
        {
            Response.Cookies.Delete("Auth");
        }
    }
}
