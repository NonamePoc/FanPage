using FanPage.Application.UserProfile;
using FanPage.Common.Interfaces;
using FanPage.Infrastructure.Interfaces.User;
using FanPage.Persistence.Repositories.Interfaces.IBookmark;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Implementations.User
{
    public class BookmarkService : IBookmark
    {
        private readonly IBookmarkRepository _bookmarkRepository;
        public BookmarkService(IBookmarkRepository bookmarkRepository)
        {
            _bookmarkRepository = bookmarkRepository;

        }

        public async Task<bool> Add(HttpRequest request, string titelName)
        {
            await _bookmarkRepository.Add(request, titelName);
            return true;
        }

        public async Task<List<BookmarkDto>> BookmarkList(HttpRequest request)
        {
            var list = await _bookmarkRepository.BookmarkList(request);
            return list;
        }

        public async Task<bool> Delete(HttpRequest request, string titelName)
        {
            await _bookmarkRepository.Delete(request, titelName);
            return true;
        }
    }
}
