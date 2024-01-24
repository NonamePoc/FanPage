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

    private readonly IMapper _mapper;

    public FanficDetailController(IFanficDetail fanfic, IMapper mapper)
    {
        _fanficDetail = fanfic;
        _mapper = mapper;
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
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> GetAverageRating([FromHeader] int fanficId)
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
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> GetAll()
    {
        var fanfic = await _fanficDetail.GetAllAsync();
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
    public async Task<IActionResult> GetById([FromHeader] int id)
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
    public async Task<IActionResult> GetByAuthorId([FromHeader] string authorName)
    {
        var fanfic = await _fanficDetail.GetByAuthorNameAsync(authorName);
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
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> Search([FromQuery] string searchString, [FromQuery] bool originalFandom)
    {
        var fanfics = await _fanficDetail.SearchAsync(searchString, originalFandom);
        return Ok(fanfics);
    }
}