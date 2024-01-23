using AutoMapper;
using Azure.Core;
using FanPage.Application.UserProfile;
using FanPage.Common.Interfaces;
using FanPage.Domain.Entities.Identity;
using FanPage.Persistence.Context;
using FanPage.Persistence.Repositories.Interfaces.IProfile;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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
            var friendRequests = await _userContext.Friendships
                .Where(fr => fr.UserName == userName)
                .ToListAsync();

            return _mapper.Map<List<FriendDto>>(friendRequests);
        }

        public async Task<FriendRequestDto> AddFriend(HttpRequest request, string friendName)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            var existingRequest = await _userContext.FriendRequests
            .FirstOrDefaultAsync(fr => fr.UserName == userName && fr.FriendName == friendName);

            if (existingRequest != null) return null;
            var newFriendRequest = new FriendRequest
            {
                UserName = userName,
                FriendName = friendName,
                IsApproving = false
            };
            _userContext.FriendRequests.Add(newFriendRequest);
            await _userContext.SaveChangesAsync();
            return _mapper.Map<FriendRequestDto>(newFriendRequest);
        }

        public async Task<bool> RemoveFriend(HttpRequest request, string friendName)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            var friendShip = await _userContext.Friendships
           .FirstOrDefaultAsync(fr => fr.UserName == userName && fr.FriendName == friendName);

            _userContext.Friendships.Remove(friendShip);
            await _userContext.SaveChangesAsync();
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
            await _userContext.SaveChangesAsync();

        }

        public async Task<bool> CancelSend(HttpRequest request, string friendName)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            var friendRequest = await _userContext.FriendRequests
           .FirstOrDefaultAsync(fr => fr.UserName == userName && fr.FriendName == friendName);

            _userContext.FriendRequests.Remove(friendRequest);
            await _userContext.SaveChangesAsync();
            return true;

        }

        public async Task<List<FriendRequestDto>> GetFriendRequests(HttpRequest request)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            var friendRequests = await _userContext.FriendRequests
                .Where(fr => fr.UserName == userName)
                .ToListAsync();

            return _mapper.Map<List<FriendRequestDto>>(friendRequests);
        }
        public async Task<List<FriendRequestDto>> GetUserRequests(HttpRequest request)
        {
            var friendName = _jwtTokenManager.GetUserNameFromToken(request);

            var receivedFriendRequests = await _userContext.FriendRequests
                .Where(fr => fr.FriendName == friendName)
                .ToListAsync();

            return _mapper.Map<List<FriendRequestDto>>(receivedFriendRequests);
        }


    }

}
