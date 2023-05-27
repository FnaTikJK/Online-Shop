using System.Security.Claims;

namespace API.Infrastructure.Extensions
{
    public static class ClaimsExtensions
    {
        public static string? GetId(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(e => e.Type.EndsWith("nameidentifier"))?.Value;
        }

        public static string? GetLogin(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(e => e.Type.EndsWith("name"))?.Value;
        }

        //public static string? GetName(this ClaimsPrincipal user)
        //{
        //    return user.Claims.FirstOrDefault(e => e.Type.EndsWith("name"))?.Value;
        //}
    }
}
