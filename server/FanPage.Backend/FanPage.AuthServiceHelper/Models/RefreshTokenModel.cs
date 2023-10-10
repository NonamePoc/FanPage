using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.AuthServiceHelper.Models
{
    public class RefreshTokenModel
    {
        public string? UserId { get; set; }

        public string? Token { get; set; }

        public string? Email { get; set; }
    }
}
