using FanPage.Application.UserProfile;
using FanPage.Common.Interfaces;
using FanPage.Infrastructure.Interfaces.User;
using FanPage.Persistence.Repositories.Interfaces.IBookmark;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace FanPage.Infrastructure.Implementations.User
{
    public class BookmarkService : IBookmark
    {
        private readonly IBookmarkRepository _bookmarkRepository;
        public BookmarkService(IBookmarkRepository bookmarkRepository)
        {
            _bookmarkRepository = bookmarkRepository;

        }

        public async Task<bool> Add(HttpRequest request, int titelId)
        {
            await _bookmarkRepository.Add(request, titelId);
            return true;
        }

        public async Task<List<BookmarkDto>> BookmarkList(HttpRequest request)
        {
            var list = await _bookmarkRepository.BookmarkList(request);
            return list;
        }

        public async Task<bool> Delete(HttpRequest request, int titelId)
        {
            await _bookmarkRepository.Delete(request, titelId);
            return true;
        }
    }
}
