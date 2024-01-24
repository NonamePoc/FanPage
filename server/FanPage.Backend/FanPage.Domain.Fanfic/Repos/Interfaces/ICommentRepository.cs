using FanPage.Application.Fanfic;

namespace FanPage.Domain.Fanfic.Repos.Interfaces;

public interface ICommentRepository
{
    Task<CommentDto> AddCommentAsync(CommentDto commentDto);
    Task<CommentDto> UpdateCommentAsync(CommentDto commentDto);
    Task DeleteCommentAsync(int id);
    Task<CommentDto> GetCommentByCommentIdAsync(int id, string authorName);
    Task<List<CommentDto>> GetCommentsByFanficIdAsync(int fanficId);
    
    Task<CommentDto> ReplyCommentAsync (CommentDto commentDto);
}