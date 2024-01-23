using FanPage.Application.UserProfile;
using Microsoft.AspNetCore.Http;

namespace FanPage.Persistence.Repositories.Interfaces.IBookmark
{
    public interface IBookmarkRepository
    {
        Task<List<BookmarkDto>> BookmarkList(HttpRequest request);

        Task Add(HttpRequest request, int titelId);

        Task Delete(HttpRequest request, int titelId);

    }
}
