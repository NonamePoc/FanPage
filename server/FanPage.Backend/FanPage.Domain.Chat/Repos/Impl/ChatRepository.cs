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
        var chat = await _context.Chats.FindAsync(id);
        return _mapper.Map<ChatDto>(chat);
    }

    public async Task<ChatDto> GetChatAsync(int id, string type)
    {
        var chat = await _context.Chats.Where(w => type == "global" || type == "private")
            .FirstOrDefaultAsync(x => x.Id == id && x.Type == type);
        return _mapper.Map<ChatDto>(chat);
    }

    public async Task<List<ChatDto>> GetChatsUserAsync(string userName, int offset, string type)
    {
        var userChats = await _context.ChatUsers
            .Include(i => i.Chat.Name)
            .Where(x => x.UserName == userName || x.Chat.Type == type)
            .Take(offset)
            .ToListAsync();

        return userChats.Select(s => new ChatDto()
        {
            Id = s.ChatId,
            Name = s.Chat.Name,
            Type = s.Chat.Type
        }).ToList();

    }

    public async Task<List<ChatUserDto>> PrivateGetChatUsersAsync(int chatId)
    {
        var chatUsers = await _context.ChatUsers
            .Where(w => w.ChatId == chatId && w.AcceptedRequest == true)
            .Select(s => new { s.UserId, s.UserName })
            .ToListAsync();

        return chatUsers.Select(s => new ChatUserDto()
        {
            UserId = s.UserId,
            UserName = s.UserName
        }).ToList();
    }

    public async Task<List<ChatDto>> GetChatRequestAsync(string userName)
    {
        var chats = await _context.ChatUsers
            .Where(w => w.UserName == userName && w.AcceptedRequest == false)
            .Select(s => new { s.ChatId, s.Chat.Name, s.Chat.Type })
            .ToListAsync();

        return chats.Select(s => new ChatDto()
        {
            Id = s.ChatId,
            Name = s.Name,
            Type = s.Type
        }).ToList();
    }

    public async Task<List<ChatDto>> GetGlobalChatsAsync(int offset)
    {
        var chats = await _context.Chats.Where(w => w.Type == "global").Take(offset).ToListAsync();
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
        var chatEntity = _mapper.Map<Entities.Chat>(chat);
        await _context.Chats.AddAsync(chatEntity);
        await _context.SaveChangesAsync();
        return _mapper.Map<ChatDto>(chatEntity);
    }
    public async Task<List<ChatDto>> SearchChatAsync(string search, string username)
    {
        var searchWords = search.Split(' ');

        var query = _context.ChatUsers.Where(x => x.UserName == username);

        query = searchWords.Aggregate(query, (current, word) =>
            current.Where(chatUser => chatUser.Chat.Name.Contains(word)));

        var result = await query.Select(chatUser => new ChatDto
        {
            Id = chatUser.Chat.Id,
            Name = chatUser.Chat.Name,
            Type = chatUser.Chat.Type
        }).ToListAsync();

        return result;
    }


    public async Task<ChatDto> UpdateAsync(ChatDto chat)
    {
        var chatEntity = _mapper.Map<Entities.Chat>(chat);
        _context.Chats.Update(chatEntity);
        await _context.SaveChangesAsync();

        return _mapper.Map<ChatDto>(chatEntity);
    }

    public async Task DeleteAsync(int id)
    {
        var chat = _context.Chats.FirstOrDefault(x => x.Id == id);
        if (chat != null) _context.Chats.Remove(chat);
        else throw new Exception("Chat not found");
        await _context.SaveChangesAsync();
    }

    public async Task RemoveUserFromChatAsync(int chatId, string userName)
    {
        var chatUser = await _context.ChatUsers.FirstOrDefaultAsync(x => x.ChatId == chatId && x.UserName == userName);
        if (chatUser != null) _context.ChatUsers.Remove(chatUser);
        else throw new Exception("Chat user not found");
        await _context.SaveChangesAsync();
    }

    public async Task InviteUserToChatAsync(int chatId, string userId, string userName)
    {
        var chatUser = await _context.ChatUsers.FirstOrDefaultAsync(x => x.ChatId == chatId && x.UserName == userName);
        if (chatUser != null)
        {
            throw new Exception("User is already in chat");
        }

        chatUser = new ChatUser
        {
            UserId = userId,
            UserName = userName,
            ChatId = chatId,
            AcceptedRequest = false
        };

        _context.ChatUsers.Add(chatUser);
        await _context.SaveChangesAsync();
    }

    public async Task AddUserToChatAsync(int chatId, string userId, string userName)
    {
        var chatUser = await _context.ChatUsers.FirstOrDefaultAsync(x => x.ChatId == chatId && x.UserId == userId);

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

    public async Task AcceptUserToChatAsync(int chatId, string userId)
    {
        var chatUser = await _context.ChatUsers.FirstOrDefaultAsync(x => x.ChatId == chatId && x.UserId == userId);

        if (chatUser == null)
        {
            throw new Exception("User is not in chat");
        }

        chatUser.AcceptedRequest = true;
        await _context.SaveChangesAsync();
    }

    public async Task DeclineUserToChatAsync(int chatId, string userName)
    {
        var chatUser = await _context.ChatUsers.FirstOrDefaultAsync(x => x.ChatId == chatId && x.UserName == userName);

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
        if (chat == null) return false;
        return true;
    }
}