using FanPage.Application.Admin;
using FanPage.Exceptions;
using FanPage.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace FanPage.Infrastructure.Implementations.User
{
    public class AdminService : IAdmin
    {
        private readonly UserManager<Domain.Entities.Identity.User> _userManager;
        private readonly IJwtTokenManager _jwtTokenManager;

        public AdminService(UserManager<Domain.Entities.Identity.User> userManager, IJwtTokenManager jwtTokenManager)
        {
            _userManager = userManager;
            _jwtTokenManager = jwtTokenManager;
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

        public async Task<bool> Ban(BanDto user, HttpRequest request)
        {
            var userToBlock = await _userManager.FindByIdAsync(user.Id);
            var admin = _jwtTokenManager.GetUserNameFromToken(request);
            if (userToBlock == null)
            {
                throw new UserNotFoundException("User not found");
            }

            var lockoutEndDate = DateTime.UtcNow.AddDays((double)user.days);
            var result = await _userManager.SetLockoutEndDateAsync(userToBlock, lockoutEndDate);
            userToBlock.WhoBan = admin;
            await _userManager.UpdateAsync(userToBlock);
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
            var bannedUsers = await _userManager.Users
            .Where(u => u.LockoutEnd != null && u.LockoutEnd > DateTime.Now)
            .Select(u => new UserBanInfoResponseDto
            {
                Id = u.Id,
                Name = u.UserName,
                BanTime = u.LockoutEnd,
                AdminName = u.WhoBan
            })
            .ToListAsync();
            return bannedUsers;
        }
        public async Task<List<UserInfoResponseDto>> AllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var userDtos = users.Select(u => new UserInfoResponseDto { Id = u.Id, Name = u.UserName }).ToList();
            return userDtos;
        }

        public async Task<bool> ApproveTag(int tagId, HttpRequest request)
        {
            var user = _jwtTokenManager.GetUserNameFromToken(request);
            var userForChangeRole = await _userManager.FindByNameAsync(user);

            var roles = await _userManager.GetRolesAsync(userForChangeRole);
            if (roles.Contains("Admin"))
            {
                throw new InvalidOperationException("Cannot change the role of another admin.");
            }

            var tag = _tagRepository.ApproveTag(tagId);
            return await tag;
        }

        public async Task<List<TagDto>> GetNotApprovedTags()
        {
            var tags = await _tagRepository.GetNotApprovedTags();
            return tags.Select(tag => new TagDto
            {
                TagId = tag.TagId,
                Name = tag.Name
            }).ToList();
        }

        public async Task<UserInfoResponseDto> GetAdminAsync(HttpRequest request)
        {
            var user = _jwtTokenManager.GetUserNameFromToken(request);
            var userRole = await _userManager.FindByNameAsync(user);
            var admin = await _userManager.GetRolesAsync(userRole);
            if (admin.Contains("Admin"))
            {
                throw new InvalidOperationException("This user is not admin.");
            }

            return new UserInfoResponseDto
            {
                UserName = userRole.UserName,
                Email = userRole.Email,
                PhoneNumber = userRole.PhoneNumber,
                Role = admin.FirstOrDefault()
            };
        }
        
        public async Task<UserInfoResponseDto> GetModeratorAsync(HttpRequest request)
        {
            var user = _jwtTokenManager.GetUserNameFromToken(request);
            var userRole = await _userManager.FindByNameAsync(user);
            var moderator = await _userManager.GetRolesAsync(userRole);
            if (moderator.Contains("Moderator"))
            {
                throw new InvalidOperationException("This user is not admin.");
            }

            return new UserInfoResponseDto
            {
                UserName = userRole.UserName,
                Email = userRole.Email,
                PhoneNumber = userRole.PhoneNumber,
                Role = moderator.FirstOrDefault()
            };
        }
        
        public async Task<UserInfoResponseDto> GetUserRoleAsync(string userName)
        {
            var userRole = await _userManager.FindByNameAsync(userName);
            var role = await _userManager.GetRolesAsync(userRole);
            return new UserInfoResponseDto
            {
                UserName = userRole.UserName,
                Email = userRole.Email,
                PhoneNumber = userRole.PhoneNumber,
                Role = role.FirstOrDefault()
            };
        }
    }
}