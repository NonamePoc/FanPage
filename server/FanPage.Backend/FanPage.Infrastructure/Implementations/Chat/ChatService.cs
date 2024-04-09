using FanPage.Application.Chat;
using FanPage.Common.Interfaces;
using FanPage.Domain.Account.Entities;
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
    private readonly IdentityUserManager _userManager;
    private readonly IFriend _friend;

    public ChatService(
        IChatRepository chatRepository,
        IJwtTokenManager jwtTokenManager,
        IAdmin admin,
        IdentityUserManager userManager,
        IFriend friend
    )
    {
        _chatRepository = chatRepository;
        _jwtTokenManager = jwtTokenManager;
        _admin = admin;
        _userManager = userManager;
        _friend = friend;
    }

    public async Task<ChatDto> GetChatAsync(int id, HttpRequest request)
    {
        var userName = _jwtTokenManager.GetUserNameFromToken(request);
        if (userName == null)
        {
            throw new ChatException($"Error Chat");
        }

        var chatUsers = await _chatRepository.PrivateGetChatUsersAsync(id);
        var chat = await _chatRepository.GetByIdAsync(id);

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

    public async Task<List<ChatDto>> GetGlobalChats(int offset, HttpRequest request)
    {
        var userName = _jwtTokenManager.GetUserNameFromToken(request);
        if (userName == null)
        {
            throw new ChatException($"Error Chat");
        }

        var chats = await _chatRepository.GetGlobalChatsAsync(offset);

        return chats
            .Select(c => new ChatDto
            {
                Id = c.Id,
                Type = c.Type,
                Name = c.Name,
                Description = c.Description,
                AuthorName = c.AuthorName,
            })
            .ToList();
    }

    public async Task<List<ChatDto>> GetChatsUser(int offset, string type, HttpRequest request)
    {
        var userName = _jwtTokenManager.GetUserNameFromToken(request);
        if (userName == null)
        {
            throw new ChatException($"Error Chat");
        }

        var result = await _chatRepository.GetChatsUserAsync(userName, offset, type);

        return result
            .Select(c => new ChatDto
            {
                Id = c.Id,
                Type = c.Type,
                Name = c.Name,
                Description = c.Description,
                AuthorName = c.AuthorName,
            })
            .ToList();
    }

    public async Task<MessageDto> CreateMessageAsync(
        int chatId,
        MessageDto message,
        HttpRequest request
    )
    {
        message.ChatId = chatId;
        var userId = _jwtTokenManager.GetUserIdFromToken(request);
        var chat = await _chatRepository.GetByIdAsync(message.ChatId);
        if (userId == null || chat == null)
        {
            throw new ChatException($"Error Chat");
        }

        await _chatRepository.CreateMessageAsync(message.ChatId, message);

        return new MessageDto
        {
            Content = message.Content,
            ReceivedDateUtc = DateTime.UtcNow,
            ChatId = chat.Id,
            SenderId = message.SenderId,
        };
    }

    public async Task<ChatDto> CreateAsync(ChatDto chat, HttpRequest request)
    {
        try
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            var userId = _jwtTokenManager.GetUserIdFromToken(request);
            var friend = await _userManager.FindByIdAsync(chat.FriendId);

            if (userName == null)
            {
                throw new ChatException($"Error Chat");
            }

            chat.AuthorName = userName;
            var chatExist = await _chatRepository.IsNameExistAsync(chat.Name, "public");
            if (chatExist)
            {
                throw new ChatException($"Chat with this name already exist");
            }

            var chatEntity = await _chatRepository.CreateAsync(chat);

            await _chatRepository.AddUserToChatAsync(chatEntity.Id, userId, userName);

            if (chat.Type == "private" && friend != null)
            {
                var isFriend = await _friend.GetUserFriend(userId, chat.FriendId);
                if (!isFriend)
                {
                    throw new ChatException($"This not you friend");
                }
                await _chatRepository.AddUserToChatAsync(
                    chatEntity.Id,
                    chat.FriendId,
                    friend.UserName
                );
            }

            if (chat.Type == "public" && friend != null)
            {
                var isFriend = await _friend.GetUserFriend(userId, chat.FriendId);
                if (!isFriend)
                {
                    throw new ChatException($"This not you friend");
                }
                await _chatRepository.AddUserToChatAsync(chatEntity.Id, userId, userName);
            }

            return new ChatDto
            {
                Id = chatEntity.Id,
                Type = chatEntity.Type,
                Name = chatEntity.Name
            };
        }
        catch (Exception e)
        {
            throw new ChatException("Error create chat" + e.Message);
        }
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

    public async Task DeleteAsync(int id, HttpRequest request)
    {
        var userName = _jwtTokenManager.GetUserNameFromToken(request);
        var chat = await _chatRepository.GetByIdAsync(id);
        if (chat.AuthorName != userName)
        {
            throw new ChatException($"Not permission to delete chat");
        }

        await _chatRepository.DeleteAsync(id);
    }

    public async Task RemoveUserFromChatAsync(
        int chatId,
        string userChatName,
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

        await _chatRepository.RemoveUserFromChatAsync(chatId, userChatName);
    }

    public async Task InviteUserToChatAsync(int chatId, string userName, HttpRequest request)
    {
        var userFriend = await _userManager.FindByNameAsync(userName);
        var userNameFromToken = _jwtTokenManager.GetUserNameFromToken(request);
        var isFriend = await _friend.GetUserFriend(userNameFromToken, userName);
        if (isFriend)
        {
            var chat = new ChatDto
            {
                AuthorName = userNameFromToken,
                Name = userNameFromToken + " " + userName,
                Type = "private",
                FriendId = userFriend.Id,
                ChatUsers = new List<ChatUserDto>
                {
                    new ChatUserDto { UserId = userFriend.Id, UserName = userName }
                },
                Messages = new List<MessageDto>()
            };
            await _chatRepository.CreateAsync(chat);
        }
        else
        {
            if (userName == null || userFriend.Id == null)
            {
                throw new ChatException($"Username or UserId is null");
            }

            await _chatRepository.InviteUserToChatAsync(chatId, userFriend.Id, userName);
        }
    }

    public async Task AcceptUserToChatAsync(int chatId, HttpRequest request)
    {
        var userNameFromToken = _jwtTokenManager.GetUserNameFromToken(request);
        var chatRequest = await _chatRepository.GetChatRequestAsync(userNameFromToken);
        var chat = chatRequest.FirstOrDefault(x => x.Id == chatId);
        if (chat == null)
        {
            throw new ChatException($"Error Chat");
        }

        if (userNameFromToken == null)
        {
            throw new ChatException($"Error Chat");
        }

        await _chatRepository.AcceptUserToChatAsync(chatId, userNameFromToken);
    }

    public async Task DeclineUserToChatAsync(int chatId, HttpRequest request)
    {
        var userNameFromToken = _jwtTokenManager.GetUserNameFromToken(request);
        var chatRequest = await _chatRepository.GetChatRequestAsync(userNameFromToken);
        var chat = chatRequest.FirstOrDefault(x => x.Id == chatId);
        if (chat == null)
        {
            throw new ChatException($"Error Chat");
        }

        if (userNameFromToken == null)
        {
            throw new ChatException($"Error Chat");
        }

        await _chatRepository.DeclineUserToChatAsync(chatId, userNameFromToken);
    }

    public async Task<List<ChatDto>> GetChatRequestAsync(HttpRequest request)
    {
        var userNameFromToken = _jwtTokenManager.GetUserNameFromToken(request);
        if (userNameFromToken == null)
        {
            throw new ChatException($"Error Chat");
        }

        var chats = await _chatRepository.GetChatRequestAsync(userNameFromToken);

        return chats
            .Select(c => new ChatDto
            {
                Id = c.Id,
                Type = c.Type,
                Name = c.Name
            })
            .ToList();
    }

    // вдосконалення чату юзер може бачити в пошуку свої приватні чати
    public async Task<List<ChatDto>> SearchChatAsync(string search, HttpRequest request)
    {
        var username = _jwtTokenManager.GetUserNameFromToken(request);
        var chatScreach = await _chatRepository.SearchChatAsync(search, username);
        return chatScreach;
    }
}
