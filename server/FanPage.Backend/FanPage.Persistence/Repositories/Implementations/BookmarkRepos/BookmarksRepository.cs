using AutoMapper;
using FanPage.Application.UserProfile;
using FanPage.Common.Interfaces;
using FanPage.Domain.Entities.Identity;
using FanPage.Persistence.Context;
using FanPage.Persistence.Repositories.Interfaces.IBookmark;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace FanPage.Persistence.Repositories.Implementations.BookmarkRepos
{
    public class BookmarksRepository : IBookmarkRepository
    {
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;
        private readonly IJwtTokenManager _jwtTokenManager;
        private readonly FanficContext _fanficContext;
        public BookmarksRepository(IMapper mapper, UserContext userContext, IJwtTokenManager jwtTokenManager, FanficContext fanficContext)
        {
            _mapper = mapper;
            _userContext = userContext;
            _jwtTokenManager = jwtTokenManager;
            _fanficContext = fanficContext;
        }
        public async Task<List<BookmarkDto>> BookmarkList(HttpRequest request)
        {
            var userId = _jwtTokenManager.GetUserIdFromToken(request);
            var marks = await _userContext.Bookmarks
            .Where(user => user.UserId == userId)
            .ToListAsync();
            return _mapper.Map<List<BookmarkDto>>(marks);
        }

        public async Task<bool> Add(HttpRequest request, string titelName)
        {
            var userId = _jwtTokenManager.GetUserIdFromToken(request);
            var fanficExists = await _fanficContext.Fanfic.AnyAsync(f => f.Title == titelName);
            var bookmarkExists = await _userContext.Bookmarks.AnyAsync(marks => marks.UserId == userId && marks.TitelName == titelName);
            return fanficExists ? !bookmarkExists && await AddNewBookmark(userId, titelName) : false;
        }

        private async Task<bool> AddNewBookmark(string userId, string titelName)
        {
            var newMarks = new Bookmark
            {
                UserId = userId,
                TitelName = titelName,
                Stage = "Reading"
            };

            _userContext.Bookmarks.Add(newMarks);
            await _userContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(HttpRequest request, string titelName)
        {
            var userId = _jwtTokenManager.GetUserIdFromToken(request);
            var remove = await _userContext.Bookmarks
            .FirstOrDefaultAsync(marks => marks.UserId == userId && marks.TitelName == titelName);
            _userContext.Bookmarks.Remove(remove);
            _userContext.SaveChanges();
            return true;
        }
    }
}


