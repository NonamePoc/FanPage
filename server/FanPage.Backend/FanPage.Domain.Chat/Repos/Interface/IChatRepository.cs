using FanPage.Application.Chat;

namespace FanPage.Domain.Chat.Repos.Interface;

public interface IChatRepository
{
    Task<ChatDto> GetChatAsync(int id, string type);
    
    Task<List<ChatUserDto>> GetChatUsersAsync(int chatId);

    Task<List<ChatDto>> GetChatsAsync(string type);

    Task CreateMessageAsync(int chatId, MessageDto message);

    Task<ChatDto> CreateAsync(ChatDto chat);
    
    Task<List<Entities.Chat>> SearchChatAsync(string search);

    Task<ChatDto> UpdateAsync(ChatDto chat);

    Task DeleteAsync(int id);

    Task RemoveUserFromChatAsync(int chatId, string userId);

    Task<List<ChatDto>> GetChatRequestAsync(string userId);

    Task InviteUserToChatAsync(int chatId, string userId, string userName);

    Task AcceptUserToChatAsync(int chatId, string userId);

    Task DeclineUserToChatAsync(int chatId, string userId);
}