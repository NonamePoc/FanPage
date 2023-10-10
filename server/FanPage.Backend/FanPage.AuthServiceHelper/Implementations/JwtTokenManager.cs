using FanPage.AuthServiceHelper.Interfaces;
using FanPage.AuthServiceHelper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.AuthServiceHelper.Implementations
{
    public class JwtTokenManager : IJwtTokenManager
    {

        private readonly IJwtGenerator _jwtGenerator;

        private readonly JwtSecurityTokenHandler _jwtSecurityToken;

        public JwtTokenManager(IJwtGenerator jwtGenerator,
                JwtSecurityTokenHandler tokenHandler)
        {
            _jwtGenerator = jwtGenerator;
            _jwtSecurityToken = tokenHandler;
        }

        public string GenerateToken(CreateTokenModel create)
        {
            return _jwtGenerator.CreateToken(create);
        }

        public string GetTokenFromHeader(HttpRequest request)
        {
            return request.Headers.TryGetValue("Authorization", out var authorizationHeader)
                         ? authorizationHeader.Single().Split(" ").Last()
                         : null;
        }

        public string GetUserIdFromToken(HttpRequest request)
        {
            var token = GetTokenFromHeader(request);

            var jwtToken = _jwtSecurityToken.ReadJwtToken(token);
            var claim = jwtToken.Claims.SingleOrDefault(w => w.Type == JwtRegisteredClaimNames.Sub);

            return claim?.Value;
        }

        public async Task<bool> IsTokenExistsAsync(HttpRequest request)
        {
            return await Task.FromResult(request.Headers.ContainsKey("Authorization"));
        }


        public string RefreshToken(RefreshTokenModel refresh)
        {
            return _jwtGenerator.RefreshToken(refresh);
        }
    }
}
