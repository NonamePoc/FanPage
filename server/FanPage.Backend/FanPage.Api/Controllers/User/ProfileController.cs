using AutoMapper;
using FanPage.Api.JsonResponse;
using FanPage.Api.Models.Account;
using FanPage.Application.Account;
using FanPage.Infrastructure.Interfaces.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FanPage.Api.Controllers.User
{
    [ApiController]
    [Route(Route)]
    public class ProfileController : BaseController
    {
        private const string Route = "v1/profile";
        private readonly IAccount _accountService;
        private readonly IMapper _mapper;

        public ProfileController(IAccount accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
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


    }
}
