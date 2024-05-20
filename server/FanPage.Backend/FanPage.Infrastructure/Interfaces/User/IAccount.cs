using FanPage.Application.Account;
using FanPage.Application.Auth;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Interfaces.User
{
    public interface IAccount
    {
        Task Registration(RegistrationDto registration);

        Task ConfirmEmail(ConfirmEmailDto confirmEmail);

        Task ChangeEmail(ChangeEmailDto changeEmail);

        Task ChangePassword(ChangePasswordDto changePassword, HttpRequest request);

        Task RequestRestorePassword(RequestRestorePasswordDto requestRestorePassword);

        Task RestorePassword(RestorePasswordDto restore);

        Task RequestToChangeEmail(RequestToChangeEmailDto changeEmail, HttpRequest request);

        Task ChangeUserName(string changeUserName, HttpRequest request);

        Task ChangeAvatar(string avatar, HttpRequest request);

        Task<LogInResponseDto> GetUserInfo(HttpRequest request, string userName);
        Task GoogleRegistration(string googleToken);
    }
}
