using FanPage.Application.Fanfic;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Interfaces.Fanfic;

public interface IComment
{
    Task<CommentDto> AddCommentAsync(CommentDto commentDto, HttpRequest request);
    Task<CommentDto> UpdateCommentAsync(CommentDto commentDto, HttpRequest request);
    Task DeleteCommentAsync(int id, HttpRequest request);
    Task<CommentDto> GetCommentByFanficIdAsync(int id, HttpRequest request);
    Task<List<CommentDto>> GetCommentsByFanficIdAsync(int fanficId, HttpRequest request);
    Task<CommentDto> ReplyCommentAsync(CommentDto commentDto, HttpRequest request);
}