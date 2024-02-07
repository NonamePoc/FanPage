using AutoMapper;
using FanPage.Api.JsonResponse;
using FanPage.Api.Models.Fanfic;
using FanPage.Api.ViewModels.Fanfic;
using FanPage.Application.Fanfic;
using FanPage.Infrastructure.Interfaces.Fanfic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FanPage.Api.Controllers.Fanfic;

[ApiController]
[Route(Route)]
public class TagController : BaseController
{
    private const string Route = "v1/tag";
    private readonly ITag _tag;
    private readonly IMapper _mapper;

    public TagController(ITag tag, IMapper mapper)
    {
        _tag = tag;
        _mapper = mapper;
    }

    /// <summary>
    /// Create tag 
    /// </summary>
    /// <param name="fanficId">id fanfic</param>
    /// <param name="tagModel">tag model</param>
    /// <returns></returns>
    [HttpPost]
    [Route("create")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer<TagViewModel>), 200)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> CreateTag([FromHeader] int fanficId, [FromBody] TagModel tagModel)
    {
        var tagDto = _mapper.Map<TagDto>(tagModel);
        var retrieval = await _tag.CreateTagAsync(fanficId, tagDto, HttpContext.Request);
        var response = _mapper.Map<TagViewModel>(retrieval);
        return Ok(response);
    }

    /// <summary>
    ///  Update tag from fanfic
    /// </summary>
    /// <param name="fanficId">fanfic id</param>
    /// <param name="nameTag">name tag</param>
    /// <returns></returns>
    [HttpPut]
    [Route("update")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer<TagViewModel>), 200)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> SetTag([FromHeader] int fanficId, [FromHeader] string? nameTag)
    {
        var retrieval = await _tag.SetTagAsync(fanficId, nameTag, HttpContext.Request);
        var response = _mapper.Map<TagViewModel>(retrieval);
        return Ok(response);
    }

    /// <summary>
    ///  Delete tag from fanfic
    /// </summary>
    /// <param name="fanficId"> id fanfic</param>
    /// <param name="tagId"> tag fanfic id</param>
    /// <returns></returns>
    [HttpDelete]
    [Route("fanficTag")]
    [ProducesResponseType(200)]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer<TagViewModel>), 200)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> DeleteTag([FromHeader] int fanficId, [FromHeader] string? tagName)
    {
        var retrieval = await _tag.DeleteTagFanficAsync(fanficId, tagName, HttpContext.Request);
        var response = _mapper.Map<TagViewModel>(retrieval);
        return Ok(response);
    }

    /// <summary>
    /// Get all tag
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("all")]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> GetAllTag()
    {
        var tags = await _tag.GetAllTagAsync();
        return Ok(tags);
    }

    [HttpDelete]
    [Route("delete")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> DeleteTag([FromHeader] int tagId)
    {
        await _tag.DeleteTagAsync(tagId, HttpContext.Request);
        return Ok();
    }

    /// <summary>
    /// Get all tag from fanfic
    /// </summary>
    /// <param name="fanficId">fanficid</param>
    /// <returns></returns>
    [HttpGet]
    [Route("fanficTag")]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> GetAllTagFanfic([FromHeader] int fanficId)
    {
        var tags = await _tag.GetAllTagFanfic(fanficId);
        return Ok(tags);
    }
}