using FanPage.Application.UserProfile;
using FanPage.Common.Interfaces;
using FanPage.Domain.Account.Repos.Interfaces;
using FanPage.Infrastructure.Interfaces.User;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Implementations.User
{
    public class FriendService : IFriend
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IJwtTokenManager _jwtTokenManager;

        public FriendService(IFriendRepository friendRepository, IJwtTokenManager jwtTokenManager)
        {
            _friendRepository = friendRepository;
            _jwtTokenManager = jwtTokenManager;
        }

        public async Task<FriendRequestDto> AddFriend(HttpRequest request, string friendName)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            await _friendRepository.AddFriend(userName, friendName);
            return new FriendRequestDto
                { UserName = userName, FriendName = friendName };
        }


        public async Task<List<FriendDto>> FriendsList(HttpRequest request)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            var list = await _friendRepository.FriendsList(userName);
            return list;
        }

        public async Task<bool> RemoveFriend(HttpRequest request, string friendId)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            await _friendRepository.RemoveFriend(userName, friendId);
            return true;
        }

        public async Task<List<FriendRequestDto>> GetFriendRequests(HttpRequest request)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            var list = await _friendRepository.GetFriendRequests(userName);
            return list;
        }

        public async Task<bool> CancelSend(HttpRequest request, string friendName)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            await _friendRepository.CancelSend(userName, friendName);
            return true;
        }

        public async Task<List<FriendRequestDto>> GetUserRequests(HttpRequest request)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            var list = await _friendRepository.GetUserRequests(userName);

            return list;
        }

        public async Task<bool> AcceptFriend(HttpRequest request, string friendName)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            await _friendRepository.AcceptFriend(userName, friendName);
            return true;
        }
    }
}