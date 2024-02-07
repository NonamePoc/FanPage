using AutoMapper;
using FanPage.Application.UserProfile;
using FanPage.Domain.Account.Context;
using FanPage.Domain.Account.Entities;
using FanPage.Domain.Account.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FanPage.Domain.Account.Repos.Impl
{
    public class BookmarksRepository : IBookmarkRepository
    {
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public BookmarksRepository(IMapper mapper, UserContext userContext)
        {
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<List<BookmarkDto>> BookmarkList(string userId)
        {
            var bookmarks = await _userContext.Bookmarks.Where(w => w.UserId == userId).ToListAsync();
            return _mapper.Map<List<BookmarkDto>>(bookmarks);
        }

        public async Task<bool> Add(string userId, int fanficId)
        {
            var bookmarkExists =
                await _userContext.Bookmarks.Where(w => w.UserId == userId && w.FanficReadingId == fanficId)
                    .ToListAsync();

            if (bookmarkExists != null && bookmarkExists.Count > 0)
            {
                throw new Exception("Bookmark already exists");
            }

            await _userContext.Bookmarks.AddAsync(new Bookmark
            {
                UserId = userId,
                FanficReadingId = fanficId
            });

            await _userContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(string userId, int fanficId)
        {
            var remove = await _userContext.Bookmarks
                .FirstOrDefaultAsync(marks => marks.UserId == userId && marks.FanficReadingId == fanficId);
            if (remove == null) throw new Exception("Bookmark not found");
            _userContext.Bookmarks.Remove(remove);
            await _userContext.SaveChangesAsync();
            return true;
        }
    }
}