using AutoMapper;
using FanPage.Api.JsonResponse;
using FanPage.Api.Models.Account;
using FanPage.Api.ViewModels.User;
using FanPage.Application.Account;
using FanPage.Application.Auth;
using FanPage.Application.Url;
using FanPage.Infrastructure.Configurations;
using FanPage.Infrastructure.Interfaces.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FanPage.Api.Controllers.User
{
    [ApiController]
    [Route(Route)]
    public sealed class AccountController : BaseController
    {
        private const string Route = "v1/account";

        private readonly IAccount _accountService;
        private readonly IMapper _mapper;
        private readonly ApplicationConfiguration _appConfiguration;

        public AccountController(
            IAccount accountService,
            IMapper mapper,
            ApplicationConfiguration configuration
        )
        {
            _accountService = accountService;
            _mapper = mapper;
            _appConfiguration = configuration;
        }

        /// <summary>
        ///  Register new account
        /// </summary>
        /// <param name="content">Model register account</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("registration")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        public async Task<IActionResult> Registration([FromBody] RegistrationModel content)
        {
            var dto = _mapper.Map<RegistrationDto>(content);
            dto.ConfirmEmailUrl = new UrlInformationDto(
                _appConfiguration.BaseApplicationAddress,
                Route,
                "confirmEmail"
            );
            await _accountService.Registration(dto);
            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("google-registration")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        public async Task<IActionResult> GoogleRegistration(string googleToken)
        {
            await _accountService.GoogleRegistration(googleToken);
            return Ok();
        }

        /// <summary>
        ///  Confirm email register
        /// </summary>
        /// <param name="content">Model confrim email</param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("confirmEmail")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailModel content)
        {
            var dto = _mapper.Map<ConfirmEmailDto>(content);
            await _accountService.ConfirmEmail(dto);

            //TODO: link redirect profile
            return Redirect("https://google.com");
        }

        /// <summary>
        ///  Request to change email
        /// </summary>
        /// <param name="content">Model request email change</param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("changeEmail")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        public async Task<IActionResult> RequestToChangeEmail(
            [FromBody] RequestToChangeEmailModel content
        )
        {
            var dto = _mapper.Map<RequestToChangeEmailDto>(content);
            dto.ChangeEmailUrl = new UrlInformationDto(
                _appConfiguration.BaseApplicationAddress,
                Route,
                "changeEmail"
            );

            await _accountService.RequestToChangeEmail(dto, HttpContext.Request);
            return Ok();
        }

        /// <summary>
        ///  Change email
        /// </summary>
        /// <param name="content">Model change email</param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("changeEmail")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        public async Task<IActionResult> ChangeEmail([FromQuery] ChangeEmailModel content)
        {
            var dto = _mapper.Map<ChangeEmailDto>(content);
            await _accountService.ChangeEmail(dto);
            return Ok();
        }

        /// <summary>
        ///  Request restore password to email
        /// </summary>
        /// <param name="content">Model request restore password</param>
        /// <returns></returns>
        [HttpPut]
        [AllowAnonymous]
        [Route("restorePassword")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        public async Task<IActionResult> RequestToRestorePassword(
            [FromBody] RequestToRestorePassModel content
        )
        {
            var dto = _mapper.Map<RequestRestorePasswordDto>(content);
            dto.RestorePasswordUrl = new UrlInformationDto(
                _appConfiguration.BaseApplicationAddress,
                Route,
                "restorePassword"
            );

            await _accountService.RequestRestorePassword(dto);
            return Redirect("https://google.com");
        }

        /// <summary>
        ///  Restore password
        /// </summary>
        /// <param name="content">Model restore password</param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("restorePassword")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        public async Task<IActionResult> RestorePassword([FromQuery] RestorePasswordModel content)
        {
            var dto = _mapper.Map<RestorePasswordDto>(content);
            await _accountService.RestorePassword(dto);
            return Ok();
        }

        /// <summary>
        /// Change user name
        /// </summary>
        /// <param name="content">model change</param>
        /// <returns>status code 200</returns>
        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("changeUserName")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        public async Task<IActionResult> ChangeUserName([FromQuery] string userName)
        {
            await _accountService.ChangeUserName(userName, HttpContext.Request);
            return Ok();
        }
        /// <summary>
        ///  Change password
        /// </summary>
        /// <param name="content">Model to change password</param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("changePassword")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        public async Task<IActionResult> ChangePassword([FromBody] PasswordChangeModel content)
        {
            var dto = _mapper.Map<ChangePasswordDto>(content);
            await _accountService.ChangePassword(dto, HttpContext.Request);
            return Ok();
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("getProfile")]
        [ProducesResponseType(typeof(JsonResponseContainer<LogInViewModel>), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        public async Task<IActionResult> GetProfile([FromQuery] string userName)
        {
            var retrieval = await _accountService.GetUserInfo(userName);
            var response = _mapper.Map<LogInResponseDto>(retrieval);
            return Ok(response);
        }
    }
}
