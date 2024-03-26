using FanPage.Application.UserProfile;
using FanPage.Domain.Account.Context;
using FanPage.Domain.Account.Entities;
using FanPage.Domain.Account.Repos.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FanPage.Domain.Account.Repos.Impl;

public class FollowerRepository : IFollowerRepository
{
    private readonly UserContext _userContext;

    private readonly UserManager<User> _userManager;

    // For Pasha. Sub is current user, блять!!!
    public FollowerRepository(UserContext userContext, UserManager<User> userManager)
    {
        _userContext = userContext;
        _userManager = userManager;
    }

    public async Task<List<FollowerDto>> FollowerList(string userName)
    {
        var friendIds = await _userContext.Followers
            .Where(f => f.SubName == userName)
            .Select(f => f.UserName)
            .ToListAsync();
        var userAvatar = await _userManager.FindByNameAsync(userName);
        var userFo = await _userManager.Users
            .Where(u => friendIds.Contains(u.UserName))
            .Select(u => new FollowerDto
            {
                UserName = userName,
                Avatar = userAvatar.UserAvatar,
                SubName = u.UserName
            })
            .ToListAsync();

        return userFo;
    }

    public async Task<bool> Subscribe(string subName, string userName, string userId, string subId)
    {
        var existingSub = await _userContext.Followers
            .FirstOrDefaultAsync(sub => sub.UserName == userName && sub.SubName == subName);

        if (existingSub != null)
        {
            return false;
        }

        var newSub = new Follower
        {
            UserName = userName,
            SubName = subName,
            UserId = userId,
            SubId = subId
        };

        _userContext.Followers.Add(newSub);
        await _userContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Unsubscribe(string subName, string userName)
    {
        var unsub = await _userContext.Followers
            .FirstOrDefaultAsync(sub => sub.UserName == userName && sub.SubName == subName);
        _userContext.Followers.Remove(unsub ?? throw new InvalidOperationException(" Not found"));
        await _userContext.SaveChangesAsync();
        return true;
    }
}