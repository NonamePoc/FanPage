using FanPage.AuthServiceHelper.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.AuthServiceHelper.Interfaces
{
    public interface IJwtTokenManager
    {
        string GetTokenFromHeader(HttpRequest request);

        Task<bool> IsTokenExistsAsync(HttpRequest request);

        string GenerateToken(CreateTokenModel create);

        string RefreshToken(RefreshTokenModel refresh);

        string GetUserIdFromToken(HttpRequest request);
    }
}
