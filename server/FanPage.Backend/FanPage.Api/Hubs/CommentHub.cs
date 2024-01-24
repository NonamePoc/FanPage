using AutoMapper;
using FanPage.Api.Models.Fanfic;
using FanPage.Application.Fanfic;
using FanPage.Infrastructure.Interfaces.Fanfic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace FanPage.Api.Hubs;

[Authorize(AuthenticationSchemes = "Bearer")]
public class CommentHub : Hub
{
    private readonly IComment _comment;

    private readonly IHubContext<CommentHub> _hubContext;
    
    private readonly IMapper _mapper;
    
    public CommentHub(IComment comment, IHubContext<CommentHub> hubContext, IMapper mapper)
    {
        _comment = comment;
        _hubContext = hubContext;
        _mapper = mapper;
    }
    
    
    public async Task AddComment(CommentModel comment)
    {
        var request = Context.GetHttpContext().Request;
        var dt = _mapper.Map<CommentDto>(comment);
        var result = await _comment.AddCommentAsync(dt, request);
        await Clients.All.SendAsync("AddComment", result);
    }

    public async Task UpdateComment(CommentModel comment)
    {
        var request = Context.GetHttpContext().Request;
        var dt = _mapper.Map<CommentDto>(comment);
        var result = await _comment.UpdateCommentAsync(dt, request);
        await Clients.All.SendAsync("UpdateComment", result);
    }

    public async Task DeleteComment(int id)
    {
        var request = Context.GetHttpContext().Request;
        await _comment.DeleteCommentAsync(id, request);
        await Clients.All.SendAsync("DeleteComment", id);
    }

    public async Task GetCommentByFanficId(int id)
    {
        var request = Context.GetHttpContext().Request;

        var result = await _comment.GetCommentByFanficIdAsync(id, request);
        await Clients.All.SendAsync("GetCommentByFanficId", result);
    }

    public async Task GetCommentsByFanficId(int fanficId)
    {
        var request = Context.GetHttpContext().Request;
        var result = await _comment.GetCommentsByFanficIdAsync(fanficId, request);
        await Clients.All.SendAsync("GetCommentsByFanficId", result);
    }

    public async Task ReplyComment(CommentDto commentDto)
    {
        var request = Context.GetHttpContext().Request;
        var result = await _comment.ReplyCommentAsync(commentDto, request);
        await Clients.All.SendAsync("ReplyComment", result);
    }
}