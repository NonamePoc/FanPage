using FanPage.Application.UserProfile;
using FanPage.Common.Interfaces;
using FanPage.Domain.User.Repos.Interfaces;
using FanPage.Infrastructure.Interfaces.User;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Implementations.User
{
    public class FollowerService : IFollower
    {
        private readonly IFollowerRepository _repository;
        private readonly IJwtTokenManager _jwtTokenManager;

        public FollowerService(IFollowerRepository repository, IJwtTokenManager jwtTokenManager)
        {
            _repository = repository;
            _jwtTokenManager = jwtTokenManager;
        }

        public async Task<List<FollowerDto>> FollowerList(HttpRequest request)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            var list = await _repository.FollowerList(userName);
            return list;
        }

        public async Task<bool> Subscribe(HttpRequest request, int followerUserId)
        {
            var userId = _jwtTokenManager.GetUserNameFromToken(request);

            await _repository.Subscribe(followerUserId, userId);
            return true;
        }

        public async Task<bool> Unsubscribe(HttpRequest request, int followerUserId)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            await _repository.Unsubscribe(followerUserId, userName);
            return true;
        }
    }
}