using FanPage.Application.Chat;
using Microsoft.AspNetCore.Http;

namespace FanPage.Domain.Chat.Repos.Interface;

public interface IChatRepository
{
    Task<ChatDto> GetByIdAsync(int id, int pageUser, int pageMessage);

    Task <bool> IsNameExistAsync(string name, string type);

    Task<ChatDto> GetChatAsync(int id);

    Task<List<ChatDto>> GetChatsUserAsync(string userName, int offset, int page);

    Task<List<ChatDto>> GetGlobalChatsAsync(int offset, int page);

    Task<List<ChatUserDto>> PrivateGetChatUsersAsync(int chatId);

    Task CreateMessageAsync(int chatId, MessageDto message);

    Task<ChatDto> CreateAsync(ChatDto chat);
    Task<List<ChatDto>> SearchChatAsync(string search,string userName);

    Task AddUserToChatAsync(int chatId, string userId, string userName);

    Task<ChatDto> UpdateAsync(int id, ChatDto chat);

    Task DeleteAsync(int id);

    Task RemoveUserFromChatAsync(int chatId, string userName);

    Task<List<ChatDto>> GetChatRequestAsync(string userName);

    Task InviteUserToChatAsync(int chatId , ICollection<ChatUserDto> chatUsers);

    Task AcceptUserToChatAsync(int chatId, string userId);

    Task DeclineUserToChatAsync(int chatId, string userName);

}
