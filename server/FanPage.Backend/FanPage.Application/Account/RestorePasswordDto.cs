﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Application.Account
{
    public class RestorePasswordDto
    {
        public string? Email { get; set; }
        public string? Token { get; set; }
    }
}