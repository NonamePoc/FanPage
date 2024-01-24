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
public class ReviewController : BaseController
{
    private const string Route = "v1/review";
    private readonly IReview _review;
    private readonly IMapper _mapper;

    public ReviewController(IReview review, IMapper mapper)
    {
        _review = review;
        _mapper = mapper;
    }

    /// <summary>
    ///  Create review
    /// </summary>
    /// <param name="fanficId">id fanfic</param>
    /// <param name="reviewModel">review model</param>
    /// <returns></returns>
    [HttpPost]
    [Route("create")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer<ReviewViewModel>), 200)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> CreateReview([FromHeader] int fanficId, [FromBody] ReviewModel reviewModel)
    {
        var reviewDto = _mapper.Map<ReviewsDto>(reviewModel);
        var retrieval = await _review.CreateReviewAsync(fanficId, reviewDto, HttpContext.Request);
        var response = _mapper.Map<ReviewViewModel>(retrieval);
        return Ok(response);
    }


    /// <summary>
    ///  Update review
    /// </summary>
    /// <param name="fanficId">id fanfic</param>
    /// <param name="reviewModel">review model</param>
    /// <returns></returns>
    [HttpPut]
    [Route("update")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer<ReviewViewModel>), 200)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> UpdateReview([FromHeader] int fanficId, [FromBody] ReviewModel reviewModel)
    {
        var reviewDto = _mapper.Map<ReviewsDto>(reviewModel);
        var retrieval = await _review.UpdateReviewAsync(fanficId, reviewDto, HttpContext.Request);
        var response = _mapper.Map<ReviewViewModel>(retrieval);
        return Ok(response);
    }

    /// <summary>
    ///  Delete review
    /// </summary>
    /// <param name="fanficId">fanfic id</param>
    /// <returns></returns>
    [HttpDelete]
    [Route("delete")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer<ReviewViewModel>), 200)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteReview([FromHeader] int fanficId)
    {
        await _review.DeleteReviewAsync(fanficId, HttpContext.Request);
        return Ok();
    }

    /// <summary>
    /// Get all review
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("all")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer<ReviewViewModel>), 200)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> GetAllReview()
    {
        var retrieval = await _review.GetAllReview();
        var response = _mapper.Map<List<ReviewViewModel>>(retrieval);
        return Ok(response);
    }


    /// <summary>
    ///  Get review by user
    /// </summary>
    /// <param name="userName">user</param>
    /// <returns></returns>
    [HttpGet("allUserReview")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer<ReviewViewModel>), 200)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> GetAllReviewByUserName([FromHeader] string userName)
    {
        var retrieval = await _review.GetAllReviewByUserNameAsync(userName);
        var response = _mapper.Map<List<ReviewViewModel>>(retrieval);
        return Ok(response);
    }

    /// <summary>
    ///  Get review by fanfic
    /// </summary>
    /// <param name="fanficId"> id fanfic</param>
    /// <returns></returns>
    [HttpGet("allFanficReview")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer<ReviewViewModel>), 200)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> GetAllReviewByFanficId([FromHeader] int fanficId)
    {
        var retrieval = await _review.GetAllReviewByFanficIdAsync(fanficId);
        var response = _mapper.Map<List<ReviewViewModel>>(retrieval);
        return Ok(response);
    }
}