// Ignore Spelling: Dto

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Application.Account
{
    public class ConfirmEmailDto
    {
        public string? Email { get; set; }

        public string? Token { get; set; }
    }
}