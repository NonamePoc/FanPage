using AutoMapper;
using FanPage.Application.UserProfile;
using FanPage.Common.Interfaces;
using FanPage.Domain.Entities.Identity;
using FanPage.Persistence.Context;
using FanPage.Persistence.Repositories.Interfaces.IProfile;
using Microsoft.AspNetCore.Http;
using System.Data.Entity;

namespace FanPage.Persistence.Repositories.Implementations.ProfileRepos
{
    public class FollowerRepository : IFollowerRepository
    {
        private readonly UserContext _userContext;
        private readonly IMapper _mapper;
        private readonly IJwtTokenManager _jwtTokenManager;
        public FollowerRepository(UserContext userContext, IMapper mapper, IJwtTokenManager jwtTokenManager)
        {
            _userContext = userContext;
            _mapper = mapper;
            _jwtTokenManager = jwtTokenManager;
        }

        public async Task<List<FollowerDto>> FollowerList(HttpRequest request)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            var followers = _userContext.Followers
                .Where(user => user.UserName == userName)
                .ToList();

            return _mapper.Map<List<FollowerDto>>(followers);
        }

        public async Task<bool> Subscribe(HttpRequest request, string userName)
        {
            var followerName = _jwtTokenManager.GetUserNameFromToken(request);
            _userContext.Followers
            .FirstOrDefault(sub => sub.UserName == userName && sub.FollowerName == followerName);
            var newSub = new Follower
            {
                UserName = userName,
                FollowerName = followerName
            };
            _userContext.Followers.Add(newSub);
            _userContext.SaveChanges();
            return true;
        }
        public async Task<bool> Unsubscribe(HttpRequest request, string userName)
        {
            var followerName = _jwtTokenManager.GetUserNameFromToken(request);
            var unsub = _userContext.Followers
            .FirstOrDefault(sub => sub.UserName == userName && sub.FollowerName == followerName);
            _userContext.Followers.Remove(unsub);
            _userContext.SaveChanges();
            return true;
        }

    }
}
