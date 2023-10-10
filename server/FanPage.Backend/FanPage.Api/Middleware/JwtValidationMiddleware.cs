using FanPage.Common.Interfaces;
using System.Net;

namespace FanPage.Api.Middleware
{
    public class JwtValidationMiddleware : IMiddleware
    {
        private readonly IJwtTokenManager _jwtTokenManager;

        public JwtValidationMiddleware(IJwtTokenManager jwtTokenManager)
        {
            _jwtTokenManager = jwtTokenManager;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (!await _jwtTokenManager.IsTokenExists(context.Request))
            {
                await next(context);
                return;
            }

            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
    }
}

