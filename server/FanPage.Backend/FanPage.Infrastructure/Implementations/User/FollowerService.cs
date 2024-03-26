using FanPage.Application.UserProfile;
using FanPage.Common.Interfaces;
using FanPage.Domain.Account.Entities;
using FanPage.Domain.Account.Repos.Interfaces;
using FanPage.Infrastructure.Interfaces.User;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Implementations.User
{
    public class FollowerService : IFollower
    {
        private readonly IFollowerRepository _repository;
        private readonly IJwtTokenManager _jwtTokenManager;
        private readonly IdentityUserManager _userManager;

        public FollowerService(IFollowerRepository repository, IJwtTokenManager jwtTokenManager, IdentityUserManager userManager)
        {
            _repository = repository;
            _jwtTokenManager = jwtTokenManager;
            _userManager = userManager;
        }

        public async Task<List<FollowerDto>> FollowerList(HttpRequest request)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            var list = await _repository.FollowerList(userName);
            return list;
        }

        public async Task<bool> Subscribe(HttpRequest request, string userName)
        {
            var subName = _jwtTokenManager.GetUserNameFromToken(request);
            var subId = _jwtTokenManager.GetUserIdFromToken(request);
            var user = await _userManager.FindByNameAsync(userName);
            await _repository.Subscribe(subName, userName, user.Id, subId);
            return true;
        }

        public async Task<bool> Unsubscribe(HttpRequest request, string userName)
        {
            var subName = _jwtTokenManager.GetUserNameFromToken(request);
            await _repository.Unsubscribe(subName, userName);
            return true;
        }
    }
}