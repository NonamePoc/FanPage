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

    // Повертає список підписників
    public async Task<List<FollowerDto>> UserFollower(string userName, int page)
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

    // Повертає список підписок
    public async Task<List<FollowerDto>> FollowerList(string userName, int page)
    {

        var followers = await _userContext.Followers
            .Where(sub => sub.SubName == userName  && sub.UserName == userName || sub.is_AreFollowersMutual == true)
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
            .FirstOrDefaultAsync(f => f.SubName == userName || f.UserName == subName);

        // Перевіряємо наявність підписки
        if (existingSub != null)
        {
            // Якщо підписка вже існує і is_AreFollowersMutual == true, просто повертаємо true
            if (existingSub.is_AreFollowersMutual)
                return true;

            // Якщо підписка існує, але is_AreFollowersMutual == false, оновлюємо значення на true
            existingSub.is_AreFollowersMutual = true;
            await _userContext.SaveChangesAsync();
            return true;
        }

        var newSub = new Follower
        {
            UserName = userName,
            SubName = subName,
            UserId = userId,
            SubId = subId,
            is_AreFollowersMutual = false,
            UnsubscribedBy = ""
        };

        _userContext.Followers.Add(newSub);
        await _userContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Unsubscribe(string subName, string userName)
    {
        var existingSub = await _userContext.Followers
            .FirstOrDefaultAsync(sub => sub.SubName == userName || sub.UserName == subName);

        if (existingSub == null)
            return false;

        // Якщо юзер відписується від чела тоді is_AreFollowersMutual == false і UnsubscribedBy == userName
        if (existingSub.is_AreFollowersMutual)
        {
            existingSub.is_AreFollowersMutual = false;
            existingSub.UnsubscribedBy = userName;
        }
        else
        {
            // Якщо is_AreFollowersMutual == false, то просто видаляємо обьект оскільки вони двоє не підписані один на одного
            _userContext.Followers.Remove(existingSub);
        }


        await _userContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> IsSubscribed(string subName, string userName)
    {
        var existingSub = await _userContext.Followers
            .FirstOrDefaultAsync(sub => sub.UserName == userName || sub.SubName == subName);

         if (existingSub != null)
            return true;

         return false;
    }
}