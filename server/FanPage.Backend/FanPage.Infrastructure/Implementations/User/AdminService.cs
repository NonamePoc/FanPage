﻿using FanPage.Application.Admin;
using FanPage.Domain.Entities.Identity;
using FanPage.Exceptions;
using FanPage.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace FanPage.Infrastructure.Implementations.User
{
    public class AdminService : IAdmin
    {
        private readonly UserManager<Domain.Entities.Identity.User> _userManager;

        public AdminService(UserManager<Domain.Entities.Identity.User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> Delete(string Id)
        {
            var userToDelete = await _userManager.FindByIdAsync(Id);
            if (userToDelete == null)
            {
                throw new UserNotFoundException("User not found");
            }
            var result = await _userManager.DeleteAsync(userToDelete);

            return result.Succeeded ? true : throw new UserDeleteException("Unsucceed delete");
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

            return result.Succeeded ? true : throw new Exception("Failed to ban user.");
        }

        public async Task<bool> Unban(string Id)
        {
            var userToUnblock = await _userManager.FindByIdAsync(Id);

            if (userToUnblock == null)
            {
                throw new UserNotFoundException("User not found");
            }

            var result = await _userManager.SetLockoutEndDateAsync(userToUnblock, null);

            return result.Succeeded ? true : throw new Exception("Failed to unban user.");
        }
        public async Task<IdentityResult> ChangeRole(ChangeRoleDto user)
        {
            var userForChangeRole = await _userManager.FindByIdAsync(user.Id);

            if (user == null)
            {
                throw new UserNotFoundException("User not found");
            }
            var roles = await _userManager.GetRolesAsync(userForChangeRole);
            if (roles.Contains("Admin"))
            {
                throw new InvalidOperationException("Cannot change the role of another admin.");
            }
            await _userManager.RemoveFromRolesAsync(userForChangeRole, roles);
            return await _userManager.AddToRoleAsync(userForChangeRole, user.NewRole);
        }
        public async Task<List<UserBanInfoResponseDto>> GetUserInBan()
        {
            var bannedUsers = _userManager.Users
            .Where(u => u.LockoutEnd != null && u.LockoutEnd > DateTime.Now)
            .Select(u => new UserBanInfoResponseDto
            {
                Id = u.Id,
                Name = u.UserName,
                BanTime = u.LockoutEnd
            })
            .ToList();
            return bannedUsers;
        }
        public async Task<List<UserInfoResponseDto>> AllUsers()
        {
            var users = _userManager.Users.ToList();
            var userDtos = users.Select(u => new UserInfoResponseDto { Id = u.Id, Name = u.UserName }).ToList();
            return userDtos;
        }

    }

}

