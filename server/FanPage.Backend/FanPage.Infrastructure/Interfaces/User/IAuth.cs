using FanPage.Application.Auth;
using FanPage.Application.GoogleAuth;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Interfaces.User
{
    public interface IAuth
    {
        Task<LogInResponseDto> LogIn(AuthDto auth);

        Task LogOut(HttpRequest request);

        Task<RefreshTokenDto> RefreshToken(HttpRequest request);

        Task<GoogleResponseDto> GoogleLogin(string googleToken);
    }
}