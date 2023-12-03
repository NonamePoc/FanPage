using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Common.Interfaces
{
    public interface IJwtTokenManager
    {
        string GetTokenFromHeader(HttpRequest request);

        Task<bool> IsTokenExists(HttpRequest request);

        Task<string> GenerateToken(IdentityUser user);

        string RefreshToken(string token, string email, string userId);

        string GetUserIdFromToken(HttpRequest request);
    }
}
