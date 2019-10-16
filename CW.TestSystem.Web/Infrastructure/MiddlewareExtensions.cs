using Microsoft.AspNetCore.Builder;

namespace CW.TestSystem.Web.Infrastructure
{

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseJwtTokenInHttpOnlyCookie(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtTokenInHttpOnlyCookie>();
        }
    }
}
