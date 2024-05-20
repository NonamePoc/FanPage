﻿using FanPage.Application.UserProfile;
using Microsoft.AspNetCore.Http;

namespace FanPage.Domain.Account.Repos.Interfaces;

public interface IFollowerRepository
{
    Task<List<FollowerDto>> FollowerList(string useraName, int page);

    Task<List<FollowerDto>> UserFollower (string userName, int page);

    Task<bool> Subscribe(string subName, string userName, string userId, string subId);
    Task<bool> Unsubscribe(string subId, string userId);

    Task<bool> IsSubscribed(string subName, string userName);
}