using System.Security.Claims;
using API.Infrastructure;
using API.Modules.Account.DTO;

namespace API.Modules.Account.Ports
{
    public interface IUsersService
    {
        public Task<Result<ClaimsIdentity>> RegisterUserAsync(RegDTO regDto);
        public Task<Result<ClaimsIdentity>> LoginUserAsync(AuthDTO authDto);
    }
}
