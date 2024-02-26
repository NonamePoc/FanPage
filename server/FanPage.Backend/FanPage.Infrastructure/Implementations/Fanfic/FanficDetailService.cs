using FanPage.Application.Fanfic;
using FanPage.Domain.Fanfic.Repos.Interfaces;
using FanPage.Infrastructure.Interfaces.Fanfic;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Implementations.Fanfic;

public class FanficDetailService : IFanficDetail
{
    private readonly IFanficRepository _fanficRepository;

    public FanficDetailService(IFanficRepository fanficRepository)
    {
        _fanficRepository = fanficRepository;
    }

    public async Task<List<FanficDto>> GetAllAsync(int count)
    {
        var allFanfic = await _fanficRepository.GetAllAsync(count);
        return allFanfic
            .Select(fanfic => new FanficDto
            {
                Id = fanfic.Id,
                AuthorName = fanfic.AuthorName,
                Title = fanfic.Title,
                Description = fanfic.Description,
                OriginFandom = fanfic.OriginFandom,
                Stage = fanfic.Stage,
                Language = fanfic.Language,
                CreationDate = fanfic.CreationDate,
                Image = fanfic.Image,
                Categories = fanfic
                    .Categories?.Select(c => new CategoryDto
                    {
                        Name = c.Name,
                        CategoryId = c.CategoryId
                    })
                    .ToList(),
                Tags = fanfic
                    .Tags?.Select(t => new TagDto
                    {
                        Name = t.Name,
                        TagId = t.TagId,
                        IsApproved = t.IsApproved
                    })
                    .ToList(),
                Chapters = fanfic
                    .Chapters?.Select(ch => new ChapterDto
                    {
                        FanficId = fanfic.Id,
                        Title = ch.Title,
                        Content = ch.Content
                    })
                    .ToList(),
                Reviews = fanfic
                    .Reviews?.Select(r => new ReviewsDto
                    {
                        FanficId = fanfic.Id,
                        ReviewId = r.ReviewId,
                        Text = r.Text,
                        CreationDate = r.CreationDate,
                        UserName = r.UserName,
                        Rating = r.Rating
                    })
                    .Where(r => r.FanficId == fanfic.Id)
                    .ToList()
            })
            .ToList();
    }

    public async Task<List<FanficDto>> GetByAuthorNameAsync(string name, int count)
    {
        var byAuthorNameAsync = await _fanficRepository.GetByAuthorNameAsync(name, count);
        return byAuthorNameAsync
            .Select(fanfic => new FanficDto
            {
                Id = fanfic.Id,
                AuthorName = fanfic.AuthorName,
                Title = fanfic.Title,
                Description = fanfic.Description,
                OriginFandom = fanfic.OriginFandom,
                Stage = fanfic.Stage,
                Language = fanfic.Language,
                CreationDate = fanfic.CreationDate,
                Image = fanfic.Image,
                Categories = fanfic
                    .Categories?.Select(c => new CategoryDto
                    {
                        Name = c.Name,
                        CategoryId = c.CategoryId
                    })
                    .ToList(),
                Tags = fanfic
                    .Tags?.Select(t => new TagDto
                    {
                        Name = t.Name,
                        TagId = t.TagId,
                        IsApproved = t.IsApproved
                    })
                    .ToList(),
                Chapters = fanfic
                    .Chapters?.Select(ch => new ChapterDto
                    {
                        FanficId = fanfic.Id,
                        Title = ch.Title,
                        Content = ch.Content
                    })
                    .ToList(),
                Reviews = fanfic
                    .Reviews?.Select(r => new ReviewsDto
                    {
                        FanficId = fanfic.Id,
                        ReviewId = r.ReviewId,
                        Text = r.Text,
                        CreationDate = r.CreationDate,
                        UserName = r.UserName,
                        Rating = r.Rating
                    })
                    .Where(r => r.FanficId == fanfic.Id)
                    .ToList()
            })
            .ToList();
    }

    public async Task<List<FanficDto>> GetLastCreationDateFanficsAsync(
        int count,
        HttpRequest request
    )
    {
        var lastCreationDateFanficsAsync = await _fanficRepository.GetLastCreationDateFanficsAsync(
            count
        );

        return lastCreationDateFanficsAsync
            .Select(fanfic => new FanficDto
            {
                Id = fanfic.Id,
                AuthorName = fanfic.AuthorName,
                Title = fanfic.Title,
                Description = fanfic.Description,
                OriginFandom = fanfic.OriginFandom,
                Stage = fanfic.Stage,
                Language = fanfic.Language,
                CreationDate = fanfic.CreationDate,
                Image = fanfic.Image,
                Categories = fanfic
                    .Categories?.Select(c => new CategoryDto
                    {
                        Name = c.Name,
                        CategoryId = c.CategoryId
                    })
                    .ToList(),
                Tags = fanfic
                    .Tags?.Select(t => new TagDto
                    {
                        Name = t.Name,
                        TagId = t.TagId,
                        IsApproved = t.IsApproved
                    })
                    .ToList(),
                Chapters = fanfic
                    .Chapters?.Select(ch => new ChapterDto
                    {
                        FanficId = fanfic.Id,
                        Title = ch.Title,
                        Content = ch.Content
                    })
                    .ToList(),
                Reviews = fanfic
                    .Reviews?.Select(r => new ReviewsDto
                    {
                        FanficId = fanfic.Id,
                        ReviewId = r.ReviewId,
                        Text = r.Text,
                        CreationDate = r.CreationDate,
                        UserName = r.UserName,
                        Rating = r.Rating
                    })
                    .Where(r => r.FanficId == fanfic.Id)
                    .ToList()
            })
            .ToList();
    }

    public async Task<List<FanficDto>> GetTopRatingFanficsAsync(int count, HttpRequest request)
    {
        var fanfic = await _fanficRepository.GetTopRatingFanficsAsync(count);

        return fanfic
            .Select(dto => new FanficDto
            {
                Id = dto.Id,
                AuthorName = dto.AuthorName,
                Title = dto.Title,
                Description = dto.Description,
                OriginFandom = dto.OriginFandom,
                Stage = dto.Stage,
                Language = dto.Language,
                CreationDate = dto.CreationDate,
                Image = dto.Image,
                Categories = dto
                    .Categories?.Select(c => new CategoryDto
                    {
                        Name = c.Name,
                        CategoryId = c.CategoryId
                    })
                    .ToList(),
                Tags = dto
                    .Tags?.Select(t => new TagDto
                    {
                        Name = t.Name,
                        TagId = t.TagId,
                        IsApproved = t.IsApproved
                    })
                    .ToList(),
                Chapters = dto
                    .Chapters?.Select(ch => new ChapterDto
                    {
                        FanficId = dto.Id,
                        Title = ch.Title,
                        Content = ch.Content
                    })
                    .ToList(),
                Reviews = dto
                    .Reviews?.Select(r => new ReviewsDto
                    {
                        FanficId = dto.Id,
                        ReviewId = r.ReviewId,
                        Text = r.Text,
                        CreationDate = r.CreationDate,
                        UserName = r.UserName,
                        Rating = r.Rating
                    })
                    .Where(r => r.FanficId == dto.Id)
                    .ToList()
            })
            .ToList();
    }

    public async Task<FanficDto> GetByIdAsync(int id)
    {
        var fanfic = await _fanficRepository.GetByIdAsync(id);

        return new FanficDto
        {
            Id = fanfic.Id,
            AuthorName = fanfic.AuthorName,
            Title = fanfic.Title,
            Description = fanfic.Description,
            OriginFandom = fanfic.OriginFandom,
            Stage = fanfic.Stage,
            Language = fanfic.Language,
            CreationDate = fanfic.CreationDate,
            Image = fanfic.Image,
            Categories = fanfic
                .Categories?.Select(c => new CategoryDto
                {
                    Name = c.Name,
                    CategoryId = c.CategoryId
                })
                .ToList(),
            Tags = fanfic
                .Tags?.Select(t => new TagDto
                {
                    Name = t.Name,
                    TagId = t.TagId,
                    IsApproved = t.IsApproved
                })
                .ToList(),
            Chapters = fanfic
                .Chapters?.Select(ch => new ChapterDto
                {
                    FanficId = fanfic.Id,
                    Title = ch.Title,
                    Content = ch.Content
                })
                .ToList(),
            Reviews = fanfic
                .Reviews?.Select(r => new ReviewsDto
                {
                    FanficId = fanfic.Id,
                    ReviewId = r.ReviewId,
                    Text = r.Text,
                    CreationDate = r.CreationDate,
                    UserName = r.UserName,
                    Rating = r.Rating
                })
                .Where(r => r.FanficId == fanfic.Id)
                .ToList()
        };
    }

    public async Task<double> GetAverageRatingAsync(int fanficId)
    {
        var averageRatingAsync = await _fanficRepository.GetAverageRatingAsync(fanficId);

        return averageRatingAsync;
    }

    public async Task<List<FanficDto>> SearchAsync(string searchString, bool original)
    {
        var fanficList = await _fanficRepository.SearchAsync(searchString, original);
        return fanficList
            .Select(fanfic => new FanficDto()
            {
                Id = fanfic.Id,
                AuthorName = fanfic.AuthorName,
                Title = fanfic.Title,
                Description = fanfic.Description,
                OriginFandom = fanfic.OriginFandom,
                Stage = fanfic.Stage,
                Language = fanfic.Language,
                CreationDate = fanfic.CreationDate,
                Image = fanfic.Image,
                Categories = fanfic
                    .Categories?.Select(s => new CategoryDto()
                    {
                        Name = s.Name,
                        CategoryId = s.CategoryId
                    })
                    .ToList(),
                Tags = fanfic
                    .Tags?.Select(s => new TagDto()
                    {
                        Name = s.Name,
                        TagId = s.TagId,
                        IsApproved = s.IsApproved
                    })
                    .ToList(),
                Chapters = fanfic
                    .Chapters?.Select(s => new ChapterDto()
                    {
                        FanficId = fanfic.Id,
                        Title = s.Title,
                        Content = s.Content,
                    })
                    .ToList(),
                Reviews = fanfic
                    .Reviews?.Select(s => new ReviewsDto()
                    {
                        FanficId = fanfic.Id,
                        ReviewId = s.ReviewId,
                        Text = s.Text,
                        CreationDate = s.CreationDate,
                        UserName = s.UserName,
                        Rating = s.Rating,
                    })
                    .Where(w => w.FanficId == fanfic.Id)
                    .ToList()
            })
            .ToList();
    }
}
