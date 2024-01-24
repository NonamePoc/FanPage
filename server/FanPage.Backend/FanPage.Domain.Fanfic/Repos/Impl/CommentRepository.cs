using AutoMapper;
using FanPage.Application.Fanfic;
using FanPage.Domain.Fanfic.Context;
using FanPage.Domain.Fanfic.Entities;
using FanPage.Domain.Fanfic.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FanPage.Domain.Fanfic.Repos.Impl;

public class CommentRepository : ICommentRepository
{
    private readonly FanficContext _context;
    private readonly IMapper _mapper;

    public CommentRepository(FanficContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CommentDto> AddCommentAsync(CommentDto commentDto)
    {
        var commentEntity = _mapper.Map<Comment>(commentDto);
        commentEntity.CreatedAt = DateTimeOffset.Now;
        await _context.Comments.AddAsync(commentEntity);
        await _context.SaveChangesAsync();

        return _mapper.Map<CommentDto>(commentEntity);
    }

    public async Task<CommentDto> UpdateCommentAsync(CommentDto commentDto)
    {
        var commentEntity = _mapper.Map<Comment>(commentDto);
        commentEntity.CreatedAt = DateTimeOffset.Now;
        _context.Comments.Update(commentEntity);
        await _context.SaveChangesAsync();

        return _mapper.Map<CommentDto>(commentEntity);
    }

    public async Task DeleteCommentAsync(int id)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(x => x.CommentId == id);
        if (comment != null) _context.Comments.Remove(comment);
        else throw new Exception("Comment not found");
        await _context.SaveChangesAsync();
    }

    public async Task<CommentDto> GetCommentByCommentIdAsync(int id, string authorName)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(x => x.CommentId == id && x.AuthorName == authorName);
        return _mapper.Map<CommentDto>(comment);
    }

    public async Task<List<CommentDto>> GetCommentsByFanficIdAsync(int fanficId)
    {
        var commentList = await _context.Comments.Where(x => x.FanficId == fanficId).ToListAsync();
        return _mapper.Map<List<CommentDto>>(commentList);
    }

    public async Task<CommentDto> ReplyCommentAsync(CommentDto commentDto)
    {
        var parentComment = await _context.Comments.FirstOrDefaultAsync(x => x.CommentId == commentDto.CommentId);
        if (parentComment == null) throw new Exception("Parent comment not found");

        var replyCommentEntity = _mapper.Map<Comment>(commentDto);
        replyCommentEntity.CreatedAt = DateTimeOffset.Now;

        await _context.Comments.AddAsync(replyCommentEntity);
        await _context.SaveChangesAsync();

        return _mapper.Map<CommentDto>(replyCommentEntity);
    }
}