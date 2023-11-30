using FanPage.Application.Auth;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Interfaces.User
{
    public interface IAuth
    {
        Task<LogInResponseDto> LogIn(AuthDto auth);

        Task LogOut(HttpRequest request);

        Task<RefreshTokenDto> RefreshToken(HttpRequest request);
    }
}