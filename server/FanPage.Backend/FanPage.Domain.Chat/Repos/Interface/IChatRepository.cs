using FanPage.Application.Chat;
using Microsoft.AspNetCore.Http;

namespace FanPage.Domain.Chat.Repos.Interface;

public interface IChatRepository
{
    Task<ChatDto> GetByIdAsync(int id);

    Task <bool> IsNameExistAsync(string name, string type);

    Task<ChatDto> GetChatAsync(int id, string type);

    Task<List<ChatDto>> GetChatsUserAsync(string userName, int offset,string type);

    Task<List<ChatDto>> GetGlobalChatsAsync(int offset);

    Task<List<ChatUserDto>> PrivateGetChatUsersAsync(int chatId);

    Task CreateMessageAsync(int chatId, MessageDto message);

    Task<ChatDto> CreateAsync(ChatDto chat);
    Task<List<ChatDto>> SearchChatAsync(string search,string userName);

    Task AddUserToChatAsync(int chatId, string userId, string userName);

    Task<ChatDto> UpdateAsync(ChatDto chat);

    Task DeleteAsync(int id);

    Task RemoveUserFromChatAsync(int chatId, string userName);

    Task<List<ChatDto>> GetChatRequestAsync(string userName);

    Task InviteUserToChatAsync(int chatId, string userId, string userName);

    Task AcceptUserToChatAsync(int chatId, string userId);

    Task DeclineUserToChatAsync(int chatId, string userName);

}
