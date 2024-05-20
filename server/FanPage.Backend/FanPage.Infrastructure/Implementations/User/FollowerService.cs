using FanPage.Application.UserProfile;
using FanPage.Common.Interfaces;
using FanPage.Domain.Account.Entities;
using FanPage.Domain.Account.Repos.Interfaces;
using FanPage.Infrastructure.Implementations.Helper;
using FanPage.Infrastructure.Interfaces.User;
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


        // Повертає список підписників користувача
        public async Task<List<FollowerDto>> UserFollower(string userName, int page)
        {
            try
            {


                var followers = await _repository.UserFollower(userName, page);
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
            catch (Exception e)
            {
                throw new Exception("Error get user follower: " + e.Message);
            }
        }

        // Повертає список підписників користувача
        public async Task<List<FollowerDto>> FollowerList(string userName, int page)
        {
            try
            {
                var followers = await _repository.FollowerList(userName, page);
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
            catch (Exception e)
            {
                throw new Exception("Error get follower list: " + e.Message);
            }
        }

        public async Task<bool> Subscribe(HttpRequest request, string userName)
        {
            try
            {
                //var token = ExtractTokenFromRequest(request);


                //request.Headers["Authorization"] = $"Bearer {token}";

                //if (userName == _jwtTokenManager.GetUserNameFromToken(request))
                //{
                //    throw new Exception("You can't subscribe to yourself");
                //}
                var subName = _jwtTokenManager.GetUserNameFromToken(request);
                var subId = _jwtTokenManager.GetUserIdFromToken(request);
                var user = await _userManager.FindByNameAsync(userName);
                await _repository.Subscribe(subName, userName, user.Id, subId);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Error subscribe: " + e.Message);
            }
        }




        public async Task<bool> Unsubscribe(HttpRequest request, string userName)
        {
            try
            {
                //var token = ExtractTokenFromRequest(request);


                //request.Headers["Authorization"] = $"Bearer {token}";

                //if (userName == _jwtTokenManager.GetUserNameFromToken(request))
                //{
                //    throw new Exception("You can't unsubscribe to yourself");
                //}
                var subName = _jwtTokenManager.GetUserNameFromToken(request);
                await _repository.Unsubscribe(subName, userName);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Error unsubscribe: " + e.Message);
            }
        }


        private string ExtractTokenFromRequest(HttpRequest request)
        {
            if (request.Query.TryGetValue("access_token", out var token))
            {
                return token;
            }
            throw new Exception("Token is missing");
        }
    }
}