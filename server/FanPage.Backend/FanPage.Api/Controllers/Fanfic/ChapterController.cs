﻿using AutoMapper;
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
public class ChapterController : BaseController
{
    private const string Route = "v1/chapter";

    private readonly IChapter _chapter;
    private readonly IMapper _mapper;

    public ChapterController(IChapter fanficDetail, IMapper mapper)
    {
        _chapter = fanficDetail;
        _mapper = mapper;
    }

    /// <summary>
    ///  Create new chapter
    /// </summary>
    /// <param name="chapterModel"> chapter model </param>
    /// <returns></returns>
    [HttpPost]
    [Route("create")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer<ChapterViewModel>), 200)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> CreateChapter([FromBody] ChapterModel chapterModel)
    {
        var chapterDto = _mapper.Map<ChapterDto>(chapterModel);
        var retrieval = await _chapter.CreateChapterAsync(chapterDto, HttpContext.Request);
        var response = _mapper.Map<ChapterViewModel>(retrieval);
        return Ok(response);
    }

    /// <summary>
    ///  Update chapter
    /// </summary>
    /// <param name="chapterModel"> chapter model </param>
    /// <param name="chapterId"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("update")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer<ChapterViewModel>), 200)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> UpdateChapter(
        [FromBody] ChapterModel chapterModel,
        [FromQuery] int chapterId
    )
    {
        var chapterDto = _mapper.Map<ChapterDto>(chapterModel);
        var retrieval = await _chapter.UpdateChapterAsync(
            chapterId,
            chapterDto,
            HttpContext.Request
        );
        var response = _mapper.Map<ChapterViewModel>(retrieval);

        return Ok(response);
    }

    /// <summary>
    ///  delete chapter
    /// </summary>
    /// <param name="id"> chapter id </param>
    /// <param name="fanficId"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("delete")]
    [ProducesResponseType(200)]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> DeleteChapter([FromQuery] int id, [FromQuery] int fanficId)
    {
        await _chapter.DeleteChapterAsync(id, fanficId, HttpContext.Request);
        return Ok();
    }

    /// <summary>
    ///  Get chapter by id
    /// </summary>
    /// <param name="id">chapter id  </param>
    /// <param name="fanficId"> fanfic id</param>
    /// <returns>object chapter </returns>
    [HttpGet]
    [Route("chapterById")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer<ChapterViewModel>), 200)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    public async Task<IActionResult> GetChapterById([FromQuery] int id, [FromQuery] int fanficId)
    {
        var retrieval = await _chapter.GetByIdAsync(id, fanficId);
        var response = _mapper.Map<ChapterViewModel>(retrieval);
        return Ok(response);
    }

    /// <summary>
    /// get all chapter by fanfic id
    /// </summary>
    /// <param name="fanficId">fanfic id</param>
    /// <returns></returns>
    [HttpGet]
    [Route("fanficChapter")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(typeof(JsonResponseContainer<ChapterViewModel>), 200)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    public async Task<IActionResult> GetChapterByFanficId([FromQuery] int fanficId)
    {
        var retrieval = await _chapter.GetAllFanficChapter(fanficId);
        var response = _mapper.Map<List<ChapterViewModel>>(retrieval);
        return Ok(response);
    }
}