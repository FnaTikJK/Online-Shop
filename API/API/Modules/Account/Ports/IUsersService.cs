using System.Security.Claims;
using API.Infrastructure;
using API.Modules.Account.DTO;

namespace API.Modules.Account.Ports
{
    public interface IUsersService
    {
        public Task<Result<string>> RegisterUserAsync(RegDTO regDto);
        public Task<Result<string>> LoginUserAsync(AuthDTO authDto);
    }
}
