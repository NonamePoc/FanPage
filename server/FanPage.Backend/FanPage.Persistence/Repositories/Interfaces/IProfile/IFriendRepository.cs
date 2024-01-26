using FanPage.Application.UserProfile;
using FanPage.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Persistence.Repositories.Interfaces.IProfile
{
    public interface IFriendRepository
    {
        Task<FriendRequestDto> AddFriend(HttpRequest request, string friendName);
        Task<bool> RemoveFriend(HttpRequest request, string friendName);
        Task AcceptFriend(HttpRequest request, string friendName);
        Task<List<FriendDto>> FriendsList(HttpRequest request);
        Task<bool> CancelSend(HttpRequest request, string friendName);
        Task<List<FriendRequestDto>> GetFriendRequests(HttpRequest request);

        Task<List<FriendRequestDto>> GetUserRequests(HttpRequest request);
    }
}
