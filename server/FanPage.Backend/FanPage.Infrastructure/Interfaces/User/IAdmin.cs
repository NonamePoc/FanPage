using FanPage.Application.Admin;
using FanPage.Application.Fanfic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FanPage.Infrastructure.Interfaces.User
{
    public interface IAdmin
    {
        Task<bool> Delete(string Id);
        Task<bool> Ban(BanDto user, HttpRequest request);
        Task<bool> Unban(string Id);
        Task<IdentityResult> ChangeRole(ChangeRoleDto user);
        Task<List<UserBanInfoResponseDto>> GetUserInBan();
        Task<List<UserInfoResponseDto>> AllUsers();
        Task<UserInfoResponseDto> Screach(string userName);

        Task<bool> ApproveTag(int tagId);

        Task<UserInfoResponseDto> GetAdminAsync(HttpRequest request);

        Task<UserInfoResponseDto> GetUserRoleAsync(string userName);

        Task<List<TagDto>> GetNotApprovedTags();
    }
}
