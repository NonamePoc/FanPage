using AutoMapper;
using FanPage.Api.Models.Chat;
using FanPage.Api.ViewModels;
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
    //public async Task JoinChat(int chatId)
    //{
    //    await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());
    //    var request = Context.GetHttpContext().Request;
    //    var result = await _chat.GetChatAsync(chatId, request);
    //    await Clients.All.SendAsync("JoinChat", result);
    //}

    //// leave chat

    //public async Task LeaveChat(int chatId)
    //{
    //    await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId.ToString());
    //    var request = Context.GetHttpContext().Request;
    //    var result = await _chat.GetChatAsync(chatId, request);
    //    await Clients.All.SendAsync("LeaveChat", result);
    //}

    /// <summary>
    ///  Get object chat
    /// </summary>
    /// <param name="chatId">id chat</param>
    /// <returns>Chat object</returns>

    public async Task GetChat(int chatId, int messagePage, int userPage)
    {
        try
        {
            var request = Context.GetHttpContext().Request;
            var result = await _chat.GetChatAsync(chatId, messagePage, userPage, request);
            await Clients.All.SendAsync("GetChat", result);
        }
        catch (Exception e)
        {
            await Clients.All.SendAsync("GetChat", $"Error GetChat:  {e.Message}");
        }
    }

    /// <summary>
    /// Get global chats
    /// </summary>
    /// <param name="offset">count chat</param>
    /// <returns>List chat object</returns>
    public async Task GlobalChats(int offset, int page)
    {
        try
        {
            var request = Context.GetHttpContext().Request;
            var result = await _chat.GetGlobalChats(offset, page, request);
            await Clients.All.SendAsync("GlobalChats", result);
        }
        catch (Exception e)
        {
            await Clients.All.SendAsync("GlobalChats", $"Error GlobalChats:  {e.Message}");
        }
    }

    /// <summary>
    ///  Get user chats
    /// </summary>
    /// <param name="offset">chat count</param>
    /// <param name="page">page</param>
    /// <returns>List user chat object</returns>
    public async Task ChatsUser(int offset, int page)
    {
        try
        {
            var request = Context.GetHttpContext().Request;
            var result = await _chat.GetChatsUser(offset, page, request);
            await Clients.All.SendAsync("ChatsUser", result);
        }
        catch (Exception e)
        {
            await Clients.All.SendAsync("ChatsUser", $"Error ChatsUser:  {e.Message}");
        }
    }

    /// <summary>
    ///  Create chat
    /// </summary>
    /// <param name="chat">object chat</param>
    /// <returns>Object chat</returns>
    public async Task Create(ChatModel chat)
    {
        try
        {
            var request = Context.GetHttpContext().Request;
            var dt = _mapper.Map<ChatDto>(chat);
            var result = await _chat.CreateAsync(dt, request);
            await Clients.All.SendAsync("Create", result);
        }
        catch (Exception e)
        {
            await Clients.All.SendAsync("Create", $"Error Create:  {e.Message}");
        }
    }

    /// <summary>
    /// Update chat
    /// </summary>
    /// <param name="chat">object chat</param>
    /// <returns>Object chat</returns>
    public async Task Update(int chatId, ChatModel chat)
    {
        try
        {
            var request = Context.GetHttpContext().Request;
            var dt = _mapper.Map<ChatDto>(chat);
            var result = await _chat.UpdateAsync(chatId, dt, request);
            await Clients.All.SendAsync("Update", result);
        }
        catch (Exception e)
        {
            await Clients.All.SendAsync("Update", $"Error Update:  {e.Message}");
        }
    }

    /// <summary>
    ///  Delete chat
    /// </summary>
    /// <param name="id">id chat</param>
    /// <returns>Status code</returns>
    public async Task Delete(int id)
    {
        try
        {
            var request = Context.GetHttpContext().Request;
            await _chat.DeleteAsync(id, request);
            await Clients.All.SendAsync("Delete", "Complete");
        }
        catch (Exception e)
        {
            await Clients.All.SendAsync("Delete", $"Error: {e.Message}");
        }
    }


    /// <summary>
    ///  Remove user from chat if user is admin and author chat
    /// </summary>
    /// <param name="chatId"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public async Task RemoveUserFromChat(int chatId, string userName)
    {
        try
        {
            var request = Context.GetHttpContext().Request;
            await _chat.RemoveUserFromChatAsync(chatId, userName, request);
            await Clients.All.SendAsync("RemoveUserFromChat", "Complete");
        }
        catch (Exception e)
        {
            await Clients.All.SendAsync("RemoveUserFromChat", $"Error RemoveUserFromChat:  {e.Message}");
        }
    }

    /// <summary>
    /// Add message to chat
    /// </summary>
    /// <param name="chatId">chat id</param>
    /// <param name="message">text message</param>
    /// <returns>Message object</returns>
    public async Task Message(int chatId, MessageViewModel message)
    {
        try
        {
            var request = Context.GetHttpContext().Request;
            var dt = _mapper.Map<MessageDto>(message);
            var result = await _chat.CreateMessageAsync(chatId, dt, request);
            await Clients.All.SendAsync("Message", result);
        }
        catch (Exception e)
        {
            await Clients.All.SendAsync("Message", $"Error Message:  {e.Message}");
        }
    }

    /// <summary>
    /// Invite user to chat
    /// </summary>
    /// <param name="chatId">chat id</param>
    /// <param name="userName">friend name</param>
    /// <returns>Complete</returns>
    public async Task InviteUsers(int chatId, List<ChatUserModel> users)
    {
        try
        {
            var request = Context.GetHttpContext().Request;
            var dto = _mapper.Map<List<ChatUserDto>>(users);
            await _chat.InviteUserToChatAsync(chatId, dto, request);
            await Clients.All.SendAsync("InviteUsers", "Complete");
        }
        catch (Exception e)
        {
            await Clients.All.SendAsync("InviteUsers", $"Error InviteUser:  {e.Message}");
        }
    }

    /// <summary>
    /// User accept invite to chat
    /// </summary>
    /// <param name="chatId">chat id</param>
    /// <returns>Complete</returns>
    public async Task UserAccept(int chatId)
    {
        try
        {
            var request = Context.GetHttpContext().Request;
            await _chat.AcceptUserToChatAsync(chatId, request);
            await Clients.All.SendAsync("UserAccept", "Complete");
        }
        catch (Exception e)
        {
            await Clients.All.SendAsync("UserAccept", $"Error UserAccept:  {e.Message}");
        }
    }

    /// <summary>
    ///  User decline invite to chat
    /// </summary>
    /// <param name="chatId">chat id</param>
    /// <returns>Complete</returns>
    public async Task UserDecline(int chatId)
    {
        try
        {
            var request = Context.GetHttpContext().Request;
            await _chat.DeclineUserToChatAsync(chatId, request);
            await Clients.All.SendAsync("UserDecline", "Complete");
        }
        catch (Exception e)
        {
            await Clients.All.SendAsync("UserDecline", $"Error UserDecline:  {e.Message}");
        }
    }

    /// <summary>
    /// Chats request user
    /// </summary>
    /// <returns></returns>
    public async Task ChatsRequestUser()
    {
        try
        {
            var request = Context.GetHttpContext().Request;
            var result = await _chat.GetChatRequestAsync(request);
            await Clients.All.SendAsync("ChatRequestUser", result);
        }
        catch (Exception e)
        {
            await Clients.All.SendAsync("ChatRequestUser", $"Error ChatRequestUser:  {e.Message}");
        }
    }

    // Зробити що декілька юзерів можна зразу добавити в чат добавити сюди чат

    /// <summary>
    ///  Chat search by name
    /// </summary>
    /// <param name="search">name fanfic</param>
    /// <returns></returns>
    public async Task Search(string search)
    {
        try
        {
            var request = Context.GetHttpContext().Request;
            var result = await _chat.SearchChatAsync(search, request);
            await Clients.All.SendAsync("Search", result);
        }
        catch (Exception e)
        {
            await Clients.All.SendAsync("Search", $"Error Search:  {e.Message}");
        }
    }
}