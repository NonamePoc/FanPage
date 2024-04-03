using FanPage.Application.UserProfile;

namespace FanPage.Domain.Account.Repos.Interfaces;

public interface IFriendRepository
{
    Task<bool> AddFriend(string userName, string friendName, string userId, string friendId);
    Task<bool> RemoveFriend(string userName, string friendName);
    Task AcceptFriend(string userName, string friendName, string userId, string friendId);
    Task<List<FriendDto>> FriendsList(string userName);
    Task<bool> CancelSend(string userName, string friendName);
    Task<List<FriendRequestDto>> GetFriendRequests(string userName);
    Task<List<FriendRequestDto>> GetUserRequests(string friendName);

    Task<bool> GetUserFriend(string userName, string friendName);
}