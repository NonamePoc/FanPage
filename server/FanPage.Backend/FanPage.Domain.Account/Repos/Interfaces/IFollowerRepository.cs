using FanPage.Application.UserProfile;
using Microsoft.AspNetCore.Http;

namespace FanPage.Domain.Account.Repos.Interfaces;

public interface IFollowerRepository
{
    Task<List<FollowerDto>> FollowerList(string userId);
    Task<bool> Subscribe(int followerId, string userId);
    Task<bool> Unsubscribe(int followerId, string userId);
}