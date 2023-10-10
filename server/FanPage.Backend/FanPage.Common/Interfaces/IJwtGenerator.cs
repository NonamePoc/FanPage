using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Common.Interfaces
{
    public interface IJwtGenerator
    {
        string CreateToken(string email, string userId);

        string RefreshToken(string token, string email, string userId);
    }
}
