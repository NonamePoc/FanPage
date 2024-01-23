using AutoMapper;
using FanPage.Application.UserProfile;
using FanPage.Common.Interfaces;
using FanPage.Domain.Entities.Identity;
using FanPage.Persistence.Context;
using FanPage.Persistence.Migrations.User;
using FanPage.Persistence.Repositories.Interfaces.IProfile;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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
            var followers = await _userContext.Followers
                .Where(user => user.UserName == userName)
                .ToListAsync();

            return _mapper.Map<List<FollowerDto>>(followers);
        }

        public async Task<FollowerDto> Subscribe(HttpRequest request, string userName)
        {
            var followerName = _jwtTokenManager.GetUserNameFromToken(request);
            var newSub = await _userContext.Followers
            .FirstOrDefaultAsync(sub => sub.UserName == userName && sub.FollowerName == followerName);
            _userContext.Followers.Add(newSub);
            await _userContext.SaveChangesAsync();
            return _mapper.Map<FollowerDto>(newSub);
        }
        public async Task<bool> Unsubscribe(HttpRequest request, string userName)
        {
            var followerName = _jwtTokenManager.GetUserNameFromToken(request);
            var unsub = await _userContext.Followers
            .FirstOrDefaultAsync(sub => sub.UserName == userName && sub.FollowerName == followerName);
            _userContext.Followers.Remove(unsub);
            await _userContext.SaveChangesAsync();
            return true;
        }

    }
}
