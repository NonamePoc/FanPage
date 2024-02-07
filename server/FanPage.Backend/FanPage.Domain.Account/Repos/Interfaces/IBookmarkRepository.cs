using FanPage.Application.UserProfile;

namespace FanPage.Domain.Account.Repos.Interfaces;

public interface IBookmarkRepository
{
    Task<List<BookmarkDto>> BookmarkList(string userId);

    Task<bool> Add(string userId, int fanficId);
    Task<bool> Delete(string userId, int fanficId);
}