using FanPage.Application.Chat;
using FanPage.Common.Interfaces;
using FanPage.Domain.Chat.Repos.Interface;
using FanPage.Exceptions;
using FanPage.Infrastructure.Interfaces.Chat;
using FanPage.Infrastructure.Interfaces.User;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Implementations.Chat;

public class ChatService : IChat
{
    private readonly IChatRepository _chatRepository;
    private readonly IJwtTokenManager _jwtTokenManager;
    private readonly IAdmin _admin;

    public ChatService(
        IChatRepository chatRepository,
        IJwtTokenManager jwtTokenManager,
        IAdmin admin
    )
    {
        _chatRepository = chatRepository;
        _jwtTokenManager = jwtTokenManager;
        _admin = admin;
    }

    public async Task<ChatDto> GetChatAsync(int id, string type, HttpRequest request)
    {
        var userName = _jwtTokenManager.GetUserNameFromToken(request);
        if (userName == null)
        {
            throw new ChatException($"Error Chat");
        }

        var chatUsers = await _chatRepository.GetChatUsersAsync(id);
        var chat = await _chatRepository.GetChatAsync(id, type);

        return new ChatDto
        {
            Id = chat.Id,
            Type = chat.Type,
            Name = chat.Name,
            ChatUsers = chatUsers
                .Select(u => new ChatUserDto { UserId = u.UserId, UserName = u.UserName })
                .ToList()
        };
    }

    public async Task<List<ChatDto>> GetChatsAsync(string type, HttpRequest request)
    {
        var userName = _jwtTokenManager.GetUserNameFromToken(request);
        if (userName == null)
        {
            throw new ChatException($"Error Chat");
        }

        var chats = await _chatRepository.GetChatsAsync(type);

        return chats
            .Select(c => new ChatDto
            {
                Id = c.Id,
                Type = c.Type,
                Name = c.Name
            })
            .ToList();
    }

    public async Task CreateMessageAsync(
        int chatId,
        string type,
        MessageDto message,
        HttpRequest request
    )
    {
        var userName = _jwtTokenManager.GetUserNameFromToken(request);
        var chat = await _chatRepository.GetChatAsync(chatId, type);
        if (userName == null || chat == null)
        {
            throw new ChatException($"Error Chat");
        }

        await _chatRepository.CreateMessageAsync(chatId, message);
    }

    public async Task<ChatDto> CreateAsync(ChatDto chat, HttpRequest request)
    {
        var userName = _jwtTokenManager.GetUserNameFromToken(request);
        var userId = _jwtTokenManager.GetUserIdFromToken(request);
        if (userName == null)
        {
            throw new ChatException($"Error Chat");
        }
        var userChat = new ChatUserDto
        {
            ChatId = chat.Id,
            UserName = userName,
            UserId = userId,
            AcceptedRequest = false
        };
        var chatEntity = await _chatRepository.CreateAsync(chat, userChat);
        return new ChatDto
        {
            Id = chatEntity.Id,
            Type = chatEntity.Type,
            Name = chatEntity.Name
        };
    }

    public async Task<ChatDto> UpdateAsync(ChatDto chat, HttpRequest request)
    {
        var userName = _jwtTokenManager.GetUserNameFromToken(request);
        var userRole = await _admin.GetUserRoleAsync(userName);
        var chatEntity = await _chatRepository.GetChatAsync(chat.Id, chat.Type);

        // if user not admin or moderator and not author chat
        if (
            userRole.Role != "Admin"
            && userRole.Role != "Moderator"
            && chatEntity.AuthorName != userName
        )
        {
            throw new ChatException($"Not permission to update chat");
        }

        chatEntity.Name = chat.Name ?? chatEntity.Name;
        chatEntity.Description = chat.Description ?? chatEntity.Description;
        chatEntity.Type = chat.Type ?? chatEntity.Type;

        var result = await _chatRepository.UpdateAsync(chat);

        return new ChatDto
        {
            Id = result.Id,
            Type = result.Type,
            Name = result.Name
        };
    }

    public async Task DeleteAsync(int id, string type, HttpRequest request)
    {
        var userName = _jwtTokenManager.GetUserNameFromToken(request);
        var chat = await _chatRepository.GetChatAsync(id, type);
        if (chat.AuthorName != userName)
        {
            throw new ChatException($"Not permission to delete chat");
        }

        await _chatRepository.DeleteAsync(id);
    }

    public async Task RemoveUserFromChatAsync(
        int chatId,
        string userId,
        string type,
        HttpRequest request
    )
    {
        var userName = _jwtTokenManager.GetUserNameFromToken(request);
        var userRole = await _admin.GetUserRoleAsync(userName);
        var chatEntity = await _chatRepository.GetChatAsync(chatId, type);
        if (
            userRole.Role != "Admin"
            && userRole.Role != "Moderator"
            && chatEntity.AuthorName != userName
        )
        {
            throw new ChatException($"Not permission to update chat");
        }

        await _chatRepository.RemoveUserFromChatAsync(chatId, userId);
    }

    public async Task InviteUserToChatAsync(
        int chatId,
        string userId,
        string userName,
        HttpRequest request
    )
    {
        var userNameFromToken = _jwtTokenManager.GetUserNameFromToken(request);
        var userRole = await _admin.GetUserRoleAsync(userNameFromToken);
        if (userRole.Role != "Admin" && userRole.Role != "Moderator")
        {
            throw new ChatException($"Not permission to update chat");
        }

        await _chatRepository.InviteUserToChatAsync(chatId, userId, userName);
    }

    public async Task<List<ChatDto>> GetChatRequestAsync(string userId, HttpRequest request)
    {
        var userNameFromToken = _jwtTokenManager.GetUserNameFromToken(request);
        if (userNameFromToken == null)
        {
            throw new ChatException($"Error Chat");
        }

        var chats = await _chatRepository.GetChatRequestAsync(userId);

        return chats
            .Select(c => new ChatDto
            {
                Id = c.Id,
                Type = c.Type,
                Name = c.Name
            })
            .ToList();
    }

    public async Task AcceptUserToChatAsync(int chatId, string userId, HttpRequest request)
    {
        var userNameFromToken = _jwtTokenManager.GetUserNameFromToken(request);
        var chatRequest = await _chatRepository.GetChatRequestAsync(userId);
        var chat = chatRequest.FirstOrDefault(x => x.Id == chatId);
        if (chat == null)
        {
            throw new ChatException($"Error Chat");
        }

        if (userNameFromToken == null)
        {
            throw new ChatException($"Error Chat");
        }

        await _chatRepository.AcceptUserToChatAsync(chatId, userId);
    }

    public async Task DeclineUserToChatAsync(int chatId, string userId, HttpRequest request)
    {
        var userNameFromToken = _jwtTokenManager.GetUserNameFromToken(request);
        var chatRequest = await _chatRepository.GetChatRequestAsync(userId);
        var chat = chatRequest.FirstOrDefault(x => x.Id == chatId);
        if (chat == null)
        {
            throw new ChatException($"Error Chat");
        }

        if (userNameFromToken == null)
        {
            throw new ChatException($"Error Chat");
        }

        await _chatRepository.DeclineUserToChatAsync(chatId, userId);
    }

    public async Task<List<Domain.Chat.Entities.Chat>> SearchChatAsync(string search)
    {
        var chatScreach = await _chatRepository.SearchChatAsync(search);
        return chatScreach;
    }

    public async Task<List<ChatDto>> PublicChat(HttpRequest request)
    {
        var userId = _jwtTokenManager.GetUserIdFromToken(request);
        var chat = await _chatRepository.GetPublicChat(userId);
        return chat;
    }

    public async Task<List<ChatDto>> PrivetChat(HttpRequest request)
    {
        var userId = _jwtTokenManager.GetUserIdFromToken(request);
        var chat = await _chatRepository.GetPrivetChat(userId);
        return chat;
    }
}
