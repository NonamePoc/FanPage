using FanPage.Application.Auth;
using FanPage.Common.Interfaces;
using FanPage.Domain.User.Entities;
using FanPage.Exceptions;
using FanPage.Infrastructure.Interfaces.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FanPage.Infrastructure.Implementations.User
{
    public class AuthService : IAuth
    {
        private readonly IJwtTokenManager _jwtTokenManager;

        private readonly SignInManager<Domain.User.Entities.User> _signInManager;
        private readonly IdentityUserManager _userManager;

        public AuthService(IJwtTokenManager jwtTokenManager, SignInManager<Domain.User.Entities.User> signInManager,
            IdentityUserManager userManager)
        {
            _jwtTokenManager = jwtTokenManager;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<LogInResponseDto> LogIn(AuthDto authDto)
        {
            var user = await _userManager.FindByEmailAsync(authDto.Email);


            var userRole = await _userManager.GetRolesAsync(user);


            if (user is null)
                throw new LogInException("Wrong login or password");

            var result = await _signInManager.CheckPasswordSignInAsync(user, authDto.Password, false);

            if (!result.Succeeded)
                throw new LogInException("Wrong login or password");

            var token = await _jwtTokenManager.GenerateToken(user);
            return new LogInResponseDto
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.UserName,
                Token = token,
                Role = userRole.FirstOrDefault(),
                WhoBan = user.WhoBan,
                UserAvatar = user.UserAvatar,
                LifeTimeToken =  DateTime.UtcNow.AddDays(7)
            };
        }

        public async Task LogOut(HttpRequest request)
        {
            // token from black list token
            var token = _jwtTokenManager.GetTokenFromHeader(request);

            var userId = _jwtTokenManager.GetUserIdFromToken(request);
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                await _signInManager.SignOutAsync();

                // Else
                // If the user needs to be blacklisted, please make a separate method for this
            }
            else
            {
                throw new UserNotFoundException("User not found");
            }
        }


        public async Task<RefreshTokenDto> RefreshToken(HttpRequest request)
        {
            var token = _jwtTokenManager.GetTokenFromHeader(request);

            var userId = _jwtTokenManager.GetUserIdFromToken(request);
            var user = await _userManager.FindByIdAsync(userId);


            var newToken = _jwtTokenManager.RefreshToken(token, user.Email, userId);

            return new RefreshTokenDto
            {
                Token = newToken
            };
        }
    }
}