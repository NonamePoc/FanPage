using AutoMapper;
using FanPage.Application.UserProfile;
using FanPage.Domain.Account.Context;
using FanPage.Domain.Account.Entities;
using FanPage.Domain.Account.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FanPage.Domain.Account.Repos.Impl
{
    public class FriendRepository : IFriendRepository
    {
        private readonly UserContext _userContext;
        private readonly IMapper _mapper;

        public FriendRepository(UserContext userContext, IMapper mapper)
        {
            _userContext = userContext;
            _mapper = mapper;
        }

        public async Task<List<FriendDto>> FriendsList(string userId)
        {
            var friendRequests = await _userContext.Friendships
                .Where(fr => fr.UserId == userId)
                .ToListAsync();

            return _mapper.Map<List<FriendDto>>(friendRequests);
        }

        public async Task<FriendRequestDto> AddFriend(string userId, string friendId)
        {
            var existingRequest = await _userContext.FriendRequests
                .FirstOrDefaultAsync(fr => fr.UserId == userId && fr.FriendId == friendId);

            if (existingRequest != null) return null;
            var newFriendRequest = new FriendRequest
            {
                UserId = userId,
                FriendId = friendId,
                IsApproving = false
            };
            await _userContext.FriendRequests.AddAsync(newFriendRequest);
            await _userContext.SaveChangesAsync();
            return _mapper.Map<FriendRequestDto>(newFriendRequest);
        }

        public async Task<bool> RemoveFriend(string userId, string friendId)
        {
            var friendShip = await _userContext.Friendships
                .FirstOrDefaultAsync(fr => fr.UserId == userId && fr.FriendId == friendId);

            _userContext.Friendships.Remove(friendShip ?? throw new InvalidOperationException("User not found"));
            await _userContext.SaveChangesAsync();
            return true;
        }

        public async Task AcceptFriend(string userId, string friendId)
        {
            var friendRequest = await _userContext.FriendRequests
                .FirstOrDefaultAsync(fr => fr.UserId == friendId && fr.FriendId == userId);
            _userContext.FriendRequests.Remove(friendRequest ?? throw new InvalidOperationException("User not found"));

            var friendship = new Friendship
            {
                UserId = userId,
                FriendId = friendId
            };
            _userContext.Friendships.Add(friendship);
            await _userContext.SaveChangesAsync();
        }

        public async Task<bool> CancelSend(string userId, string friendId)
        {
            var friendRequest = await _userContext.FriendRequests
                .FirstOrDefaultAsync(fr => fr.UserId == userId && fr.FriendId == friendId);

            _userContext.FriendRequests.Remove(friendRequest ?? throw new InvalidOperationException("User not found"));
            await _userContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<FriendRequestDto>> GetFriendRequests(string userId)
        {
            var friendRequests = await _userContext.FriendRequests
                .Where(fr => fr.UserId == userId)
                .ToListAsync();

            return _mapper.Map<List<FriendRequestDto>>(friendRequests);
        }

        public async Task<List<FriendRequestDto>> GetUserRequests(string friendId)
        {
            var receivedFriendRequests = await _userContext.FriendRequests
                .Where(fr => fr.FriendId == friendId)
                .ToListAsync();

            return _mapper.Map<List<FriendRequestDto>>(receivedFriendRequests);
        }
    }
}