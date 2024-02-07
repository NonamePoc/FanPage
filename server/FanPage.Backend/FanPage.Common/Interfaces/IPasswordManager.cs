using FanPage.Common.Models;

namespace FanPage.Common.Interfaces
{
    public interface IPasswordManager
    {
        string GetNewPassword();

        PasswordValidateResponse ValidatePassword(string password);
    }
}