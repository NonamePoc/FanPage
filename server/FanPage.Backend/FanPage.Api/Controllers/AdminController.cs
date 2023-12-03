using AutoMapper;
using FanPage.Api.JsonResponse;
using FanPage.Api.Models.Admin;
using FanPage.Api.ViewModels;
using FanPage.Application.Admin;
using FanPage.Infrastructure.Implementations;
using FanPage.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FanPage.Api.Controllers
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

        [HttpDelete]
        [Route("user")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> User(DeleteModel deletId)
        {
            var dto = _mapper.Map<DeleteDto>(deletId);
            await _admin.Delete(dto);
            return Ok();

        }
        [HttpPut]
        [Route("ban")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> Ban(BanModel ban)
        {
            var dto = _mapper.Map<BanDto>(ban);
            await _admin.Ban(dto);
            return Ok();

        }
        [HttpPut]
        [Route("unban")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> Unban(UnbanModel unbanId)
        {
            var dto = _mapper.Map<UnbanDto>(unbanId);
            await _admin.Unban(dto);
            return Ok();

        }
        [HttpPut]
        [Route("role")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeRole(ChangeRoleModel user)
        {
            var dto = _mapper.Map<ChangeRoleDto>(user);
            await _admin.ChangeRole(dto);
            return Ok();
        }
        [HttpPost]
        [Route("info")]
        [ProducesResponseType(typeof(JsonResponseContainer<UserInfoViewModel>), 200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> UserInfo([FromBody] UserInfoModel user)
        {
            var dto = _mapper.Map<UserInfoDto>(user);
            var retval = await _admin.GetUserInformation(dto);
            var response = _mapper.Map<UserInfoViewModel>(retval);
            return Ok(response);
        }
    }
}