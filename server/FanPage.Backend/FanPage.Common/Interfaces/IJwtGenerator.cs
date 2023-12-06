using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Common.Interfaces
{
    public interface IJwtGenerator
    {
        Task<string> CreateToken(IdentityUser user);

        string RefreshToken(string token, string email, string userId);
    }
}