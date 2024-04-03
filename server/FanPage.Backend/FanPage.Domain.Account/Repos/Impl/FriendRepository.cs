using AutoMapper;
using FanPage.Application.Admin;
using FanPage.Application.UserProfile;
using FanPage.Domain.Account.Context;
using FanPage.Domain.Account.Entities;
using FanPage.Domain.Account.Repos.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;

namespace FanPage.Domain.Account.Repos.Impl
{
    public class FriendRepository : IFriendRepository
    {
        private readonly UserContext _userContext;
        private readonly UserManager<User> _userManager;

        public FriendRepository(UserContext userContext, UserManager<User> userManager)
        {
            _userContext = userContext;
            _userManager = userManager;
        }

        public async Task<List<FriendDto>> FriendsList(string userName)
        {
            var friendsOfUser = await _userContext.Friendships
                .Where(f => f.UserName == userName)
                .Select(f => f.FriendName)
                .ToListAsync();

            var usersWithUserInFriends = await _userContext.Friendships
                .Where(f => f.FriendName == userName)
                .Select(f => f.UserName)
                .ToListAsync();

            var userAvatar = await _userManager.FindByNameAsync(userName);
            var userFriend = await _userManager.Users
                .Where(u => friendsOfUser.Contains(u.UserName) || usersWithUserInFriends.Contains(u.UserName))
                .Select(u => new FriendDto
                {
                    UserName = userName,
                    userAvatar = userAvatar.UserAvatar,
                    friendAvatar = u.UserAvatar,
                    FriendName = u.UserName
                })
                .ToListAsync();

            return userFriend;
        }


        public async Task<bool> AddFriend(string userName, string friendName, string userId, string friendId)
        {
            var existingRequest = await _userContext.FriendRequests
                .FirstOrDefaultAsync(fr => fr.UserName == userName && fr.FriendName == friendName);

            if (existingRequest != null) return false;
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
            return true;
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
                 .FirstOrDefaultAsync(fr => fr.UserName == friendName && fr.FriendName == userName);
             _userContext.FriendRequests.Remove(friendRequest);

            var friendship = new Friendship
            {
                UserName = userName,
                FriendName = friendName,
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
            var friend = await _userContext.FriendRequests
                .Where(f => f.FriendName == userName)
                .Select(f => f.UserName)
                .ToListAsync();
            var userAvatar = await _userManager.FindByNameAsync(userName);
            var friendRequestUser = await _userManager.Users
                .Where(u => friend.Contains(u.UserName))
                .Select(u => new FriendRequestDto
                {
                    UserName = userName,
                    userAvatar = userAvatar.UserAvatar,
                    friendAvatar = u.UserAvatar,
                    FriendName = u.UserName
                })
                .ToListAsync();

            return friendRequestUser;
        }
        public async Task<List<FriendRequestDto>> GetUserRequests(string userName)
        {
            var friend = await _userContext.FriendRequests
               .Where(f => f.UserName == userName)
               .Select(f => f.FriendName)
               .ToListAsync();
            var userAvatar = await _userManager.FindByNameAsync(userName);
            var userFriendReques = await _userManager.Users
                .Where(u => friend.Contains(u.UserName))
                .Select(u => new FriendRequestDto
                {
                    UserName = userName,
                    userAvatar = userAvatar.UserAvatar,
                    friendAvatar = u.UserAvatar,
                    FriendName = u.UserName  
                })
                .ToListAsync();

            return userFriendReques;
        }

        public async Task<bool> GetUserFriend(string userName, string friendName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var friendId = await _userContext.Friendships
                .Where(f => f.UserName == userName && f.FriendName == friendName)
                .Select(f => f.FriendId)
                .FirstOrDefaultAsync();

            if (friendId == null) return false;

            return true;
        }
    }
}