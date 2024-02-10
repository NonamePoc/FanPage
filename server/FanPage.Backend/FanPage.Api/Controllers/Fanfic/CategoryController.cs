using AutoMapper;
using FanPage.Api.JsonResponse;
using FanPage.Api.ViewModels.Fanfic;
using FanPage.Infrastructure.Interfaces.Fanfic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FanPage.Api.Controllers.Fanfic;

[ApiController]
[Route(Route)]
public class CategoryController : BaseController
{
    private const string Route = "v1/category";
    private readonly ICategory _category;
    private readonly IMapper _mapper;

    public CategoryController(ICategory category, IMapper mapper)
    {
        _category = category;
        _mapper = mapper;
    }

    /// <summary>
    ///  Update category from fanfic
    /// </summary>
    /// <param name="fanficId"> fanfic id</param>
    /// <param name="categoryName"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("update")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer<CategoryViewModel>), 200)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> UpdateCategory([FromQuery] int fanficId, [FromQuery] string categoryName)
    {
        var retrieval = await _category.SetCategoryAsync(fanficId, categoryName, HttpContext.Request);
        var response = _mapper.Map<CategoryViewModel>(retrieval);
        return Ok(response);
    }


    /// <summary>
    ///  Delete category from fanfic
    /// </summary>
    /// <param name="fanficId"> id fanfic</param>
    /// <param name="categoryId"> category fanfic id</param>
    /// <returns></returns>
    [HttpDelete]
    [Route("fanficCategory")]
    [ProducesResponseType(200)]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> DeleteCategory([FromQuery] int fanficId, [FromQuery] int categoryId)
    {
        await _category.DeleteCategoryAsync(fanficId, categoryId, HttpContext.Request);
        return Ok();
    }

    /// <summary>
    /// Get all category from fanfic
    /// </summary>
    /// <param name="fanficId">fanfic id</param>
    /// <returns></returns>
    [HttpGet]
    [Route("fanficCategory")]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> GetAllCategoryFanfic([FromQuery] int fanficId)
    {
        var tags = await _category.GetAllCategoryFanfic(fanficId);
        return Ok(tags);
    }
}