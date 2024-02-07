using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace FanPage.Common.Interfaces
{
    public interface IJwtTokenManager
    {
        string GetTokenFromHeader(HttpRequest request);

        Task<bool> IsTokenExists(HttpRequest request);

        Task<string> GenerateToken(IdentityUser user);

        string RefreshToken(string token, string email, string userId);

        string GetUserIdFromToken(HttpRequest request);

        string GetUserNameFromToken(HttpRequest request);

        Task<string> GoogleLogin(string googleToken);

        Task<string> DecodeTokenAndGetEmail(string token);
    }
}