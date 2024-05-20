using FanPage.Application.UserProfile;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Interfaces.User;

public interface IFollower
{
    Task<List<FollowerDto>> FollowerList(string userName, int page);

    Task<List<FollowerDto>> UserFollower(string userName, int page);

    Task<bool> Subscribe(HttpRequest request, string username);
    Task<bool> Unsubscribe(HttpRequest request, string username);
}