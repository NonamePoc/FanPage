using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.AuthServiceHelper.Models
{
    public class CreateTokenModel
    {
        public string? UserId { get; set; }

        public string? Email { get; set; }
    }
}
