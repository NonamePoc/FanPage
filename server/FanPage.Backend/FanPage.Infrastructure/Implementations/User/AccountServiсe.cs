using FanPage.Application.Account;
using FanPage.Application.Auth;
using FanPage.Common.Interfaces;
using FanPage.Domain.Account.Entities;
using FanPage.Domain.Account.Repos.Interfaces;
using FanPage.EmailService.Interfaces;
using FanPage.EmailService.Models;
using FanPage.Exceptions;
using FanPage.Infrastructure.Interfaces.User;
using Flurl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FanPage.Infrastructure.Implementations.User
{
    public class AccountServiсe : IAccount
    {
        private readonly IdentityUserManager _userManager;

        private readonly IEmailService _emailService;

        private readonly SignInManager<Domain.Account.Entities.User> _signInManager;

        private readonly IPasswordManager _passwordManager;

        private readonly IJwtTokenManager _jwtTokenManager;

        private readonly ICustomizationSettingsRepository _customizationSettings;

        public AccountServiсe( ICustomizationSettingsRepository customizationSettings,
            IPasswordManager passwordManager, SignInManager<Domain.Account.Entities.User> signInManager,
            IJwtTokenManager jwtTokenManager,
            IdentityUserManager identityUser, IEmailService emailService)
        {
            _userManager = identityUser;
            _emailService = emailService;
            _jwtTokenManager = jwtTokenManager;
            _signInManager = signInManager;
            _passwordManager = passwordManager;
            _customizationSettings = customizationSettings;
        }

        public async Task ConfirmEmail(ConfirmEmailDto confirmEmail)
        {
            var user = await _userManager.FindByEmailAsync(confirmEmail.Email);

            if (user is null)
            {
                throw new UserNotFoundException("User not found");
            }

            var validToken = confirmEmail.Token.Replace(" ", "+");

            var confirmResult = await _userManager.ConfirmEmailAsync(user, validToken);

            if (!confirmResult.Succeeded)
            {
                throw new AggregateException(
                    confirmResult.Errors.Select(s => new ResetPasswordException(s.Description)));
            }
        }

        public async Task<LogInResponseDto> GetUserInfo(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user is null)
                throw new UserNotFoundException("User not found");

            var role = await _userManager.GetRolesAsync(user);

            var token = await _jwtTokenManager.GenerateToken(user);
            return new LogInResponseDto
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.UserName,
                Token = token,
                Role = role.FirstOrDefault(),
                WhoBan = user.WhoBan,
                UserAvatar = user.UserAvatar,
            };
        }

        public async Task ChangeEmail(ChangeEmailDto changeEmail)
        {
            var user = await _userManager.FindByEmailAsync(changeEmail.Email);

            if (user is null)
                throw new UserNotFoundException("User not found");

            var validToken = changeEmail.Token.Replace(" ", "+");
            var email = await _userManager.ChangeEmailAsync(user, changeEmail.NewEmail, validToken);

            if (!email.Succeeded)
                throw new AggregateException(
                    email.Errors.Select(s => new ResetPasswordException(s.Description)));
        }

        public async Task RequestToChangeEmail(RequestToChangeEmailDto changeEmail, HttpRequest request)
        {
            var idFromToken = _jwtTokenManager.GetUserIdFromToken(request);
            var user = await _userManager.FindByIdAsync(idFromToken);

            if (user is null)
                throw new UserNotFoundException("User not found");

            if (user.Email == changeEmail.NewEmail)
                throw new Exception("The new email address must be different from the old one");

            var changeEmailToken = await _userManager.GenerateChangeEmailTokenAsync(user, changeEmail.NewEmail);

            var changeEmailUrl = Url.Combine(
                changeEmail.ChangeEmailUrl.BaseAddress,
                changeEmail.ChangeEmailUrl.ControllerRoute,
                changeEmail.ChangeEmailUrl.MethodRoute,
                $"?email={user.Email}&newEmail={changeEmail.NewEmail}&token={changeEmailToken}"
            );

            var email = new EmailRequest
            {
                Subject = "FanPage",
                Html = $"Link Reset Email - {changeEmailUrl}",
                EmailTo = user.Email
            };

            await _emailService.SendAsync(email);
        }

        public async Task ChangePassword(ChangePasswordDto changePassword, HttpRequest request)
        {
            var idFromToken = _jwtTokenManager.GetUserIdFromToken(request);
            var user = await _userManager.FindByIdAsync(idFromToken);

            if (user is null)
                throw new UserNotFoundException("User not found");

            var checkPasswordResult =
                await _signInManager.CheckPasswordSignInAsync(user, changePassword.Password, false);

            if (!checkPasswordResult.Succeeded)
                throw new InvalidPasswordException("Invalid Password");

            var changePasswordResult =
                await _userManager.ChangePasswordAsync(user, changePassword.Password, changePassword.NewPassword);

            if (!changePasswordResult.Succeeded)
                throw new AggregateException(
                    changePasswordResult.Errors.Select(s => new ChangePasswordException(s.Description))
                );

            var email = new EmailRequest
            {
                Subject = "FanPage",
                Html = "Password update",
                EmailTo = user.Email
            };

            await _emailService.SendAsync(email);
        }

        public async Task RequestRestorePassword(RequestRestorePasswordDto requestRestorePassword)
        {
            var user = await _userManager.FindByEmailAsync(requestRestorePassword.Email);

            if (user is null)
                throw new UserNotFoundException("User not found");

            var resetPassToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            var resetPassUrl = Url.Combine(
                requestRestorePassword.RestorePasswordUrl.BaseAddress,
                requestRestorePassword.RestorePasswordUrl.ControllerRoute,
                requestRestorePassword.RestorePasswordUrl.MethodRoute,
                $"?email={user.Email}&token={resetPassToken}"
            );

            var email = new EmailRequest
            {
                Subject = "FanPage",
                Html = $"Link Reset Password - {resetPassUrl}",
                EmailTo = user.Email
            };

            await _emailService.SendAsync(email);
        }

        public async Task RestorePassword(RestorePasswordDto restore)
        {
            var user = await _userManager.FindByEmailAsync(restore.Email);

            if (user is null)
                throw new UserNotFoundException("User not found");


            var newPassword = _passwordManager.GetNewPassword();
            var validToken = restore.Token.Replace(" ", "+");
            var resetPassword = await _userManager.ResetPasswordAsync(user, validToken, newPassword);

            if (!resetPassword.Succeeded)
                throw new AggregateException(
                    resetPassword.Errors.Select(s => new ResetPasswordException(s.Description)));

            var email = new EmailRequest
            {
                Subject = "FanPage",
                Html = $"New Password - {newPassword}",
                EmailTo = user.Email
            };

            await _emailService.SendAsync(email);
        }

        public async Task Registration(RegistrationDto registration)
        {
            var customizationSettingId = await _customizationSettings.CreateCustomizationSettings();
            var user = new Domain.Account.Entities.User
            {
                Email = registration.Email,
                UserName = registration.UserName,
                CustomizationSettingsId = customizationSettingId,
                WhoBan = "None"
            };

            if (registration.UserName != null && await _userManager.FindByNameAsync(registration.UserName) != null)
            {
                throw new UserCreateException("User with this username already exists");
            }

            if (registration.Email != null && await _userManager.FindByEmailAsync(registration.Email) == null)
            {
                var createResult = await _userManager.CreateAsync(user, registration.Password);

                if (!createResult.Succeeded)
                {
                    throw new AggregateException(createResult.Errors.Select(s =>
                        new UserCreateException(s.Description)));
                }


                var roleResult = await _userManager.AddToRoleAsync(user, "User");

                if (!createResult.Succeeded)
                    throw new AggregateException(
                        roleResult.Errors.Select(s => new UserCreateException(s.Description)));

                var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                var emailConfirmationUrl = Url.Combine(
                    registration.ConfirmEmailUrl.BaseAddress,
                    registration.ConfirmEmailUrl.ControllerRoute,
                    registration.ConfirmEmailUrl.MethodRoute,
                    $"?email={user.Email}&token={emailConfirmationToken}"
                );

                var email = new EmailRequest
                {
                    Subject = "FanPage",
                    Html = $"Link Confirm Email - {emailConfirmationUrl}",
                    EmailTo = user.Email
                };

                await _emailService.SendAsync(email);
            }
        }

        public async Task GoogleRegistration(string googleToken)
        {
            var token = await _jwtTokenManager.GoogleLogin(googleToken);
            var email = await _jwtTokenManager.DecodeTokenAndGetEmail(token);

            var existingUser = await _userManager.FindByEmailAsync(email);
            if (existingUser != null)
            {
                throw new UserCreateException("User with this email already exists");
            }

            var user = new Domain.Account.Entities.User
            {
                Email = email,
                UserName = email,
                CustomizationSettingsId = await _customizationSettings.CreateCustomizationSettings(),
                WhoBan = "None"
            };

            var createResult = await _userManager.CreateAsync(user);
            if (!createResult.Succeeded)
            {
                throw new AggregateException(createResult.Errors.Select(s =>
                    new UserCreateException(s.Description)));
            }

            var roleResult = await _userManager.AddToRoleAsync(user, "User");
            if (!roleResult.Succeeded)
            {
                throw new AggregateException(
                    roleResult.Errors.Select(s => new UserCreateException(s.Description)));
            }
        }
    }
}