using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FanPage.Common.Configurations;
using FanPage.Common.Interfaces;
using FanPage.Domain.Account.Entities;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace FanPage.Common.Implementations
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly SigningCredentials _credentials;
        private readonly JwtConfiguration _jwtConfiguration;
        private readonly JwtSecurityTokenHandler _tokenHandler;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public JwtGenerator(
            JwtConfiguration options,
            JwtSecurityTokenHandler tokenHandler,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager
        )
        {
            _jwtConfiguration = options;
            _tokenHandler = tokenHandler;
            _userManager = userManager;
            _roleManager = roleManager;

            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtConfiguration.Key)
            );
            _credentials = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha512Signature
            );
        }

        public async Task<string> CreateToken(IdentityUser user)
        {
            var claims = await GetValidClaim(user);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(_jwtConfiguration.LifeTime),
                SigningCredentials = _credentials
            };

            var token = _tokenHandler.CreateToken(tokenDescriptor);
            return _tokenHandler.WriteToken(token);
        }

        private async Task<List<Claim>> GetValidClaim(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Name, user.UserName)
            };
            var userClaim = await _userManager.GetClaimsAsync((User)user);
            claims.AddRange(userClaim);
            var userRoles = _userManager.GetRolesAsync((User)user);
            foreach (var userRole in await userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await _roleManager.FindByIdAsync(userRole);
                if (role != null)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    foreach (var roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }

            return claims;
        }

        public string RefreshToken(string token, string email, string userId)
        {
            if (!_tokenHandler.CanReadToken(token))
                throw new SecurityTokenValidationException();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Sub, userId)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(_jwtConfiguration.LifeTime),
                SigningCredentials = _credentials
            };

            var newToken = _tokenHandler.CreateToken(tokenDescriptor);
            return _tokenHandler.WriteToken(newToken);
        }

        public async Task<string> CreateTokenFromGoogle(string googleToken)
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(googleToken);
            var users = await _userManager.FindByEmailAsync(payload.Email);

            var email = users.Email;
            var userId = users.Id;
            var userName = users.UserName;
            
            var user = new IdentityUser()
            {
                Email = email,
                UserName = userName,
                Id = userId,
            };
            

            return await CreateToken(user);
        }
    }
}
