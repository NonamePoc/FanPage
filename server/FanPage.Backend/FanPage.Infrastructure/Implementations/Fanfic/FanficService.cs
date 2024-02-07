using FanPage.Application.Fanfic;
using FanPage.Common.Interfaces;
using FanPage.Domain.Fanfic.Repos.Interfaces;
using FanPage.Exceptions;
using FanPage.Infrastructure.Extensions;
using FanPage.Infrastructure.Interfaces.Fanfic;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Implementations.Fanfic
{
    public class FanficService : IFanfic
    {
        private readonly IJwtTokenManager _jwtTokenManager;
        private readonly IFanficRepository _fanficRepository;
        private readonly IFanficPhotoRepository _fanficPhotoRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITagRepository _tagRepository;

        public FanficService(IJwtTokenManager jwtTokenManager, IFanficRepository fanficRepository,
            IFanficPhotoRepository fanficPhotoRepository, ICategoryRepository categoryRepository,
            ITagRepository tagRepository)
        {
            _jwtTokenManager = jwtTokenManager;
            _fanficRepository = fanficRepository;
            _fanficPhotoRepository = fanficPhotoRepository;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
        }

        public async Task<FanficDto> CreateAsync(CreateDto createFanfic, HttpRequest request)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            createFanfic.AuthorName = userName;

            var fanficAlready = await _fanficRepository.LocalGetAllAsync();
            if (fanficAlready.Any(f => f.Title == createFanfic.Title))
            {
                throw new FanficException("Fanfic already exists");
            }

            var fanficResult = await _fanficRepository.CreateAsync(createFanfic);

            var fanficPhotoDto = new FanficPhotoDto { FanficId = fanficResult.Id, Image = createFanfic.Image };
            await _fanficPhotoRepository.CreateAsync(fanficPhotoDto);

            foreach (var categoryName in createFanfic.Categories.OrEmptyIfNull())
            {
                var categoryDto = await _categoryRepository.GetByNameAsync(categoryName);
                await _categoryRepository.AddCategoryToFanficAsync(fanficResult.Id, categoryDto.CategoryId);
            }

            foreach (var tagName in createFanfic.Tags.OrEmptyIfNull()
                         .Where(tagName => !string.IsNullOrEmpty(tagName)))
            {
                var existingTag = await _tagRepository.GetByNameAsync(tagName);
                if (existingTag == null)
                {
                    var tagDtos = new TagDto { Name = tagName };
                    await _tagRepository.CreateAsync(tagDtos);
                }

                var tagDto = await _tagRepository.GetByNameAsync(tagName);
                if (tagDto != null && fanficResult != null)
                {
                    await _tagRepository.AddTagToFanficAsync(fanficResult.Id, tagDto.TagId);
                }
            }

            var categoryFanfic = await _categoryRepository.GetAllCategoryByFanficIdAsync(fanficResult.Id);
            var tagFanfic = await _tagRepository.GetTagsByFanficIdAsync(fanficResult.Id);


            var result = new FanficDto
            {
                Id = fanficResult.Id,
                Title = createFanfic.Title,
                AuthorName = createFanfic.AuthorName,
                Image = createFanfic.Image ?? Array.Empty<byte>(),
                Stage = createFanfic.Stage,
                Language = createFanfic.Language,
                Description = createFanfic.Description,
                OriginFandom = createFanfic.OriginFandom,
                CreationDate = fanficResult.CreationDate,
                Categories = categoryFanfic?.Select(c => new CategoryDto
                {
                    Name = c.Name,
                    CategoryId = c.CategoryId
                }).ToList(),
                Tags = tagFanfic?.Select(t => new TagDto
                {
                    Name = t.Name,
                    TagId = t.TagId,
                    IsApproved = t.IsApproved
                }).ToList(),
            };
            return result;
        }


        public async Task<FanficDto> UpdateAsync(int fanficId, UpdateDto updateFanfic, HttpRequest request)
        {
            var fanfic = await _fanficRepository.GetByIdAsync(fanficId);
            var userName = _jwtTokenManager.GetUserNameFromToken(request);

            var resultPhoto = await _fanficPhotoRepository.GetByIdAsync(fanficId);

            if (fanfic.AuthorName != userName && fanfic == null)
            {
                throw new FanficException("Error update");
            }

            fanfic.Description = updateFanfic.Description ?? fanfic.Description;
            fanfic.OriginFandom = updateFanfic.OriginFandom ?? fanfic.OriginFandom;
            fanfic.Stage = updateFanfic.Stage ?? fanfic.Stage;
            fanfic.Title = updateFanfic.Title ?? fanfic.Title;
            resultPhoto.Image = updateFanfic.Photo.Select(s => s.Image).FirstOrDefault() ?? resultPhoto.Image;

            var result = new UpdateDto()
            {
                Description = fanfic.Description,
                OriginFandom = fanfic.OriginFandom,
                Stage = fanfic.Stage,
                Photo = new List<FanficPhotoDto>()
                {
                    new()
                    {
                        Image = resultPhoto.Image
                    }
                }
            };


            await _fanficRepository.UpdateAsync(result, fanficId);

            return new FanficDto()
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
                Categories = fanfic.Categories?.Select(c => new CategoryDto
                {
                    Name = c.Name,
                    CategoryId = c.CategoryId
                }).ToList(),
                Tags = fanfic.Tags?.Select(t => new TagDto
                {
                    Name = t.Name,
                    TagId = t.TagId,
                    IsApproved = t.IsApproved
                }).ToList(),
                Chapters = fanfic.Chapters?.Select(ch => new ChapterDto
                {
                    FanficId = fanfic.Id,
                    Title = ch.Title,
                    Content = ch.Content
                }).ToList(),
                Reviews = fanfic.Reviews?.Select(r => new ReviewsDto
                {
                    FanficId = fanfic.Id,
                    ReviewId = r.ReviewId,
                    Text = r.Text,
                    CreationDate = r.CreationDate,
                    UserName = r.UserName,
                    Rating = r.Rating
                }).Where(r => r.FanficId == fanfic.Id).ToList()
            };
        }

        public async Task DeleteAsync(int id, HttpRequest request)
        {
            var fanfic = await _fanficRepository.GetByIdAsync(id);
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            if (fanfic.AuthorName != userName && fanfic == null)
            {
                throw new FanficException("Error update");
            }

            await _fanficRepository.DeleteAsync(id);
        }
    }
}