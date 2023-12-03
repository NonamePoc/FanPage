using FanPage.Application.Admin;
using Microsoft.AspNetCore.Identity;

namespace FanPage.Infrastructure.Interfaces
{
    public interface IAdmin
    {
        Task<bool> Delete(DeleteDto userId);
        Task<bool> Ban(BanDto user);
        Task<bool> Unban(UnbanDto banId);
        Task<IdentityResult> ChangeRole(ChangeRoleDto userId);
        Task<UserInfoResponseDto> GetUserInformation(UserInfoDto userId);

    }
}
