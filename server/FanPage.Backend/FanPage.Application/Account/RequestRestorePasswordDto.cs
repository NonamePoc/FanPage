// Ignore Spelling: Dto

using FanPage.Application.Url;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Application.Account
{
    public class RequestRestorePasswordDto
    {
        public string? Email { get; set; }

        public UrlInformationDto? RestorePasswordUrl { get; set; }
    }
}