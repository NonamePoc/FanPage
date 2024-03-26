using AutoMapper;
using FanPage.Application.Fanfic;
using FanPage.Application.UserProfile;
using FanPage.Domain.Account.Context;
using FanPage.Domain.Account.Entities;
using FanPage.Domain.Account.Repos.Interfaces;
using FanPage.Domain.Fanfic.Context;
using FanPage.Domain.Fanfic.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FanPage.Domain.Account.Repos.Impl
{
    public class BookmarksRepository : IBookmarkRepository
    {

        private readonly UserContext _userContext;
        private readonly IFanficRepository _fanficRepository; 

        public BookmarksRepository(UserContext userContext, IFanficRepository fanficRepository)
        {
            _userContext = userContext;
            _fanficRepository = fanficRepository;


        }

        public async Task<List<FanficDto>> BookmarkList(string userId)
        {
            var bookmarks = await _userContext.Bookmarks
            .Where(w => w.UserId == userId)
            .Select(w => w.FanficReadingId)
            .ToListAsync();

            var bookmarkDtos = new List<FanficDto>();

            foreach (var bookmarkId in bookmarks)
            {
                var fanficBookmark = await _fanficRepository.GetByIdAsync(bookmarkId);
                bookmarkDtos.Add(fanficBookmark);
            }

            return bookmarkDtos;
            
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