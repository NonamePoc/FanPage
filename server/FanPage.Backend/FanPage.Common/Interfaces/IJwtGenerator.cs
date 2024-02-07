using Microsoft.AspNetCore.Identity;

namespace FanPage.Common.Interfaces
{
    public interface IJwtGenerator
    {
        Task<string> CreateToken(IdentityUser user);

        string RefreshToken(string token, string email, string userId);

        Task<string> CreateTokenFromGoogle(string googleToken);
    }
}