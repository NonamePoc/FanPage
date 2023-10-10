﻿using FanPage.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Common.Implementations
{
    public class JwtTokenManager : IJwtTokenManager
    {

        private readonly IJwtGenerator _jwtGenerator;
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public JwtTokenManager(IJwtGenerator jwtGenerator,
            JwtSecurityTokenHandler tokenHandler)
        {
            _jwtGenerator = jwtGenerator;
            _tokenHandler = tokenHandler;
        }

        public Task<bool> IsTokenExists(HttpRequest request)
        {
            var token = GetTokenFromHeader(request);
            return Task.FromResult(token != null);
        }


        public string? GetTokenFromHeader(HttpRequest request)
        {
            return request.Headers.TryGetValue("Authorization", out var authorizationHeader)
                ? authorizationHeader.Single().Split(" ").Last()
                : null;
        }

        public string GenerateToken(string email, string userId)
        {
            return _jwtGenerator.CreateToken(email, userId);
        }

        public string RefreshToken(string token, string email, string userId)
        {
            return _jwtGenerator.RefreshToken(token, email, userId);
        }

        public string GetUserIdFromToken(HttpRequest request)
        {
            var token = GetTokenFromHeader(request);

            var jwtToken = _tokenHandler.ReadJwtToken(token);
            var claim = jwtToken.Claims.SingleOrDefault(w => w.Type == JwtRegisteredClaimNames.Sub);

            return claim?.Value;
        }
    }
}
