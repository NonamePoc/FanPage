using FanPage.Application.UserProfile;
using FanPage.Common.Interfaces;
using FanPage.Domain.Account.Entities;
using FanPage.Domain.Account.Repos.Interfaces;
using FanPage.Infrastructure.Implementations.Helper;
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
        private readonly IStorageHttp _storageHttp;

        public FollowerService(
            IFollowerRepository repository,
            IJwtTokenManager jwtTokenManager,
            IdentityUserManager userManager,
            IStorageHttp storageHttp
        )
        {
            _repository = repository;
            _jwtTokenManager = jwtTokenManager;
            _userManager = userManager;
            _storageHttp = storageHttp;
        }

        public async Task<List<FollowerDto>> FollowerList(HttpRequest request)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            var followers = await _repository.FollowerList(userName);
            var list = new List<FollowerDto>();
            foreach (var follower in followers)
            {
                var followerDto = new FollowerDto
                {
                    UserName = follower.UserName,
                    SubName = follower.SubName,
                    Avatar = follower.Avatar
                };
                if (follower.Avatar != null)
                {
                    var uploadResult = await _storageHttp.GetImageBase64FromStorageService(
                        follower.Avatar
                    );
                    followerDto.Avatar = uploadResult;
                }

                list.Add(followerDto);
            }
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
