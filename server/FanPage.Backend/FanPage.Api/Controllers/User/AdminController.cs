using AutoMapper;
using FanPage.Api.JsonResponse;
using FanPage.Api.Models.Admin;
using FanPage.Api.ViewModels.User;
using FanPage.Application.Admin;
using FanPage.Infrastructure.Implementations;
using FanPage.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FanPage.Api.Controllers.User
{
    [ApiController]
    [Route(Route)]
    public class AdminController : ControllerBase
    {
        private const string Route = "v1/admin";
        private readonly IAdmin _admin;
        private readonly IMapper _mapper;
        public AdminController(IAdmin admin, IMapper mapper)
        {
            _admin = admin;
            _mapper = mapper;
        }
        /// <summary>
        /// delete user
        /// </summary>
        /// <param name="id">for deleting user</param>
        /// <returns>Status 200</returns>
        [HttpDelete]
        [Route("user")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> User([FromHeader] string id)
        {
            await _admin.Delete(id);
            return Ok();

        }
        /// <summary>
        /// ban user
        /// </summary>
        /// <param name="ban">Model for baned user</param>
        /// <returns>Number of days for which you were banned</returns>
        [HttpPut]
        [Route("ban")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> Ban([FromBody] BanModel ban)
        {
            var dto = _mapper.Map<BanDto>(ban);
            await _admin.Ban(dto);
            return Ok();

        }
        /// <summary>
        /// unban user
        /// </summary>
        /// <param name="id">for unbaned user</param>
        /// <returns>Status 200</returns>
        [HttpPut]
        [Route("unban")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> Unban([FromBody] string id)
        {
            await _admin.Unban(id);
            return Ok();

        }
        /// <summary>
        /// Change user role
        /// </summary>
        /// <param name="changeRole">Model for change user role</param>
        /// <returns>new user role</returns>
        [HttpPut]
        [Route("role")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeRole([FromBody] ChangeRoleModel changeRole)
        {
            var dto = _mapper.Map<ChangeRoleDto>(changeRole);
            await _admin.ChangeRole(dto);
            return Ok();
        }
        /// <summary>
        /// Info about user who get ban
        /// </summary>
        /// <returns>is the user in the ban(and if so, how much)</returns>
        [HttpGet]
        [Route("baninfo")]
        [ProducesResponseType(typeof(JsonResponseContainer<UserInfoViewModel>), 200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> BanUserInfo()
        {
            var result = await _admin.GetUserInBan();
            return Ok(result);
        }
        /// <summary>
        /// Info about user
        /// </summary>
        /// <returns>all other info about user from data base</returns>
        [HttpGet]
        [Route("info")]
        [ProducesResponseType(typeof(JsonResponseContainer<UserInfoViewModel>), 200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> UserInfo()
        {
            var result = await _admin.AllUsers();
            return Ok(result);
        }
    }
}