using FanPage.Application.UserProfile;
using Microsoft.AspNetCore.Http;

namespace FanPage.Persistence.Repositories.Interfaces.IBookmark
{
    public interface IBookmarkRepository
    {
        Task<List<BookmarkDto>> BookmarkList(HttpRequest request);

        Task<bool> Add(HttpRequest request, string titelName);

        Task<bool> Delete(HttpRequest request, string titelName);

    }
}
