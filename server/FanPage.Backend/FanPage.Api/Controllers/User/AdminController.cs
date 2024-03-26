using AutoMapper;
using FanPage.Api.JsonResponse;
using FanPage.Api.Models.Admin;
using FanPage.Api.ViewModels.User;
using FanPage.Application.Admin;
using FanPage.Infrastructure.Interfaces.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FanPage.Api.Controllers.User;

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
    public async Task<IActionResult> User([FromQuery] string id)
    {
        await _admin.Delete(id);
        return Ok();
    }

    /// <summary>
    /// ban user
    /// </summary>
    /// <param name="ban">Model for baned user</param>
    /// <param name="request">user </param>
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
        var request = HttpContext.Request;
        var dto = _mapper.Map<BanDto>(ban);
        await _admin.Ban(dto, request);
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
    public async Task<IActionResult> Unban([FromQuery] string id)
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

    // /// <summary>
    // /// Info about user
    // /// </summary>
    // /// <param name="name">For know to find out user information</param>
    // /// <returns>Email, Phone Number, is the user in the ban(and if so, how much)</returns>
     [HttpPost]
     [Route("info")]
    [ProducesResponseType(typeof(JsonResponseContainer<UserInfoViewModel>), 200)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
     [ProducesResponseType(typeof(JsonResponseContainer), 500)]
     [Authorize(AuthenticationSchemes = "Bearer")]
     [Authorize(Roles = "Admin, Moderator")]
     public async Task<UserInfoResponseDto> Screach(string name)
     {
         var result = await _admin.Screach(name);
         return result;
     }


    /// <summary>
    /// Approve tag
    /// </summary>
    /// <param name="tagId"> tag id</param>
    /// <returns></returns>
    [HttpPut]
    [Route("approve")]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Admin, Moderator")]
    public async Task<IActionResult> ApproveTag([FromBody] int tagId)
    {
        await _admin.ApproveTag(tagId);
        return Ok();
    }

    [HttpGet]
    [Route("notapproved")]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Admin, Moderator")]
    public async Task<IActionResult> GetNotApprovedTags()
    {
        var response = await _admin.GetNotApprovedTags();
        return Ok(response);
    }
}
