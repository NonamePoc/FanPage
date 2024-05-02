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

    public FollowerRepository(UserContext userContext)
    {
        _userContext = userContext;
    }

    public async Task<List<FollowerDto>> FollowerList(string userName, int page)
    {
        var followers = await _userContext.Followers
            .Where(sub => sub.UserName == userName)
            .Skip((page - 1) * 10)
            .Take(10)
            .ToListAsync();

        var list = new List<FollowerDto>();
        foreach (var follower in followers)
        {
            var followerDto = new FollowerDto
            {
                UserName = follower.UserName,
                SubName = follower.SubName,
                Avatar = ""
            };
            list.Add(followerDto);
        }

        return list;
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