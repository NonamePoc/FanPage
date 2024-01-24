using FanPage.Application.Fanfic;
using FanPage.Common.Interfaces;
using FanPage.Domain.Fanfic.Repos.Interfaces;
using FanPage.Exceptions;
using FanPage.Infrastructure.Interfaces.Fanfic;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Implementations.Fanfic;

public class CommentService : IComment
{
    private readonly ICommentPhotoRepository _commentPhotoRepository;
    private readonly ICommentRepository _commentRepository;

    private readonly IJwtTokenManager _jwtTokenManager;

    private readonly IFanficRepository _fanficRepository;


    public CommentService(ICommentRepository commentRepository, IJwtTokenManager jwtTokenManager,
        IFanficRepository fanficRepository, ICommentPhotoRepository commentPhotoRepository)
    {
        _commentRepository = commentRepository;
        _jwtTokenManager = jwtTokenManager;
        _fanficRepository = fanficRepository;
        _commentPhotoRepository = commentPhotoRepository;
    }

    public async Task<CommentDto> AddCommentAsync(CommentDto commentDto, HttpRequest request)
    {
        var authorName = _jwtTokenManager.GetUserNameFromToken(request);
        var fanfic = _fanficRepository.GetByIdAsync(commentDto.FanficId);

        commentDto.AuthorName = authorName;

        var commentPhotoDto = new CommentPhotoDto
        {
            CommentId = commentDto.CommentId,
            Image = commentDto.Image
        };

        await _commentPhotoRepository.CreateAsync(commentPhotoDto);


        if (fanfic == null)
        {
            throw new FanficException($"Error Comment");
        }

        var result = await _commentRepository.AddCommentAsync(commentDto);

        return new CommentDto()
        {
            FanficId = commentDto.FanficId,
            CommentId = result.CommentId,
            Content = result.Content,
            CreatedAt = result.CreatedAt,
            AuthorName = authorName,
            Image = commentPhotoDto.Image
        };
    }

    public async Task<CommentDto> UpdateCommentAsync(CommentDto commentDto, HttpRequest request)
    {
        var authorName = _jwtTokenManager.GetUserNameFromToken(request);
        var comment = await _commentRepository.GetCommentByCommentIdAsync(commentDto.CommentId, authorName);

        if (authorName != comment.AuthorName)
            throw new FanficException($"You can't update this comment");

        comment.Content = commentDto.Content ?? comment.Content;
        comment.Image = commentDto.Image ?? comment.Image;

        var result = await _commentRepository.UpdateCommentAsync(comment);

        return new CommentDto()
        {
            FanficId = commentDto.FanficId,
            CommentId = result.CommentId,
            Content = result.Content,
            CreatedAt = result.CreatedAt,
            AuthorName = authorName,
            Image = result.Image
        };
    }

    public async Task DeleteCommentAsync(int id, HttpRequest request)
    {
        var authorName = _jwtTokenManager.GetUserNameFromToken(request);
        var comment = await _commentRepository.GetCommentByCommentIdAsync(id, authorName);

        if (authorName != comment.AuthorName)
            throw new FanficException($"You can't delete this comment");

        await _commentRepository.DeleteCommentAsync(id);
    }

    public async Task<CommentDto> GetCommentByFanficIdAsync(int id, HttpRequest request)
    {
        var authorName = _jwtTokenManager.GetUserNameFromToken(request);
        var result = await _commentRepository.GetCommentByCommentIdAsync(id, authorName);
        return new CommentDto()
        {
            FanficId = result.FanficId,
            CommentId = result.CommentId,
            Content = result.Content,
            CreatedAt = result.CreatedAt,
            AuthorName = authorName,
            Image = result.Image
        };
    }

    public async Task<List<CommentDto>> GetCommentsByFanficIdAsync(int fanficId, HttpRequest request)
    {
        var result = await _commentRepository.GetCommentsByFanficIdAsync(fanficId);

        return result.Select(comment => new CommentDto()
        {
            FanficId = comment.FanficId,
            CommentId = comment.CommentId,
            Content = comment.Content,
            CreatedAt = comment.CreatedAt,
            AuthorName = comment.AuthorName,
            Image = comment.Image
        }).ToList();
    }

    public async Task<CommentDto> ReplyCommentAsync(CommentDto commentDto, HttpRequest request)
    {
        var authorName = _jwtTokenManager.GetUserNameFromToken(request);

        var parentComment = await _commentRepository.GetCommentByCommentIdAsync(commentDto.CommentId, authorName);
        if (parentComment == null) throw new FanficException("Parent comment not found");

        commentDto.AuthorName = authorName;
        commentDto.CreatedAt = DateTimeOffset.Now;

        var commentPhotoDto = new CommentPhotoDto
        {
            CommentId = commentDto.CommentId,
            Image = commentDto.Image
        };

        await _commentPhotoRepository.CreateAsync(commentPhotoDto);

        var result = await _commentRepository.ReplyCommentAsync(commentDto);

        return new CommentDto()
        {
            FanficId = commentDto.FanficId,
            CommentId = result.CommentId,
            Content = result.Content,
            CreatedAt = result.CreatedAt,
            AuthorName = authorName,
            Image = commentPhotoDto.Image
        };
    }
}