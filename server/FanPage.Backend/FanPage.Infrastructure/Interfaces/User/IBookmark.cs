using FanPage.Application.UserProfile;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Infrastructure.Interfaces.User
{
    public interface IBookmark
    {
        Task<List<BookmarkDto>> BookmarkList(HttpRequest request);

        Task<bool> Add(HttpRequest request, int titelId);

        Task<bool> Delete(HttpRequest request, int titelId);
    }
}
