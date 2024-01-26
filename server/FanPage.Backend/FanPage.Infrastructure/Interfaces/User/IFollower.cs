using FanPage.Application.UserProfile;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Interfaces.User;

public interface IFollower
{
    Task<List<FollowerDto>> FollowerList(HttpRequest request);

    Task<bool> Subscribe(HttpRequest request, int followerUserId);
    Task<bool> Unsubscribe(HttpRequest request, int followerUserId);
}