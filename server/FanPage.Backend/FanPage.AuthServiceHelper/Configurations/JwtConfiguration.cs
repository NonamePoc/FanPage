using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.AuthServiceHelper.Configurations
{
    public class JwtConfiguration
    {
        public TimeSpan LifeTime { get; set; }

        public string? Key { get; set; }

        public TimeSpan BlackListLifeTime { get; set; }
    }
}
