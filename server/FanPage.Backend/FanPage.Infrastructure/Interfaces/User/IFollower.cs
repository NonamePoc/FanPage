using FanPage.Application.UserProfile;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Infrastructure.Interfaces.User
{
    public interface IFollower
    {
        Task<List<FollowerDto>> FollowerList(HttpRequest request);

        Task<bool> Subscribe(HttpRequest request, string userName);
        Task<bool> Unsubscribe(HttpRequest request, string userName);
    }
}
