﻿using Microsoft.AspNetCore.Http;
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

        string GenerateToken(string email, string userId, string userName);

        string RefreshToken(string token, string email, string userId);

        string GetUserIdFromToken(HttpRequest request);

        string GetUserNameFromToken(HttpRequest request);
    }
}