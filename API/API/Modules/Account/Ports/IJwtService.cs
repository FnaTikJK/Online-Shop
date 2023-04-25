using System.Security.Claims;

namespace API.Modules.Account.Ports
{
    public interface IJwtService
    {
        public string CreateToken(List<Claim> claims);
    }
}
