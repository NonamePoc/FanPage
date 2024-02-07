using FanPage.Application.UserProfile;

namespace FanPage.Domain.Account.Repos.Interfaces;

public interface IFriendRepository
{
    Task<FriendRequestDto> AddFriend(string userId, string friendId);
    Task<bool> RemoveFriend(string userId, string friendId);
    Task AcceptFriend(string userId, string friendId);
    Task<List<FriendDto>> FriendsList(string userName);
    Task<bool> CancelSend(string userId, string friendId);
    Task<List<FriendRequestDto>> GetFriendRequests(string userId);
    Task<List<FriendRequestDto>> GetUserRequests(string friendId);
}