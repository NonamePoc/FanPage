using FanPage.Application.UserProfile;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Interfaces.User
{
    public interface IFriend
    {
        Task<FriendRequestDto> AddFriend(HttpRequest request, string friendName);
        Task<bool> RemoveFriend(HttpRequest request, string friendName);
        Task<List<FriendDto>> FriendsList(HttpRequest request);
        Task<List<FriendRequestDto>> GetFriendRequests(HttpRequest request);
        Task<bool> CancelSend(HttpRequest request, string friendName);
        Task<List<FriendRequestDto>> GetUserRequests(HttpRequest request);
        Task AcceptFriend(HttpRequest request, string friendName);
    }
}
