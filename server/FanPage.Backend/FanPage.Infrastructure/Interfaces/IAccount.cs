using FanPage.Application.Account;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Infrastructure.Interfaces
{
    public interface IAccount
    {
        Task Registration (RegistrationDto registration);

        Task ConfirmEmail (ConfirmEmailDto confirmEmail);

        Task ChangeEmail (ChangeEmailDto changeEmail);

        Task ChangePassword (ChangePasswordDto changePassword, HttpRequest request);

        Task RequestRestorePassword (RequestRestorePasswordDto requestRestorePassword);

        Task RestorePassword(RestorePasswordDto restore);

        Task RequestToChangeEmail (RequestToChangeEmailDto changeEmail, HttpRequest request);
    }
}
