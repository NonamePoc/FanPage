using FanPage.Application.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FanPage.Infrastructure.Interfaces
{
    public interface IAdmin
    {
        Task<bool> Delete(string Id);
        Task<bool> Ban(BanDto user, HttpRequest request);
        Task<bool> Unban(string Id);
        Task<IdentityResult> ChangeRole(ChangeRoleDto user);
        Task<List<UserBanInfoResponseDto>> GetUserInBan();
        Task<List<UserInfoResponseDto>> AllUsers();

    }
}
