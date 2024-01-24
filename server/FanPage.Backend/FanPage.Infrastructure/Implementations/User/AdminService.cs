using FanPage.Application.Admin;
using FanPage.Application.Fanfic;
using FanPage.Common.Interfaces;
using FanPage.Domain.Fanfic.Repos.Interfaces;
using FanPage.Exceptions;
using FanPage.Infrastructure.Interfaces.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FanPage.Infrastructure.Implementations.User
{
    public class AdminService : IAdmin
    {
        private readonly UserManager<Domain.User.Entities.User> _userManager;

        private readonly ITagRepository _tagRepository;

        private readonly IJwtTokenManager _jwtTokenManager;

        public AdminService(UserManager<Domain.User.Entities.User> userManager, ITagRepository tagRepository,
            IJwtTokenManager jwtTokenManager)
        {
            _userManager = userManager;
            _tagRepository = tagRepository;
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

            return result.Succeeded ? true : throw new UserDeleteException("Un succeed delete");
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

        public async Task<bool> Unban(string id)
        {
            var userToUnblock = await _userManager.FindByIdAsync(id);

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

            if (userForChangeRole != null)
            {
                var roles = await _userManager.GetRolesAsync(userForChangeRole);
                if (roles.Contains("Admin"))
                {
                    throw new InvalidOperationException("Cannot change the role of another admin.");
                }

                await _userManager.RemoveFromRolesAsync(userForChangeRole, roles);
            }

            return await _userManager.AddToRoleAsync(userForChangeRole, user.NewRole);
        }

        public async Task<UserInfoResponseDto> GetUserInformation(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            bool ban = false;
            var roles = await _userManager.GetRolesAsync(user);
            var roleString = roles.FirstOrDefault();
            if (user == null)
            {
                throw new UserNotFoundException("User not found");
            }

            ban = user.LockoutEnd != null ? true : false;
            return new UserInfoResponseDto
            {
                IsBanned = ban,
                BanExpirationDate = user.LockoutEnd,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = roleString,
                UserName = user.UserName
            };
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