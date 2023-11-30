using AutoMapper;
using FanPage.Application.Fanfic;
using FanPage.Common.Interfaces;
using FanPage.Infrastructure.Interfaces.Fanfic;
using FanPage.Persistence.Repositories.Interfaces.IFanfic;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Implementations.Fanfic;

public class FanficDetailService : IFanficDetail
{
    private readonly IFanficRepository _fanficRepository;

    private readonly IMapper _mapper;

    private readonly IJwtTokenManager _jwtTokenManager;

    public FanficDetailService(IFanficRepository fanficRepository, IMapper mapper, IJwtTokenManager jwtTokenManager)
    {
        _fanficRepository = fanficRepository;
        _mapper = mapper;
        _jwtTokenManager = jwtTokenManager;
    }

    public async Task<List<FanficDto>> GetAllAsync()
    {
        var allFanfic = await _fanficRepository.GetAllAsync();
        var fanficDtos = allFanfic.Select(fanfic => new FanficDto
        {
            Id = fanfic.FanficId,
            AuthorName = fanfic.AuthorName,
            Description = fanfic.Description,
            OriginFandom = fanfic.OriginFandom,
            Stage = fanfic.Stage,
            Language = fanfic.Language,
            CreationDate = fanfic.CreationDate,
            Image = fanfic.Photos.Select(s => s.Image).FirstOrDefault(),
            Categories = fanfic.FanficCategories.Select(s => s.Category.Name).ToList(),
            Tags = fanfic.FanficTags.Select(s => s.Tag.Name).ToList(),
            Chapters = fanfic.Chapters.Select(s => new ChapterDto()
            {
                FanficId = fanfic.FanficId,
                Title = s.Title,
                Content = s.Content,
            }).ToList(),
            Reviews = fanfic.Reviews.Select(s => new ReviewsDto()
            {
                FanficId = fanfic.FanficId,
                ReviewId = s.ReviewId,
                Text = s.Text,
                CreationDate = s.CreationDate,
                UserName = s.UserName,
                Rating = s.Rating,
            }).Where(w => w.FanficId == fanfic.FanficId).ToList()
        }).ToList();

        return fanficDtos;
    }

    public async Task<List<FanficDto>> GetByAuthorNameAsync(string name)
    {
        var byAuthorNameAsync = await _fanficRepository.GetByAuthorNameAsync(name);
        var fanficDtos = byAuthorNameAsync.Select(fanfic => new FanficDto
        {
            Id = fanfic.FanficId,
            AuthorName = fanfic.AuthorName,
            Description = fanfic.Description,
            OriginFandom = fanfic.OriginFandom,
            Stage = fanfic.Stage,
            Language = fanfic.Language,
            CreationDate = fanfic.CreationDate,
            Image = fanfic.Photos.Select(s => s.Image).FirstOrDefault(),
            Categories = fanfic.FanficCategories.Select(s => s.Category.Name).ToList(),
            Tags = fanfic.FanficTags.Select(s => s.Tag.Name).ToList(),
            Chapters = fanfic.Chapters.Select(s => new ChapterDto()
            {
                FanficId = fanfic.FanficId,
                Title = s.Title,
                Content = s.Content,
            }).ToList(),
            Reviews = fanfic.Reviews.Select(s => new ReviewsDto()
            {
                FanficId = fanfic.FanficId,
                ReviewId = s.ReviewId,
                Text = s.Text,
                CreationDate = s.CreationDate,
                UserName = s.UserName,
                Rating = s.Rating,
            }).Where(w => w.FanficId == fanfic.FanficId).ToList()
        }).ToList();
        return fanficDtos;
    }


    public async Task<FanficDto> GetByIdAsync(int id)
    {
        var fanfic = await _fanficRepository.GetByIdAsync(id);
        var fanficDtos = new FanficDto
        {
            Id = fanfic.FanficId,
            AuthorName = fanfic.AuthorName,
            Description = fanfic.Description,
            OriginFandom = fanfic.OriginFandom,
            Stage = fanfic.Stage,
            Language = fanfic.Language,
            CreationDate = fanfic.CreationDate,
            Image = fanfic.Photos.Select(s => s.Image).FirstOrDefault(),
            Categories = fanfic.FanficCategories.Select(s => s.Category.Name).ToList(),
            Tags = fanfic.FanficTags.Select(s => s.Tag.Name).ToList(),
            Chapters = fanfic.Chapters.Select(s => new ChapterDto()
            {
                FanficId = fanfic.FanficId,
                Title = s.Title,
                Content = s.Content,
            }).ToList(),
            Reviews = fanfic.Reviews.Select(s => new ReviewsDto()
            {
                FanficId = fanfic.FanficId,
                ReviewId = s.ReviewId,
                Text = s.Text,
                CreationDate = s.CreationDate,
                UserName = s.UserName,
                Rating = s.Rating,
            }).Where(w => w.FanficId == fanfic.FanficId).ToList()
        };
        return fanficDtos;
    }

    public Task<double> GetAverageRatingAsync(int fanficId)
    {
        var averageRatingAsync = _fanficRepository.GetAverageRatingAsync(fanficId);
        return averageRatingAsync;
    }

    public async Task<List<FanficDto>> SearchAsync(string searchString, HttpRequest request)
    {
        var fanficList = await _fanficRepository.SearchAsync(searchString, request);
        return fanficList.Select(fanfic => new FanficDto()
        {
            Id = fanfic.FanficId,
            AuthorName = fanfic.AuthorName,
            Description = fanfic.Description,
            OriginFandom = fanfic.OriginFandom,
            Stage = fanfic.Stage,
            Language = fanfic.Language,
            CreationDate = fanfic.CreationDate,
            Image = fanfic.Photos.Select(s => s.Image).FirstOrDefault(),
            Categories = fanfic.FanficCategories.Select(s => s.Category.Name).ToList(),
            Tags = fanfic.FanficTags.Select(s => s.Tag.Name).ToList(),
            Chapters = fanfic.Chapters.Select(s => new ChapterDto()
            {
                FanficId = fanfic.FanficId,
                Title = s.Title,
                Content = s.Content,
            }).ToList(),
            Reviews = fanfic.Reviews.Select(s => new ReviewsDto()
            {
                FanficId = fanfic.FanficId,
                ReviewId = s.ReviewId,
                Text = s.Text,
                CreationDate = s.CreationDate,
                UserName = s.UserName,
                Rating = s.Rating,
            }).Where(w => w.FanficId == fanfic.FanficId).ToList()
        }).ToList();
    }
}