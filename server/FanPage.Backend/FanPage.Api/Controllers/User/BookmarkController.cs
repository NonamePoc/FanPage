using AutoMapper;
using FanPage.Api.JsonResponse;
using FanPage.Api.ViewModels.User;
using FanPage.Application.Admin;
using FanPage.Application.UserProfile;
using FanPage.Domain.Entities.Identity;
using FanPage.Infrastructure.Interfaces.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FanPage.Api.Controllers.User
{
    [ApiController]
    [Route(Route)]
    public class BookmarkController : BaseController
    {
        private const string Route = "v1/bookmark";
        private readonly IBookmark _bookmark;
        private readonly IMapper _mapper;
        public BookmarkController(IBookmark bookmark, IMapper mapper) 
        {
            _bookmark = bookmark;
            _mapper = mapper;

        }
        /// <summary>
        /// Add Bookmark
        /// </summary>
        /// <param name="id">id of titel wich user want to add to list of bookmarks</param>
        /// <returns>status 200</returns>
        [HttpPost]
        [Route("Add")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Add(int titelId)
        {
            await _bookmark.Add(HttpContext.Request, titelId);
            return Ok();
        }
        /// <summary>
        /// Delete Bookmark
        /// </summary>
        /// <param name="id">id of titel wich user want to remove from list of bookmarks</param>
        /// <returns>status 200</returns>
        [HttpDelete]
        [Route("Delete")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Delete(int titelId)
        {
            await _bookmark.Delete(HttpContext.Request, titelId);
            return Ok();
        }
        /// <summary>
        /// Bookmarks List
        /// </summary>
        /// <returns>list of bookmarkss</returns>
        [HttpGet]
        [Route("List")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
        [ProducesResponseType(typeof(JsonResponseContainer), 500)]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> List()
        {
            var list = await _bookmark.BookmarkList(HttpContext.Request);
            return Ok(list);
        }
    }
}
