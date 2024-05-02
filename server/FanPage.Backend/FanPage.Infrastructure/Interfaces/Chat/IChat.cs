using FanPage.Application.Chat;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Interfaces.Chat;

public interface IChat
{
    Task<ChatDto> GetChatAsync(int id, int messagePage, int userPage, HttpRequest request);

    Task<List<ChatDto>> GetGlobalChats(int offset, int page, HttpRequest request);
    Task<List<ChatDto>> GetChatsUser(int offset, int page, HttpRequest request);
    Task<MessageDto> CreateMessageAsync(int chatId, MessageDto message, HttpRequest request);

    Task<ChatDto> CreateAsync(ChatDto chat, HttpRequest request);

    Task<ChatDto> UpdateAsync(int chatId,ChatDto chat, HttpRequest request);

    Task DeleteAsync(int id, HttpRequest request);

    Task RemoveUserFromChatAsync(int chatId, string userId, HttpRequest request);

    Task InviteUserToChatAsync(int chatId, List<ChatUserDto> chatUsers, HttpRequest request);

    Task<List<ChatDto>> GetChatRequestAsync(HttpRequest request);

    Task AcceptUserToChatAsync(int chatId, HttpRequest request);

    Task DeclineUserToChatAsync(int chatId, HttpRequest request);

    Task<List<ChatDto>> SearchChatAsync(string search, HttpRequest request);
}
