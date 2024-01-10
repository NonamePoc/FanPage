using AutoMapper;
using Azure.Core;
using FanPage.Application.UserProfile;
using FanPage.Common.Interfaces;
using FanPage.Domain.Entities.Identity;
using FanPage.Persistence.Context;
using FanPage.Persistence.Repositories.Interfaces.IProfile;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace FanPage.Persistence.Repositories.Implementations.ProfileRepos
{
    public class FriendRepository : IFriendRepository
    {
        private readonly UserContext _userContext;
        private readonly IMapper _mapper;
        private readonly IJwtTokenManager _jwtTokenManager;
        public FriendRepository(UserContext userContext, IMapper mapper, IJwtTokenManager jwtTokenManager)
        {
            _userContext = userContext;
            _mapper = mapper;
            _jwtTokenManager = jwtTokenManager;
        }
        public async Task<List<FriendDto>> FriendsList(HttpRequest request)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            var friendRequests = _userContext.Friendships
                .Where(fr => fr.UserName == userName)
                .ToList();

            return _mapper.Map<List<FriendDto>>(friendRequests);
        }

        public async Task<FriendRequestDto> AddFriend(HttpRequest request, string friendName)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            var existingRequest = _userContext.FriendRequests
            .FirstOrDefault(fr => fr.UserName == userName && fr.FriendName == friendName);

            if (existingRequest != null) return null;
            var newFriendRequest = new FriendRequest
            {
                UserName = userName,
                FriendName = friendName,
                IsApproving = false
            };
            _userContext.FriendRequests.Add(newFriendRequest);
            _userContext.SaveChanges();
            return _mapper.Map<FriendRequestDto>(newFriendRequest);
        }

        public async Task<bool> RemoveFriend(HttpRequest request, string friendName)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            var friendShip = _userContext.Friendships
           .FirstOrDefault(fr => fr.UserName == userName && fr.FriendName == friendName);

            _userContext.Friendships.Remove(friendShip);
            _userContext.SaveChanges();
            return true;
        }

        public async Task AcceptFriend(HttpRequest request, string friendName)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            var friendRequest = await _userContext.FriendRequests
                .FirstOrDefaultAsync(fr => fr.UserName == friendName && fr.FriendName == userName);
            _userContext.FriendRequests.Remove(friendRequest);

            var friendship = new Friendship
            {
                UserName = userName,
                FriendName = friendName
            };
            _userContext.Friendships.Add(friendship);
            _userContext.SaveChanges();

        }

        public async Task<bool> CancelSend(HttpRequest request, string friendName)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            var friendRequest = _userContext.FriendRequests
           .FirstOrDefault(fr => fr.UserName == userName && fr.FriendName == friendName);

            _userContext.FriendRequests.Remove(friendRequest);
            _userContext.SaveChanges();
            return true;

        }

        public async Task<List<FriendRequestDto>> GetFriendRequests(HttpRequest request)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            var friendRequests = _userContext.FriendRequests
                .Where(fr => fr.UserName == userName)
                .ToList();

            return _mapper.Map<List<FriendRequestDto>>(friendRequests);
        }
        public async Task<List<FriendRequestDto>> GetUserRequests(HttpRequest request)
        {
            var friendName = _jwtTokenManager.GetUserNameFromToken(request);

            var receivedFriendRequests = _userContext.FriendRequests
                .Where(fr => fr.FriendName == friendName)
                .ToList();

            return _mapper.Map<List<FriendRequestDto>>(receivedFriendRequests);
        }


    }

}
