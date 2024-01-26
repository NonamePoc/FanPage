using FanPage.Application.UserProfile;
using Microsoft.AspNetCore.Http;

namespace FanPage.Persistence.Repositories.Interfaces.IProfile
{
    public interface IFollowerRepository
    {
        Task<List<FollowerDto>> FollowerList(HttpRequest request);
        Task<FollowerDto> Subscribe(HttpRequest request, string userName);
        Task<bool> Unsubscribe(HttpRequest request, string userName);
    }
}
