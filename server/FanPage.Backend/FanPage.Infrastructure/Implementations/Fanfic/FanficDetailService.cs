using FanPage.Application.Fanfic;
using FanPage.Common.Interfaces;
using FanPage.Domain.Fanfic.Repos.Interfaces;
using FanPage.Exceptions;
using FanPage.Infrastructure.Implementations.Helper;
using FanPage.Infrastructure.Interfaces.Fanfic;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Implementations.Fanfic;

public class FanficDetailService : IFanficDetail
{
    private readonly IFanficRepository _fanficRepository;
    private readonly IJwtTokenManager _jwtTokenManager;
    private readonly IStorageHttp _storageHttp;

    public FanficDetailService(IFanficRepository fanficRepository, IJwtTokenManager jwtTokenManager,
        IStorageHttp storageHttp)
    {
        _fanficRepository = fanficRepository;
        _jwtTokenManager = jwtTokenManager;
        _storageHttp = storageHttp;
    }

    public async Task<List<FanficDto>> GetAllAsync(int count)
    {
        var allFanfic = await _fanficRepository.GetAllAsync(count);
        var list = new List<FanficDto>();

        foreach (var fanfic in allFanfic)
        {
            var fanficDto = new FanficDto()
            {
                Id = fanfic.Id,
                AuthorName = fanfic.AuthorName,
                Title = fanfic.Title,
                Description = fanfic.Description,
                OriginFandom = fanfic.OriginFandom,
                Stage = fanfic.Stage,
                Language = fanfic.Language,
                CreationDate = fanfic.CreationDate,
                Categories = fanfic.Categories?.Select(s => new CategoryDto()
                {
                    Name = s.Name,
                    CategoryId = s.CategoryId
                }).ToList(),
                Tags = fanfic.Tags?.Select(s => new TagDto()
                {
                    Name = s.Name,
                    TagId = s.TagId,
                    IsApproved = s.IsApproved
                }).ToList(),
                Chapters = fanfic.Chapters?.Select(s => new ChapterDto()
                {
                    FanficId = fanfic.Id,
                    Title = s.Title,
                    Content = s.Content,
                }).ToList(),
                Reviews = fanfic.Reviews?.Select(s => new ReviewsDto()
                {
                    FanficId = fanfic.Id,
                    ReviewId = s.ReviewId,
                    Text = s.Text,
                    CreationDate = s.CreationDate,
                    UserName = s.UserName,
                    Rating = s.Rating,
                }).Where(w => w.FanficId == fanfic.Id).ToList()
            };

            if (fanfic.Image != null)
            {
                var uploadResult = await _storageHttp.GetImageBase64FromStorageService(fanfic.Image);
                fanficDto.Image = uploadResult;
            }

            list.Add(fanficDto);
        }

        return list;
    }

    public async Task<List<FanficDto>> GetByAuthorNameAsync(string name, int count)
    {
        var byAuthorNameAsync = await _fanficRepository.GetByAuthorNameAsync(name, count);

        var list = new List<FanficDto>();

        foreach (var fanfic in byAuthorNameAsync)
        {
            var fanficDto = new FanficDto()
            {
                Id = fanfic.Id,
                AuthorName = fanfic.AuthorName,
                Title = fanfic.Title,
                Description = fanfic.Description,
                OriginFandom = fanfic.OriginFandom,
                Stage = fanfic.Stage,
                Language = fanfic.Language,
                CreationDate = fanfic.CreationDate,
                Categories = fanfic.Categories?.Select(s => new CategoryDto()
                {
                    Name = s.Name,
                    CategoryId = s.CategoryId
                }).ToList(),
                Tags = fanfic.Tags?.Select(s => new TagDto()
                {
                    Name = s.Name,
                    TagId = s.TagId,
                    IsApproved = s.IsApproved
                }).ToList(),
                Chapters = fanfic.Chapters?.Select(s => new ChapterDto()
                {
                    FanficId = fanfic.Id,
                    Title = s.Title,
                    Content = s.Content,
                }).ToList(),
                Reviews = fanfic.Reviews?.Select(s => new ReviewsDto()
                {
                    FanficId = fanfic.Id,
                    ReviewId = s.ReviewId,
                    Text = s.Text,
                    CreationDate = s.CreationDate,
                    UserName = s.UserName,
                    Rating = s.Rating,
                }).Where(w => w.FanficId == fanfic.Id).ToList()
            };

            if (fanfic.Image != null)
            {
                var uploadResult = await _storageHttp.GetImageBase64FromStorageService(fanfic.Image);
                fanficDto.Image = uploadResult;
            }

            list.Add(fanficDto);
        }

        return list;
    }

    public async Task<List<FanficDto>> GetLastCreationDateFanficsAsync(
        int count,
        HttpRequest request
    )
    {
        var lastCreationDateFanficsAsync = await _fanficRepository.GetLastCreationDateFanficsAsync(
            count
        );

        var list = new List<FanficDto>();

        foreach (var fanfic in lastCreationDateFanficsAsync)
        {
            var fanficDto = new FanficDto()
            {
                Id = fanfic.Id,
                AuthorName = fanfic.AuthorName,
                Title = fanfic.Title,
                Description = fanfic.Description,
                OriginFandom = fanfic.OriginFandom,
                Stage = fanfic.Stage,
                Language = fanfic.Language,
                CreationDate = fanfic.CreationDate,
                Categories = fanfic.Categories?.Select(s => new CategoryDto()
                {
                    Name = s.Name,
                    CategoryId = s.CategoryId
                }).ToList(),
                Tags = fanfic.Tags?.Select(s => new TagDto()
                {
                    Name = s.Name,
                    TagId = s.TagId,
                    IsApproved = s.IsApproved
                }).ToList(),
                Chapters = fanfic.Chapters?.Select(s => new ChapterDto()
                {
                    FanficId = fanfic.Id,
                    Title = s.Title,
                    Content = s.Content,
                }).ToList(),
                Reviews = fanfic.Reviews?.Select(s => new ReviewsDto()
                {
                    FanficId = fanfic.Id,
                    ReviewId = s.ReviewId,
                    Text = s.Text,
                    CreationDate = s.CreationDate,
                    UserName = s.UserName,
                    Rating = s.Rating,
                }).Where(w => w.FanficId == fanfic.Id).ToList()
            };

            if (fanfic.Image != null)
            {
                var uploadResult = await _storageHttp.GetImageBase64FromStorageService(fanfic.Image);
                fanficDto.Image = uploadResult;
            }

            list.Add(fanficDto);
        }

        return list;
    }

    public async Task<List<FanficDto>> GetTopRatingFanficsAsync(int count, HttpRequest request)
    {
        var fanficList = await _fanficRepository.GetTopRatingFanficsAsync(count);

        var list = new List<FanficDto>();

        foreach (var fanfic in fanficList)
        {
            var fanficDto = new FanficDto()
            {
                Id = fanfic.Id,
                AuthorName = fanfic.AuthorName,
                Title = fanfic.Title,
                Description = fanfic.Description,
                OriginFandom = fanfic.OriginFandom,
                Stage = fanfic.Stage,
                Language = fanfic.Language,
                CreationDate = fanfic.CreationDate,
                Categories = fanfic.Categories?.Select(s => new CategoryDto()
                {
                    Name = s.Name,
                    CategoryId = s.CategoryId
                }).ToList(),
                Tags = fanfic.Tags?.Select(s => new TagDto()
                {
                    Name = s.Name,
                    TagId = s.TagId,
                    IsApproved = s.IsApproved
                }).ToList(),
                Chapters = fanfic.Chapters?.Select(s => new ChapterDto()
                {
                    FanficId = fanfic.Id,
                    Title = s.Title,
                    Content = s.Content,
                }).ToList(),
                Reviews = fanfic.Reviews?.Select(s => new ReviewsDto()
                {
                    FanficId = fanfic.Id,
                    ReviewId = s.ReviewId,
                    Text = s.Text,
                    CreationDate = s.CreationDate,
                    UserName = s.UserName,
                    Rating = s.Rating,
                }).Where(w => w.FanficId == fanfic.Id).ToList()
            };

            if (fanfic.Image != null)
            {
                var uploadResult = await _storageHttp.GetImageBase64FromStorageService(fanfic.Image);
                fanficDto.Image = uploadResult;
            }

            list.Add(fanficDto);
        }

        return list;
    }

    public async Task<FanficDto> GetByIdAsync(int id)
    {
        var fanfic = await _fanficRepository.GetByIdAsync(id);

        var avatar = await _storageHttp.GetImageBase64FromStorageService(fanfic.Image);

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
            Image = avatar,
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

        var updatedFanficList = new List<FanficDto>();

        foreach (var fanfic in fanficList)
        {
            var fanficDto = new FanficDto()
            {
                Id = fanfic.Id,
                AuthorName = fanfic.AuthorName,
                Title = fanfic.Title,
                Description = fanfic.Description,
                OriginFandom = fanfic.OriginFandom,
                Stage = fanfic.Stage,
                Language = fanfic.Language,
                CreationDate = fanfic.CreationDate,
                Categories = fanfic.Categories?.Select(s => new CategoryDto()
                {
                    Name = s.Name,
                    CategoryId = s.CategoryId
                }).ToList(),
                Tags = fanfic.Tags?.Select(s => new TagDto()
                {
                    Name = s.Name,
                    TagId = s.TagId,
                    IsApproved = s.IsApproved
                }).ToList(),
                Chapters = fanfic.Chapters?.Select(s => new ChapterDto()
                {
                    FanficId = fanfic.Id,
                    Title = s.Title,
                    Content = s.Content,
                }).ToList(),
                Reviews = fanfic.Reviews?.Select(s => new ReviewsDto()
                {
                    FanficId = fanfic.Id,
                    ReviewId = s.ReviewId,
                    Text = s.Text,
                    CreationDate = s.CreationDate,
                    UserName = s.UserName,
                    Rating = s.Rating,
                }).Where(w => w.FanficId == fanfic.Id).ToList()
            };

            if (fanfic.Image != null)
            {
                var uploadResult = await _storageHttp.GetImageBase64FromStorageService(fanfic.Image);
                fanficDto.Image = uploadResult;
            }

            updatedFanficList.Add(fanficDto);
        }

        return updatedFanficList;
    }

    public async Task ChangeAvatar(int id, IFormFile file, HttpRequest request)
    {
        var username = _jwtTokenManager.GetUserNameFromToken(request);
        var fanfic = await _fanficRepository.GetByIdAsync(id);
        if (username != fanfic.AuthorName)
            throw new FanficException($"You can't change this avatar");

        if (file == null)
            throw new FanficException($"File is null");

        var avatar = await _storageHttp.SendFileToStorageService(file);

        if (avatar == null)
            throw new FanficException($"Error upload avatar");

        await _fanficRepository.ChangeAvatar(id, avatar.FilePath);
    }
}