using AutoMapper;
using FanPage.Api.JsonResponse;
using FanPage.Api.Models.Auth;
using FanPage.Api.ViewModels.User;
using FanPage.Application.Auth;
using FanPage.Infrastructure.Interfaces.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FanPage.Api.Controllers.User
{
    [ApiController]
    [Route(Route)]
    public sealed class AuthController : ControllerBase
    {
        private const string Route = "v1/auth";

        private readonly IAuth _authService;
        private readonly IMapper _mapper;

        public AuthController(IMapper mapper, IAuth authService)
        {
            _mapper = mapper;
            _authService = authService;
        }

        /// <summary>
        ///  Replace google token to jwt token
        /// </summary>
        /// <param name="googleToken"> googleToken</param>
        /// <returns></returns>
        [HttpPost]
        [Route("google-login")]
        [ProducesResponseType(typeof(JsonResponseContainer<LogInViewModel>), 200)]
        [ProducesResponseType(typeof(JsonResponseContainer), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        public async Task<IActionResult> GoogleLogin(string googleToken)
        {
            var response = await _authService.GoogleLogin(googleToken);
            return Ok(response);
        }

        /// <summary>
        ///  Log in system
        /// </summary>
        /// <param name="content">Model change password </param>
        /// <returns>Model data in account and token</returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        [ProducesResponseType(typeof(JsonResponseContainer<LogInViewModel>), 200)]
        [ProducesResponseType(typeof(JsonResponseContainer), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        public async Task<IActionResult> LogIn([FromBody] AuthModel content)
        {
            var dto = _mapper.Map<AuthDto>(content);
            var retrieval = await _authService.LogIn(dto);
            var response = _mapper.Map<LogInViewModel>(retrieval);
            return Ok(response);
        }

        /// <summary>
        ///  Log out system
        /// </summary>
        /// <returns>Status 200</returns>
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("logout")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        public async Task<IActionResult> LogOut()
        {
            await _authService.LogOut(HttpContext.Request);
            return Ok();
        }


        /// <summary>
        /// Refresh token
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("refreshToken")]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(JsonResponseContainer<RefreshTokenViewModel>), 200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        public async Task<IActionResult> RefreshToken()
        {
            var retval = await _authService.RefreshToken(HttpContext.Request);
            var response = _mapper.Map<RefreshTokenViewModel>(retval);
            return Ok(response);
        }
    }
}