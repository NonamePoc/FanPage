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
    public async Task JoinChat(int chatId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());
        var request = Context.GetHttpContext().Request;
        var result = await _chat.GetChatAsync(chatId, request);
        await Clients.All.SendAsync("JoinChat", result);
    }

    // leave chat

    public async Task LeaveChat(int chatId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId.ToString());
        var request = Context.GetHttpContext().Request;
        var result = await _chat.GetChatAsync(chatId, request);
        await Clients.All.SendAsync("LeaveChat", result);
    }

    /// <summary>
    ///  Get object chat
    /// </summary>
    /// <param name="chatId">id chat</param>
    /// <param name="type">private or public</param>
    /// <returns>Chat object</returns>

    public async Task Chat(int chatId)
    {
        var request = Context.GetHttpContext().Request;
        var result = await _chat.GetChatAsync(chatId, request);
        await Clients.All.SendAsync("GetChat", result);
    }

    /// <summary>
    /// Get global chats
    /// </summary>
    /// <param name="offset">count chat</param>
    /// <returns>List chat object</returns>
    public async Task GlobalChats(int offset)
    {
        var request = Context.GetHttpContext().Request;
        var result = await _chat.GetGlobalChats(offset, request);
        await Clients.All.SendAsync("GlobalChats", result);
    }

    /// <summary>
    ///  Get user chats
    /// </summary>
    /// <param name="offset">chat count</param>
    /// <param name="type">public or private</param>
    /// <returns>List user chat object</returns>
    public async Task ChatsUser(int offset, string type)
    {
        var request = Context.GetHttpContext().Request;
        var result = await _chat.GetChatsUser(offset, type, request);
        await Clients.All.SendAsync("ChatUser", result);
    }

    /// <summary>
    ///  Create chat
    /// </summary>
    /// <param name="chat">object chat</param>
    /// <returns>Object chat</returns>
    public async Task Create(ChatModel chat)
    {
        var request = Context.GetHttpContext().Request;
        var dt = _mapper.Map<ChatDto>(chat);
        var result = await _chat.CreateAsync(dt, request);
        await Clients.All.SendAsync("Create", result);
    }

    /// <summary>
    /// Update chat
    /// </summary>
    /// <param name="chat">object chat</param>
    /// <returns>Object chat</returns>
    public async Task Update(ChatModel chat)
    {
        var request = Context.GetHttpContext().Request;
        var dt = _mapper.Map<ChatDto>(chat);
        var result = await _chat.UpdateAsync(dt, request);
        await Clients.All.SendAsync("Update", result);
    }

    /// <summary>
    ///  Delete chat
    /// </summary>
    /// <param name="id">id chat</param>
    /// <returns>Status code</returns>
    public async Task Delete(int id)
    {
        var request = Context.GetHttpContext().Request;
        await _chat.DeleteAsync(id, request);
        await Clients.All.SendAsync("Delete", "Complete");
    }

    /// <summary>
    /// Add message to chat
    /// </summary>
    /// <param name="chatId">chat id</param>
    /// <param name="message">text message</param>
    /// <returns>Message object</returns>
    public async Task Message(int chatId, MessageModel message)
    {
        var request = Context.GetHttpContext().Request;
        var dt = _mapper.Map<MessageDto>(message);
        var result = await _chat.CreateMessageAsync(chatId, dt, request);
        await Clients.All.SendAsync("AddMessage", result);
    }

    /// <summary>
    /// Invite user to chat
    /// </summary>
    /// <param name="chatId">chat id</param>
    /// <param name="userName">friend name</param>
    /// <returns>Complete</returns>
    public async Task InviteUser(int chatId, string userName)
    {
        var request = Context.GetHttpContext().Request;
        await _chat.InviteUserToChatAsync(chatId, userName, request);
        await Clients.All.SendAsync("InviteUser", "Complete");
    }

    /// <summary>
    /// User accept invite to chat
    /// </summary>
    /// <param name="chatId">chat id</param>
    /// <returns>Complete</returns>
    public async Task UserAccept(int chatId)
    {
        var request = Context.GetHttpContext().Request;
        await _chat.AcceptUserToChatAsync(chatId, request);
        await Clients.All.SendAsync("UserAccept", "Complete");
    }

    /// <summary>
    ///  User decline invite to chat
    /// </summary>
    /// <param name="chatId">chat id</param>
    /// <returns>Complete</returns>
    public async Task UserDecline(int chatId)
    {
        var request = Context.GetHttpContext().Request;
        await _chat.DeclineUserToChatAsync(chatId, request);
        await Clients.All.SendAsync("UserLeave", "Complete");
    }

    /// <summary>
    /// Chats request user
    /// </summary>
    /// <returns></returns>
    public async Task ChatsRequestUser()
    {
        var request = Context.GetHttpContext().Request;
        var result = await _chat.GetChatRequestAsync(request);
        await Clients.All.SendAsync("ChatRequestUser", result);
    }

    // Зробити що декілька юзерів можна зразу добавити в чат добавити сюди чат

   
    /// <summary>
    ///  Chat search by name
    /// </summary>
    /// <param name="search">name fanfic</param>
    /// <returns></returns>
    public async Task Search(string search)
    {
        var request = Context.GetHttpContext().Request;
        var result = await _chat.SearchChatAsync(search, request);
        await Clients.All.SendAsync("Search", result);
    }
}
