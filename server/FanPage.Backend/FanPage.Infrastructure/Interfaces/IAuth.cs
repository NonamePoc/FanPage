using FanPage.Application.Auth;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Infrastructure.Interfaces
{
    public interface IAuth
    {
        Task<LogInResponseDto> LogIn(AuthDto auth);

        Task LogOut(HttpRequest request);

        Task<RefreshTokenDto> RefreshToken(HttpRequest request);
    }
}
