﻿namespace FanPage.Api.Models.Account
{
    public class ConfirmEmailModel
    {
        public string? Email { get; set; }

        public string? Token { get; set; }
    }
}