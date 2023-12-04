using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Application.Admin
{
    public class UserInfoResponseDto
    {
        public bool IsBanned { get; set; }
        public DateTimeOffset? BanExpirationDate { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Role { get; set;}

    }
}
