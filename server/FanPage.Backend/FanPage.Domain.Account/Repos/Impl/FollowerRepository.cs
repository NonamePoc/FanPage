using AutoMapper;
using FanPage.Application.UserProfile;
using FanPage.Domain.Account.Context;
using FanPage.Domain.Account.Entities;
using FanPage.Domain.Account.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FanPage.Domain.Account.Repos.Impl;

public class FollowerRepository : IFollowerRepository
{
    private readonly UserContext _userContext;
    private readonly IMapper _mapper;

    public FollowerRepository(UserContext userContext, IMapper mapper)
    {
        _userContext = userContext;
        _mapper = mapper;
    }

    public async Task<List<FollowerDto>> FollowerList(string userId)
    {
        var followers = await _userContext.Followers
            .Where(user => user.UserId == userId)
            .ToListAsync();

        return _mapper.Map<List<FollowerDto>>(followers);
    }

    public async Task<bool> Subscribe(int followerId, string userId)
    {
        await _userContext.Followers
            .FirstOrDefaultAsync(sub => sub.UserId == userId && sub.FollowerId == followerId);
        var newSub = new Follower
        {
            UserId = userId,
            FollowerId = followerId
        };
        _userContext.Followers.Add(newSub);
        await _userContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Unsubscribe(int followerId, string userId)
    {
        var unsub = await _userContext.Followers
            .FirstOrDefaultAsync(sub => sub.UserId == userId && sub.FollowerId == followerId);
        _userContext.Followers.Remove(unsub ?? throw new InvalidOperationException(" Not found"));
        await _userContext.SaveChangesAsync();
        return true;
    }
}