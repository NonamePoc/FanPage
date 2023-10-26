using FanPage.Application.Admin;
using FanPage.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace FanPage.Infrastructure.Interfaces
{
    public interface IAdmin
    {
        Task <bool>Delete(DeleteDto userId);
        Task <bool> Ban(BanDto user);
        Task<bool> Unban(UnbanDto banId);
        Task<IdentityResult> ChangeRole(ChangeRoleDto user);

    }
}
