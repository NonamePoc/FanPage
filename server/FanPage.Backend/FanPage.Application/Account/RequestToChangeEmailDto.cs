using FanPage.Application.Url;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Application.Account
{
    public class RequestToChangeEmailDto
    {
        public string NewEmail { get; set; }

        public UrlInformationDto ChangeEmailUrl { get; set; }
    }
}
