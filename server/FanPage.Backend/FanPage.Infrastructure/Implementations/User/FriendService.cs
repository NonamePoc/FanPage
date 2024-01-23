using AutoMapper;
using FanPage.Application.UserProfile;
using FanPage.Common.Interfaces;
using FanPage.Infrastructure.Interfaces.User;
using FanPage.Persistence.Repositories.Interfaces.IProfile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FanPage.Infrastructure.Implementations.User
{
    public class FriendService : IFriend
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IJwtTokenManager _jwtTokenManager;
        private readonly UserManager<Domain.Entities.Identity.User> _userManager;
        public FriendService(IFriendRepository friendRepository, IJwtTokenManager jwtTokenManager, UserManager<Domain.Entities.Identity.User> userManager)
        {
            _friendRepository = friendRepository;
            _jwtTokenManager = jwtTokenManager;
            _userManager = userManager;
        }

        public async Task<FriendRequestDto> AddFriend(HttpRequest request, string friendName)
        {
            _friendRepository.AddFriend(request, friendName);
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            return new FriendRequestDto
            { UserName = userName, FriendName = friendName};

        }

        public async Task<List<FriendDto>> FriendsList(HttpRequest request)
        {
            var list = await _friendRepository.FriendsList(request);
            return list;
        }
        public async Task<bool> RemoveFriend(HttpRequest request, string friendName)
        {
            await _friendRepository.RemoveFriend(request, friendName);
            return true;
        }
        public async Task<List<FriendRequestDto>> GetFriendRequests(HttpRequest request)
        {
            var list = await _friendRepository.GetFriendRequests(request);
            return list;


        }

        public async Task<bool> CancelSend(HttpRequest request, string friendName)
        {
            await _friendRepository.CancelSend(request, friendName);
            return true;
        }

        public async Task<List<FriendRequestDto>> GetUserRequests(HttpRequest request)
        {
            var list = await _friendRepository.GetUserRequests(request);

            return list;
        }
        public async Task<bool> AcceptFriend(HttpRequest request, string friendName)
        {
            await _friendRepository.AcceptFriend(request, friendName);
            return true;
        }
    }
}
