using FanPage.Common.Interfaces;
using FanPage.Common.Models;
using PasswordGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Common.Implementations
{
    public class PasswordManager : IPasswordManager
    {
        private readonly Password _password;
        private readonly IPasswordSettings _passwordSettings;

        public PasswordManager(IPasswordSettings passwordSettings)
        {
            _passwordSettings = passwordSettings;
            _password = new Password(passwordSettings);
        }

        public string GetNewPassword()
        {
            return _password.Next();
        }

        public PasswordValidateResponse ValidatePassword(string password)
        {
            var errorMessages = new Dictionary<string, string>();

            if (_passwordSettings.MinimumLength > password.Length)
                errorMessages.Add("MinimumLength", $"Min lenght password - {_passwordSettings.MinimumLength}");

            if (_passwordSettings.MaximumLength < password.Length)
                errorMessages.Add("MaximumLength", $"Max lenght password - {_passwordSettings.MaximumLength}");

            if (_passwordSettings.IncludeLowercase && !password.Any(c => char.IsLower(c)))
                errorMessages.Add("IncludeLowercase", "The password must contain a lowercase letter");

            if (_passwordSettings.IncludeUppercase && !password.Any(c => char.IsUpper(c)))
                errorMessages.Add("IncludeUppercase", "The password must contain an uppercase letter");

            if (_passwordSettings.IncludeNumeric && !password.Any(c => char.IsDigit(c)))
                errorMessages.Add("IncludeNumeric", "The password must contain a digit");


            if (_passwordSettings.IncludeSpecial && password.All(char.IsLetterOrDigit))
                errorMessages.Add("IncludeSpecial", "Password must be a character other than a letter or number");

            var retval = new PasswordValidateResponse
            {
                Errors = errorMessages
            };

            return retval;
        }
    }
}

