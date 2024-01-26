using FanPage.Application.UserProfile;
using FanPage.Common.Interfaces;
using FanPage.Domain.Fanfic.Repos.Interfaces;
using FanPage.Domain.User.Repos.Interfaces;
using FanPage.Infrastructure.Interfaces.User;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Implementations.User
{
    public class BookmarkService : IBookmark
    {
        private readonly IBookmarkRepository _bookmarkRepository;
        private readonly IJwtTokenManager _jwtTokenManager;
        private readonly IFanficRepository _fanficRepository;

        public BookmarkService(IBookmarkRepository bookmarkRepository, IJwtTokenManager jwtTokenManager,
            IFanficRepository fanficRepository)
        {
            _bookmarkRepository = bookmarkRepository;
            _jwtTokenManager = jwtTokenManager;
            _fanficRepository = fanficRepository;
        }

        public async Task<bool> Add(HttpRequest request, int fanficId)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            if (userName == null) throw new Exception("User not found");
            var fanfic = await _fanficRepository.GetByIdAsync(fanficId);
            if (fanfic == null) throw new Exception("Fanfic not found");
            await _bookmarkRepository.Add(userName, fanficId);
            return true;
        }

        public async Task<List<BookmarkDto>> BookmarkList(HttpRequest request)
        {
            var userId = _jwtTokenManager.GetUserIdFromToken(request);
            var list = await _bookmarkRepository.BookmarkList(userId);
            return list;
        }

        public async Task<bool> Delete(HttpRequest request, int fanficId)
        {
            var userId = _jwtTokenManager.GetUserIdFromToken(request);
            await _bookmarkRepository.Delete(userId, fanficId);
            return true;
        }
    }
}