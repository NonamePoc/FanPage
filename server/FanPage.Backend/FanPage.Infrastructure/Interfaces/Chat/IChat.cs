using FanPage.Application.Chat;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Interfaces.Chat;

public interface IChat
{
    Task<ChatDto> GetChatAsync(int id, string type, HttpRequest request);

    Task<List<ChatDto>> GetChatsAsync(string type, HttpRequest request);

    Task CreateMessageAsync(int chatId, string type, MessageDto message, HttpRequest request);

    Task<ChatDto> CreateAsync(ChatDto chat, HttpRequest request);

    Task<ChatDto> UpdateAsync(ChatDto chat, HttpRequest request);

    Task DeleteAsync(int id, string type, HttpRequest request);

    Task RemoveUserFromChatAsync(int chatId, string userId, string type, HttpRequest request);

    Task InviteUserToChatAsync(int chatId, string userId, string userName, HttpRequest request);

    Task<List<ChatDto>> GetChatRequestAsync(string userId, HttpRequest request);

    Task AcceptUserToChatAsync(int chatId, string userId, HttpRequest request);

    Task DeclineUserToChatAsync(int chatId, string userId, HttpRequest request);

    Task<List<Domain.Chat.Entities.Chat>> SearchChatAsync(string search);
    Task<List<ChatDto>> PrivetChat(HttpRequest request);
    Task<List<ChatDto>> PublicChat(HttpRequest request);
}