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

        public async Task Add(HttpRequest request, int titelId)
        {
            var userId = _jwtTokenManager.GetUserIdFromToken(request);
            var fanficExists = await _fanficContext.Fanfic.AnyAsync(f => f.FanficId == titelId);
            var bookmarkExists = await _userContext.Bookmarks.AnyAsync(marks => marks.UserId == userId && marks.TitelId == titelId);

            if (fanficExists && !bookmarkExists)
            {
                await AddNewBookmark(userId, titelId);
            }
        }

        private async Task AddNewBookmark(string userId, int titelId)
        {
            var newMarks = new Bookmark
            {
                UserId = userId,
                TitelId = titelId,
                Stage = "Reading"
            };

            _userContext.Bookmarks.Add(newMarks);
            await _userContext.SaveChangesAsync();
        }

        public async Task Delete(HttpRequest request, int titelId)
        {
            var userId = _jwtTokenManager.GetUserIdFromToken(request);
            var remove = await _userContext.Bookmarks
            .FirstOrDefaultAsync(marks => marks.UserId == userId && marks.TitelId == titelId);
            _userContext.Bookmarks.Remove(remove);
            await _userContext.SaveChangesAsync();
        }
    }
}


