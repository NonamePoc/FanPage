using FanPage.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Common.Interfaces
{
    public interface IPasswordManager
    {
        string GetNewPassword();

        PasswordValidateResponse ValidatePassword(string password);
    }
}