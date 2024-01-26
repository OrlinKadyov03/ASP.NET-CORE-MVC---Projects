using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Running
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal user) 
        {
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
