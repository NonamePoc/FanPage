using FanPage.Application.Admin;
using FanPage.Domain.Entities.Identity;
using FanPage.Exceptions;
using FanPage.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace FanPage.Infrastructure.Implementations
{
    public class AdminService : IAdmin
    {
        private readonly UserManager<User> _userManager;

        public AdminService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> Delete(DeleteDto userId)
        {
            var userToDelete = await _userManager.FindByIdAsync(userId.Id);
            if (userToDelete == null)
            {
                throw new UserNotFoundException("User not found");
            }
            var result = await _userManager.DeleteAsync(userToDelete);

            if (result.Succeeded)
            {
                return true;
            }
            throw new UserDeleteException("Unsucceed delete");
        }

        public async Task<bool> Ban(BanDto user)
        {
            var userToBlock = await _userManager.FindByIdAsync(user.Id);

            if (userToBlock == null)
            {
                throw new UserNotFoundException("User not found");
            }

            var lockoutEndDate = DateTime.UtcNow.AddDays((double)user.days);
            var result = await _userManager.SetLockoutEndDateAsync(userToBlock, lockoutEndDate);

            if (result.Succeeded)
            {
                return true;
            }
            throw new Exception("Failed to ban user.");
        }

        public async Task<bool> Unban(UnbanDto userId)
        {
            var userToUnblock = await _userManager.FindByIdAsync(userId.Id);

            if (userToUnblock == null)
            {
                throw new UserNotFoundException("User not found");
            }

            var result = await _userManager.SetLockoutEndDateAsync(userToUnblock, null);

            if (result.Succeeded)
            {
                return true;
            }
            throw new Exception("Failed to unban user.");
        }
        public async Task<IdentityResult> ChangeRole(ChangeRoleDto userId)
        {
            var user = await _userManager.FindByIdAsync(userId.Id);
            if (user == null)
            {
                throw new UserNotFoundException("User not found");
            }
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Contains("Admin"))
            {
                throw new InvalidOperationException("Cannot change the role of another admin.");
            }
            var result = await _userManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                return result;
            }

            return await _userManager.AddToRoleAsync(user, userId.NewRole);
        }
    }
}
