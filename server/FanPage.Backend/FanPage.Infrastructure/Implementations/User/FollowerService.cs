using FanPage.Application.UserProfile;
using FanPage.Infrastructure.Interfaces.User;
using FanPage.Persistence.Repositories.Interfaces.IProfile;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace FanPage.Infrastructure.Implementations.User
{
    public class FollowerService : IFollower
    {
        private readonly IFollowerRepository _repository;

        public FollowerService(IFollowerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FollowerDto>> FollowerList(HttpRequest request)
        {
            var list = await _repository.FollowerList(request);
            return list;
        }

        public async Task<bool> Subscribe(HttpRequest request, string userName)
        {
            await _repository.Subscribe(request, userName);
            return true;


        }

        public async Task<bool> Unsubscribe(HttpRequest request, string userName)
        {
            await _repository.Unsubscribe(request, userName);
            return true;
        }
    }
}
