using AutoMapper;
using FanPage.Api.JsonResponse;
using FanPage.Infrastructure.Interfaces.Fanfic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FanPage.Api.Controllers.Fanfic;

[ApiController]
[Route(Route)]
public class FanficDetailController : BaseController
{
    private const string Route = "v1/detail";

    private readonly IFanficDetail _fanficDetail;

    public FanficDetailController(IFanficDetail fanfic)
    {
        _fanficDetail = fanfic;
    }

    /// <summary>
    ///  Get last creation date fanfics
    /// </summary>
    /// <param name="count">fanfic list count</param>
    /// <returns>list object fanfic</returns>
    [HttpGet]
    [Route("lastCreationDateFanfics")]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    public async Task<IActionResult> GetLastCreationDateFanfics([FromQuery] int count)
    {
        var fanfic = await _fanficDetail.GetLastCreationDateFanficsAsync(count, HttpContext.Request);
        return Ok(fanfic);
    }


    /// <summary>
    ///  Get top rating fanfics
    /// </summary>
    /// <param name="count">fanfic list count</param>
    /// <returns>list object fanfic</returns>
    [HttpGet]
    [Route("topRatingFanfics")]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    public async Task<IActionResult> GetTopRatingFanfics([FromQuery] int count)
    {
        var fanfic = await _fanficDetail.GetTopRatingFanficsAsync(count, HttpContext.Request);
        return Ok(fanfic);
    }


    /// <summary>
    /// rating fanfic
    /// </summary>
    /// <param name="fanficId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("ratingFanfic")]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    public async Task<IActionResult> GetAverageRating([FromQuery] int fanficId)
    {
        var rating = await _fanficDetail.GetAverageRatingAsync(fanficId);
        return Ok(rating);
    }

    /// <summary>
    /// Get all fanfic
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("getAll")]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    public async Task<IActionResult> GetAll([FromQuery] int offset)
    {
        var fanfic = await _fanficDetail.GetAllAsync(offset);
        return Ok(fanfic);
    }

    /// <summary>
    /// Get by id fanfic
    /// </summary>
    /// <param name="id">fanfic id</param>
    /// <returns></returns>
    [HttpGet]
    [Route("getById")]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> GetById([FromQuery] int id)
    {
        var fanfic = await _fanficDetail.GetByIdAsync(id);
        return Ok(fanfic);
    }

    /// <summary>
    ///  Get by Username
    /// </summary>
    /// <param name="authorName"> UserName Author</param>
    /// <returns></returns>
    [HttpGet]
    [Route("byAuthorName")]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> GetByAuthorName([FromQuery] string authorName, [FromQuery] int offset)
    {
        var fanfic = await _fanficDetail.GetByAuthorNameAsync(authorName, offset);
        return Ok(fanfic);
    }


    /// <summary>
    ///  Search fanfic 
    /// </summary>
    /// <param name="searchString"> name fanfic and tag fanfic and username author </param>
    /// <param name="originalFandom">Check whether the fanfic should be from the original author or not</param>
    /// <returns></returns>
    [HttpGet]
    [Route("search")]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    public async Task<IActionResult> Search([FromQuery] string searchString, [FromQuery] bool originalFandom)
    {
        var fanfics = await _fanficDetail.SearchAsync(searchString, originalFandom);
        return Ok(fanfics);
    }

    /// <summary>
    ///  Update photo fanfic
    /// </summary>
    /// <param name="fanficId">id fanfic</param>
    /// <param name="imageFanfic">file</param>
    /// <returns>status code 200</returns>
    [HttpPost]
    [Route("updateAvatar")]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> ChangeAvatar(int fanficId, IFormFile imageFanfic)
    {
        await _fanficDetail.ChangeAvatar(fanficId, imageFanfic, HttpContext.Request);
        return Ok();
    }
}