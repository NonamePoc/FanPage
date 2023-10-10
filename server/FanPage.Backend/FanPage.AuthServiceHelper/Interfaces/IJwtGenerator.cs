using FanPage.AuthServiceHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.AuthServiceHelper.Interfaces
{
    public interface IJwtGenerator
    {
        string CreateToken(CreateTokenModel createToken);

        string RefreshToken (RefreshTokenModel refreshToken);
    }
}
