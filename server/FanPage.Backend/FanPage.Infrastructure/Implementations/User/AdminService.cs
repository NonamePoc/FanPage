using System.Data.Entity;
using FanPage.Application.Admin;
using FanPage.Application.Fanfic;
using FanPage.Common.Interfaces;
using FanPage.Domain.Fanfic.Repos.Interfaces;
using FanPage.Exceptions;
using FanPage.Infrastructure.Interfaces.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FanPage.Infrastructure.Implementations.User;

public class AdminService : IAdmin
{
    private readonly UserManager<Domain.Account.Entities.User> _userManager;
    private readonly IJwtTokenManager _jwtTokenManager;
    private readonly ITagRepository _tagRepository;

    public AdminService(UserManager<Domain.Account.Entities.User> userManager, IJwtTokenManager jwtTokenManager,
        ITagRepository tagRepository)
    {
        _userManager = userManager;
        _jwtTokenManager = jwtTokenManager;
        _tagRepository = tagRepository;
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
        var userToBlock =
            await _userManager.FindByIdAsync(user.Id ?? throw new InvalidOperationException("User not found"));
        var admin = _jwtTokenManager.GetUserNameFromToken(request);
        if (userToBlock == null)
        {
            throw new UserNotFoundException("User not found");
        }

        var lockoutEndDate = DateTime.UtcNow.AddDays((double)user.days!);
        var result = await _userManager.SetLockoutEndDateAsync(userToBlock, lockoutEndDate);
        userToBlock.WhoBan = admin;
        await _userManager.UpdateAsync(userToBlock);
        return result.Succeeded ? true : throw new InvalidOperationException("Failed to ban user.");
    }

    public async Task<bool> Unban(string id)
    {
        var userToUnblock = await _userManager.FindByIdAsync(id);

        if (userToUnblock == null)
        {
            throw new UserNotFoundException("User not found");
        }

        var result = await _userManager.SetLockoutEndDateAsync(userToUnblock, null);

        return result.Succeeded ? true : throw new InvalidOperationException("Failed to unban user.");
    }

    public async Task<IdentityResult> ChangeRole(ChangeRoleDto user)
    {
        var userForChangeRole =
            await _userManager.FindByIdAsync(user.Id ?? throw new InvalidOperationException("User not found"));

        if (user == null)
        {
            throw new UserNotFoundException("User not found");
        }

        var roles = await _userManager.GetRolesAsync(userForChangeRole ??
                                                     throw new InvalidOperationException("User not found"));
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

        if (userForChangeRole != null)
        {
            var roles = await _userManager.GetRolesAsync(userForChangeRole);
            if (roles.Contains("Admin"))
            {
                throw new InvalidOperationException("Cannot change the role of another admin.");
            }
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
            Name = userRole.UserName,
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
            Name = userRole.UserName,
            Email = userRole.Email,
            PhoneNumber = userRole.PhoneNumber,
            Role = moderator.FirstOrDefault()
        };
    }

    public async Task<UserInfoResponseDto> GetUserRoleAsync(string userName)
    {
        var userRole = await _userManager.FindByNameAsync(userName);
        var role = await _userManager.GetRolesAsync(userRole ?? throw new InvalidOperationException(" User not found"));
        return new UserInfoResponseDto
        {
            Name = userRole.UserName,
            Email = userRole.Email,
            PhoneNumber = userRole.PhoneNumber,
            Role = role.FirstOrDefault()
        };
    }
}