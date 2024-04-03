using FanPage.Application.Fanfic;
using FanPage.Common.Interfaces;
using FanPage.Domain.Account.Entities;
using FanPage.Domain.Fanfic.Repos.Interfaces;
using FanPage.Exceptions;
using FanPage.Infrastructure.Implementations.Helper;
using FanPage.Infrastructure.Interfaces.Fanfic;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Implementations.Fanfic;

public class CommentService : IComment
{
    private readonly ICommentRepository _commentRepository;

    private readonly IJwtTokenManager _jwtTokenManager;

    private readonly IFanficRepository _fanficRepository;

    private readonly IStorageHttp _storageHttp;

    private readonly IdentityUserManager _userManager;

    public CommentService(ICommentRepository commentRepository, IJwtTokenManager jwtTokenManager,
        IFanficRepository fanficRepository, IStorageHttp storageHttp, IdentityUserManager userManager)
    {
        _commentRepository = commentRepository;
        _jwtTokenManager = jwtTokenManager;
        _fanficRepository = fanficRepository;
        _storageHttp = storageHttp;
        _userManager = userManager;
    }

    public async Task<CommentDto> AddCommentAsync(CommentDto commentDto, HttpRequest request)
    {
        var authorName = _jwtTokenManager.GetUserNameFromToken(request);
        var fanfic = _fanficRepository.GetByIdAsync(commentDto.FanficId);
        var user = await _userManager.FindByNameAsync(authorName);
        var userAvatar = await _storageHttp.GetImageBase64FromStorageService(user.UserAvatar);
        commentDto.AuthorName = authorName;
        commentDto.CreatedAt = DateTimeOffset.Now;
        commentDto.AuthorAvatar = userAvatar;

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
            AuthorAvatar = userAvatar,
        };
    }

    public async Task<CommentDto> UpdateCommentAsync(CommentDto commentDto, HttpRequest request)
    {
        var authorName = _jwtTokenManager.GetUserNameFromToken(request);
        var comment = await _commentRepository.GetCommentByCommentIdAsync(commentDto.CommentId, authorName);
        var user = await _userManager.FindByNameAsync(authorName);
        var userAvatar = await _storageHttp.GetImageBase64FromStorageService(user.UserAvatar);

        if (user == null) throw new FanficException("User not found");

        if (authorName != comment.AuthorName)
            throw new FanficException($"You can't update this comment");

        comment.Content = commentDto.Content ?? comment.Content;

        var result = await _commentRepository.UpdateCommentAsync(comment);

        return new CommentDto()
        {
            FanficId = commentDto.FanficId,
            CommentId = result.CommentId,
            Content = result.Content,
            CreatedAt = result.CreatedAt,
            AuthorName = authorName,
            AuthorAvatar = userAvatar,
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

    public async Task<CommentDto> GetCommentByCommentIdAsync(int id, HttpRequest request)
    {
        var authorName = _jwtTokenManager.GetUserNameFromToken(request);
        var result = await _commentRepository.GetCommentByCommentIdAsync(id, authorName);
        var user = await _userManager.FindByNameAsync(authorName);
        if (user == null) throw new FanficException("User not found");
        var userAvatar = await _storageHttp.GetImageBase64FromStorageService(user.UserAvatar);
        return new CommentDto()
        {
            FanficId = result.FanficId,
            CommentId = result.CommentId,
            Content = result.Content,
            CreatedAt = result.CreatedAt,
            AuthorName = authorName,
            AuthorAvatar = userAvatar,
        };
    }

    public async Task<List<CommentDto>> GetCommentsByFanficIdAsync(int fanficId, HttpRequest request)
    {
        var result = await _commentRepository.GetCommentsByFanficIdAsync(fanficId);

        var resultList = new List<CommentDto>();

        foreach (var comment in result)
        {
            var user = await _userManager.FindByNameAsync(comment.AuthorName);
            var userAvatar = await _storageHttp.GetImageBase64FromStorageService(user.UserAvatar);
            resultList.Add(new CommentDto()
            {
                FanficId = comment.FanficId,
                CommentId = comment.CommentId,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt,
                AuthorName = comment.AuthorName,
                AuthorAvatar = userAvatar,
            });
        }
        return resultList;
    }

    public async Task<CommentDto> ReplyCommentAsync(CommentDto commentDto, HttpRequest request)
    {
        var authorName = _jwtTokenManager.GetUserNameFromToken(request);
        var user = await _userManager.FindByNameAsync(authorName);
        var userAvatar = await _storageHttp.GetImageBase64FromStorageService(user.UserAvatar);

        var parentComment = await _commentRepository.GetCommentByCommentIdAsync(commentDto.CommentId, authorName);
        if (parentComment == null) throw new FanficException("Parent comment not found");

        commentDto.AuthorName = authorName;

        var result = await _commentRepository.ReplyCommentAsync(commentDto);

        return new CommentDto()
        {
            FanficId = commentDto.FanficId,
            CommentId = result.CommentId,
            Content = result.Content,
            CreatedAt = result.CreatedAt,
            AuthorName = authorName,
            AuthorAvatar = userAvatar,
        };
    }
}