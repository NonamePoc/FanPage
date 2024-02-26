using AutoMapper;
using FanPage.Application.Admin;
using FanPage.Application.UserProfile;
using FanPage.Domain.Account.Context;
using FanPage.Domain.Account.Entities;
using FanPage.Domain.Account.Repos.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace FanPage.Domain.Account.Repos.Impl
{
    public class FriendRepository : IFriendRepository
    {
        private readonly UserContext _userContext;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public FriendRepository(UserContext userContext, IMapper mapper, UserManager<User> userManager)
        {
            _userContext = userContext;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<List<FriendDto>> FriendsList(string userName)
        {
            var friendIds = await _userContext.Friendships
                .Where(f => f.UserName == userName)
                .Select(f => f.FriendName)
                .ToListAsync();    
            var userAva = await _userManager.FindByNameAsync(userName);
            var userFr = await _userManager.Users
                .Where(u => friendIds.Contains(u.Id))
                .Select(u => new FriendDto
                {
                    UserName = userName,
                    userAvatar = userAva.UserAvatar,
                    friendAvatar = u.UserAvatar,
                    FriendName = u.Id
                })
                .ToListAsync();

            return userFr;
        }


        public async Task<FriendRequestDto> AddFriend(string userName, string friendName, string userId, string friendId)
        {
            var existingRequest = await _userContext.FriendRequests
                .FirstOrDefaultAsync(fr => fr.UserName == userName && fr.FriendName == friendName);

            if (existingRequest != null) return null;
            var newFriendRequest = new FriendRequest
            {
                UserName = userName,
                FriendName = friendName,
                UserId = userId,
                FriendId = friendId,
                IsApproving = false
            };
            await _userContext.FriendRequests.AddAsync(newFriendRequest);
            await _userContext.Followers
            .FirstOrDefaultAsync(sub => sub.UserName == friendId && sub.SubName == userId);
            var newSub = new Follower
            {
                UserName = friendId,
                SubName = userId,
                UserId = friendId,
                SubId = userId
            };
            _userContext.Followers.Add(newSub);
            await _userContext.SaveChangesAsync();
            return _mapper.Map<FriendRequestDto>(newFriendRequest);
        }

        public async Task<bool> RemoveFriend(string userName, string friendName)
        {
            var friendShip = await _userContext.Friendships
                .FirstOrDefaultAsync(fr => fr.UserName == userName && fr.FriendName == friendName);

            _userContext.Friendships.Remove(friendShip ?? throw new InvalidOperationException("User not found"));
            await _userContext.SaveChangesAsync();
            return true;
        }

        public async Task AcceptFriend(string userName, string friendName, string userId, string friendId)
        {
            var friendRequest = await _userContext.FriendRequests
                .FirstOrDefaultAsync(fr => fr.UserName == userName && fr.FriendName == friendName);
            _userContext.FriendRequests.Remove(friendRequest ?? throw new InvalidOperationException("User not found"));

            var friendship = new Friendship
            {
                UserName = userId,
                FriendName = friendId,
                UserId = userId,
                FriendId = friendId
            };
            _userContext.Friendships.Add(friendship);
            await _userContext.SaveChangesAsync();
        }

        public async Task<bool> CancelSend(string userName, string friendName)
        {
            var friendRequest = await _userContext.FriendRequests
                .FirstOrDefaultAsync(fr => fr.UserName == userName && fr.FriendName == friendName);
            _userContext.FriendRequests.Remove(friendRequest ?? throw new InvalidOperationException("User not found"));
            await _userContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<FriendRequestDto>> GetFriendRequests(string userName)
        {
            var friendIds = await _userContext.FriendRequests
                .Where(f => f.UserName == userName)
                .Select(f => f.FriendName)
                .ToListAsync();
            var userAva = await _userManager.FindByNameAsync(userName);
            var userFr = await _userManager.Users
                .Where(u => friendIds.Contains(u.UserName))
                .Select(u => new FriendRequestDto
                {
                    UserName = userName,
                    userAvatar = userAva.UserAvatar,
                    friendAvatar = u.UserAvatar,
                    FriendName = u.UserName
                })
                .ToListAsync();

            return userFr;
        }
        public async Task<List<FriendRequestDto>> GetUserRequests(string userName)
        {
            var friendIds = await _userContext.FriendRequests
               .Where(f => f.FriendName == userName)
               .Select(f => f.FriendName)
               .ToListAsync();
            var userAva = await _userManager.FindByNameAsync(userName);
            var userFr = await _userManager.Users
                .Where(u => friendIds.Contains(u.UserName))
                .Select(u => new FriendRequestDto
                {
                    UserName = u.UserName,
                    userAvatar = userAva.UserAvatar,
                    friendAvatar = u.UserAvatar,
                    FriendName = userName       
                })
                .ToListAsync();

            return userFr;
        }
    }
}