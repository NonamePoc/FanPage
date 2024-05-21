using AutoMapper;
using FanPage.Application.Chat;
using FanPage.Domain.Chat.Context;
using FanPage.Domain.Chat.Entities;
using FanPage.Domain.Chat.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace FanPage.Domain.Chat.Repos.Impl;

public class ChatRepository : IChatRepository
{
    private readonly ChatContext _context;

    private readonly IMapper _mapper;

    public ChatRepository(ChatContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ChatDto> GetByIdAsync(int id)
    {
        var chat = await _context.Chats
            .Include(x => x.ChatUsers)
            .Include(x => x.Messages)
            .FirstOrDefaultAsync(x => x.Id == id);



        return _mapper.Map<ChatDto>(chat);
    }

    public async Task<ChatDto> GetChatAsync(int id)
    {
        var chat = await _context
            .Chats.FindAsync(id);
        return _mapper.Map<ChatDto>(chat);
    }

    public async Task<List<ChatDto>> GetChatsUserAsync(string userName)
    {
        var chatUser = await _context.ChatUsers
            .Where(w => w.UserName == "vlasta2" && w.AcceptedRequest == true)
            .Include(x => x.Chat.Messages.OrderByDescending(m => m.ReceivedDateUtc))
            .ToListAsync();

        return _mapper.Map<List<ChatDto>>(chatUser);
    }

    public async Task<List<ChatUserDto>> PrivateGetChatUsersAsync(int chatId)
    {
        var chatUsers = await _context
            .ChatUsers.Where(w => w.ChatId == chatId && w.AcceptedRequest == true)
            .Select(s => new { s.UserId, s.UserName })
            .ToListAsync();

        return chatUsers
            .Select(s => new ChatUserDto() { UserId = s.UserId, UserName = s.UserName })
            .ToList();
    }

    public async Task<List<ChatDto>> GetChatRequestAsync(string userName)
    {
        var chats = await _context.ChatUsers
            .Where(w => w.UserName == userName || w.AcceptedRequest == false)
            .Select(s => new ChatDto
            {
                Id = s.ChatId,
                Name = s.Chat.Name,
                Type = s.Chat.Type,
                Description = s.Chat.Description,
                AuthorName = s.Chat.AuthorName,
                FriendId = s.UserId,
                //ChatUsers = new List<ChatUserDto>(),
                Messages = new List<MessageDto>()
            })
            .ToListAsync();

        return chats;
    }

    public async Task<List<ChatDto>> GetGlobalChatsAsync()
    {
        var chats = await _context.Chats
              .Where(w => w.Type == "public")
              .Include(x => x.ChatUsers)
              .Include(x => x.Messages.OrderByDescending(m => m.ReceivedDateUtc))
              .ToListAsync();

        return _mapper.Map<List<ChatDto>>(chats);
    }

    public async Task CreateMessageAsync(int chatId, MessageDto message)
    {
        var messageEntity = _mapper.Map<Message>(message);

        var existingChat = await _context.Chats.FirstOrDefaultAsync(x => x.Id == chatId);
        if (existingChat == null)
        {
            throw new Exception("Chat not found");
        }

        messageEntity.ChatId = chatId;
        await _context.Messages.AddAsync(messageEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<ChatDto> CreateAsync(ChatDto chat)
    {
        try
        {
            var chatEntity = _mapper.Map<Entities.Chat>(chat);

            if (chatEntity.ChatUsers.Count > 0)
            {
                chatEntity.ChatUsers = new List<ChatUser>();
            }
            await _context.Chats.AddAsync(chatEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ChatDto>(chatEntity);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
       
    }

    public async Task<List<ChatDto>> SearchChatAsync(string search, string username)
    {
        var searchWords = search.Split(' ');

        var userChatsQuery = _context.ChatUsers
            .Where(x => x.UserName == username)
            .Select(chatUser => chatUser.ChatId);

        var publicChatsQuery = _context.Chats
            .Where(chat => chat.Type == "public");

        var combinedQuery = publicChatsQuery.Union(
            _context.ChatUsers
                .Where(chatUser => userChatsQuery.Contains(chatUser.ChatId))
                .Select(chatUser => chatUser.Chat)
        );

        combinedQuery = searchWords.Aggregate(
            combinedQuery,
            (current, word) => current.Where(chat => chat.Name.Contains(word))
        );

        var result = await combinedQuery
            .Select(chat => new ChatDto
            {
                Id = chat.Id,
                Name = chat.Name,
                Type = chat.Type,
                AuthorName = chat.AuthorName,
                ChatUsers = new List<ChatUserDto>(),
                Description = chat.Description,
                Messages = new List<MessageDto>(),
                FriendId = ""
            })
            .ToListAsync();

        return result;
    }

    public async Task<ChatDto> UpdateAsync(int id, ChatDto chat)
    {
        var existingChat = await _context.Chats.FindAsync(id);
        if (existingChat == null)
        {
            throw new Exception("Chat not found");
        }

        existingChat.Name = chat.Name;
        existingChat.Description = chat.Description;
        existingChat.Type = chat.Type;

        await _context.SaveChangesAsync();

        return _mapper.Map<ChatDto>(existingChat);
    }

    public async Task DeleteAsync(int id)
    {
        var chat = _context.Chats.FirstOrDefault(x => x.Id == id);
        if (chat != null)
            _context.Chats.Remove(chat);
        else
            throw new Exception("Chat not found");
        await _context.SaveChangesAsync();
    }

    public async Task RemoveUserFromChatAsync(int chatId, string userName)
    {
        var chatUser = await _context.ChatUsers.FirstOrDefaultAsync(x =>
            x.ChatId == chatId && x.UserName == userName
        );
        if (chatUser != null)
            _context.ChatUsers.Remove(chatUser);
        else
            throw new Exception("Chat user not found");
        await _context.SaveChangesAsync();
    }

    public async Task InviteUserToChatAsync(int chatId, ICollection<ChatUserDto> chats)
    {
        var chat = await _context.Chats.FindAsync(chatId);

        if (chat != null)
        {
            foreach (var chatUser in chats)
            {
                var existingChatUser = await _context.ChatUsers.FirstOrDefaultAsync(x =>
                    x.ChatId == chatId && x.UserName == chatUser.UserName
                );

                if (existingChatUser != null)
                {
                    throw new Exception($"User {chatUser.UserName} is already in chat");
                }

                var newChatUser = new ChatUser
                {
                    ChatId = chatId,
                    UserName = chatUser.UserName,
                    UserId = chatUser.UserId,
                    AcceptedRequest = false
                };

                await _context.ChatUsers.AddAsync(newChatUser);
            }

            await _context.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Chat not found");
        }
    }


    public async Task AddUserToChatAsync(int chatId, string userId, string userName)
    {
        var chatUser = await _context.ChatUsers.FirstOrDefaultAsync(x =>
            x.ChatId == chatId && x.UserId == userId
        );

        if (chatUser != null)
        {
            throw new Exception("User is already in chat");
        }

        chatUser = new ChatUser
        {
            UserId = userId,
            UserName = userName,
            ChatId = chatId,
            AcceptedRequest = true
        };

        _context.ChatUsers.Add(chatUser);
        await _context.SaveChangesAsync();
    }

    public async Task AcceptUserToChatAsync(int chatId, string userName)
    {
        var chatUser = await _context.ChatUsers.FirstOrDefaultAsync(x =>
            x.ChatId == chatId && x.UserName == userName
        );

        if (chatUser == null)
        {
            throw new Exception("User is not in chat");
        }

        chatUser.AcceptedRequest = true;
        await _context.SaveChangesAsync();
    }

    public async Task DeclineUserToChatAsync(int chatId, string userName)
    {
        var chatUser = await _context.ChatUsers.FirstOrDefaultAsync(x =>
            x.ChatId == chatId && x.UserName == userName
        );

        if (chatUser == null)
        {
            throw new Exception("User is not in chat");
        }

        _context.ChatUsers.Remove(chatUser);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsNameExistAsync(string name, string type)
    {
        var chat = await _context.Chats.FirstOrDefaultAsync(x => x.Name == name && x.Type == type);
        if (chat == null)
            return false;
        return true;
    }
}