using AutoMapper;
using FanPage.Api.Models.Fanfic;
using FanPage.Application.Fanfic;
using FanPage.Domain.Fanfic.Entities;
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
    
    
    /// <summary>
    ///  Create new comment
    /// </summary>
    /// <param name="comment"> comment model</param>
    /// <returns>Comment object</returns>
    public async Task Create(CommentModel comment)
    {
        var request = Context.GetHttpContext().Request; 
        var dt = _mapper.Map<CommentDto>(comment);
        var result = await _comment.AddCommentAsync(dt, request);
        await Clients.All.SendAsync("Create", result);
    }

    /// <summary>
    /// Update comment
    /// </summary>
    /// <param name="comment">comment model</param>
    /// <returns>Comment object</returns>
    public async Task Update(CommentModel comment)
    {
        var request = Context.GetHttpContext().Request;
        var dt = _mapper.Map<CommentDto>(comment);
        var result = await _comment.UpdateCommentAsync(dt, request);
        await Clients.All.SendAsync("Update", result);
    }

    /// <summary>
    ///  Delete comment
    /// </summary>
    /// <param name="id">comment id</param>
    /// <returns>Comment object</returns>
    public async Task Delete(int id)
    {
        var request = Context.GetHttpContext().Request;
        await _comment.DeleteCommentAsync(id, request);
        await Clients.All.SendAsync("Delete", id);
    }

    /// <summary>
    ///  Get comment by id
    /// </summary>
    /// <param name="id">comment id</param>
    /// <returns>Comment object</returns>
    public async Task CommentById(int id)
    {
        var request = Context.GetHttpContext().Request;

        var result = await _comment.GetCommentByCommentIdAsync(id, request);
        await Clients.All.SendAsync("CommentById", result);
    }

    /// <summary>
    /// Get comments by fanfic id
    /// </summary>
    /// <param name="fanficId">id fanfic</param>
    /// <returns>List object comments</returns>
    public async Task CommentsByFanficId(int fanficId)
    {
        var request = Context.GetHttpContext().Request;
        var result = await _comment.GetCommentsByFanficIdAsync(fanficId, request);
        await Clients.All.SendAsync("CommentsByFanficId", result);
    }

    /// <summary>
    /// Write a reply to another comment
    /// </summary>
    /// <param name="commentDto">comment object</param>
    /// <returns>Comment Object</returns>
    public async Task ReplyComment(CommentModel comment)
    {
        var request = Context.GetHttpContext().Request;
        var dt = _mapper.Map<CommentDto>(comment);
        var result = await _comment.ReplyCommentAsync(dt, request);
        await Clients.All.SendAsync("ReplyComment", result);
    }
}