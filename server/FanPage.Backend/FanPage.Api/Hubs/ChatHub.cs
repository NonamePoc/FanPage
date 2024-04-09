using AutoMapper;
using FanPage.Api.Models.Chat;
using FanPage.Application.Chat;
using FanPage.Infrastructure.Interfaces.Chat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace FanPage.Api.Hubs;

[Authorize(AuthenticationSchemes = "Bearer")]
public class ChatHub : Hub
{
    private readonly IChat _chat;

    private readonly IHubContext<ChatHub> _hubContext;

    private readonly IMapper _mapper;

    public ChatHub(IChat chat, IHubContext<ChatHub> hubContext, IMapper mapper)
    {
        _chat = chat;
        _hubContext = hubContext;
        _mapper = mapper;
    }

    // join to chat
    public async Task JoinChat(int chatId, string type)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());
        var request = Context.GetHttpContext().Request;
        var result = await _chat.GetChatAsync(chatId, request);
        await Clients.All.SendAsync("JoinChat", result);
    }

    // leave chat

    public async Task LeaveChat(int chatId, string type)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId.ToString());
        var request = Context.GetHttpContext().Request;
        var result = await _chat.GetChatAsync(chatId, request);
        await Clients.All.SendAsync("LeaveChat", result);
    }

    public async Task GetChat(int id, string type)
    {
        var request = Context.GetHttpContext().Request;
        var result = await _chat.GetChatAsync(id, request);
        await Clients.All.SendAsync("GetChat", result);
    }

    public async Task GetChats(int id)
    {
        var request = Context.GetHttpContext().Request;
        var result = await _chat.GetChatAsync(id, request);
        await Clients.All.SendAsync("GetChats", result);
    }

    public async Task CreateMessage(int offset, string type, MessageModel message)
    {
        var request = Context.GetHttpContext().Request;
        var result = await _chat.GetChatsUser(offset, type, request);
        await Clients.All.SendAsync("ChatUser", result);
    }

    public async Task CreateChat(ChatModel chat)
    {
        var request = Context.GetHttpContext().Request;
        var dt = _mapper.Map<ChatDto>(chat);
        var result = await _chat.CreateAsync(dt, request);
        await Clients.All.SendAsync("CreateChat", result);
    }

    public async Task UpdateChat(ChatModel chat)
    {
        var request = Context.GetHttpContext().Request;
        var dt = _mapper.Map<ChatDto>(chat);
        var result = await _chat.UpdateAsync(dt, request);
        await Clients.All.SendAsync("UpdateChat", result);
    }

    public async Task DeleteChat(int id, string type)
    {
        var request = Context.GetHttpContext().Request;
        await _chat.DeleteAsync(id, request);
        await Clients.All.SendAsync("DeleteChat", id);
    }

    public async Task InviteUserToChat(int chatId, string userId, string userName)
    {
        var request = Context.GetHttpContext().Request;
        await _chat.InviteUserToChatAsync(chatId, userName, request);
        await Clients.All.SendAsync("InviteUserToChat", chatId, userId, userName);
    }

    public async Task AcceptUserToChat(int chatId, string userId)
    {
        var request = Context.GetHttpContext().Request;
        await _chat.AcceptUserToChatAsync(chatId, request);
        await Clients.All.SendAsync("AcceptUserToChat", chatId, userId);
    }

    public async Task DeclineUserToChat(int chatId, string userId)
    {
        var request = Context.GetHttpContext().Request;
        await _chat.DeclineUserToChatAsync(chatId, request);
        await Clients.All.SendAsync("DeclineUserToChat", chatId, userId);
    }

    public async Task GetUserChatRequest(string userId)
    {
        var request = Context.GetHttpContext().Request;
        var result = await _chat.GetChatRequestAsync(request);
        await Clients.All.SendAsync("GetUserChatRequest", result);
    }

    public async Task RemoveUserFromChat(int chatId, string userId, string type)
    {
        var request = Context.GetHttpContext().Request;
        var result = await _chat.GetChatRequestAsync(request);
        await Clients.All.SendAsync("ChatRequestUser", result);
    }

    public async Task SearchChat(string search)
    {
        var request = Context.GetHttpContext().Request;
        var result = await _chat.SearchChatAsync(search, request);
        await Clients.All.SendAsync("SearchChat", result);
    }
}
