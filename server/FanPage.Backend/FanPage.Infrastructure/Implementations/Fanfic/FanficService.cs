using AutoMapper;
using FanPage.Application.Fanfic;
using FanPage.Common.Interfaces;
using FanPage.Exceptions;
using FanPage.Infrastructure.Extensions;
using FanPage.Infrastructure.Interfaces.Fanfic;
using FanPage.Persistence.Repositories.Interfaces;
using FanPage.Persistence.Repositories.Interfaces.IFanfic;
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
        private readonly IMapper _mapper;

        public FanficService(IJwtTokenManager jwtTokenManager, IFanficRepository fanficRepository, IMapper mapper,
            IFanficPhotoRepository fanficPhotoRepository, ICategoryRepository categoryRepository,
            ITagRepository tagRepository)
        {
            _jwtTokenManager = jwtTokenManager;
            _fanficRepository = fanficRepository;
            _mapper = mapper;
            _fanficPhotoRepository = fanficPhotoRepository;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
        }

        public async Task<FanficDto> CreateAsync(CreateDto createFanfic, HttpRequest request)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            var fanficDto = _mapper.Map<CreateDto>(createFanfic);
            fanficDto.AuthorName = userName;
            var fanficResult = await _fanficRepository.CreateAsync(fanficDto);

            var fanficPhotoDto = new FanficPhotoDto { FanficId = fanficResult.Id, Image = createFanfic.Image };
            if (fanficPhotoDto.Image != null)
            {
                await _fanficPhotoRepository.CreateAsync(fanficPhotoDto);
            }

            foreach (var categoryName in createFanfic.Categories.OrEmptyIfNull())
            {
                var categoryDto = await _categoryRepository.GetByNameAsync(categoryName);
                await _categoryRepository.AddCategoryToFanficAsync(fanficResult.Id, categoryDto.CategoryId);
            }

            foreach (var tagName in createFanfic.Tags.OrEmptyIfNull().Where(tagName => !string.IsNullOrEmpty(tagName)))
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


            var result = new FanficDto
            {
                Id = fanficResult.Id,
                Title = createFanfic.Title,
                AuthorName = fanficDto.AuthorName,
                Image = createFanfic.Image,
                Stage = createFanfic.Stage,
                Language = createFanfic.Language,
                Description = createFanfic.Description,
                OriginFandom = createFanfic.OriginFandom,
                CreationDate = fanficResult.CreationDate,
                Categories = createFanfic.Categories
                    ?.Select(categoryName => new FanficCategoryDto { CategoryName = categoryName })
                    .Select(s => s.CategoryName)
                    .ToList(),
                Tags = createFanfic.Tags?.Select(tagName => new FanficTagDto { TagName = tagName })
                    .Select(s => s.TagName).ToList(),
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
                Id = fanficId,
                AuthorName = userName,
                Title = fanfic.Title,
                Description = fanfic.Description,
                OriginFandom = fanfic.OriginFandom,
                Stage = fanfic.Stage,
                Language = fanfic.Language,
                CreationDate = fanfic.CreationDate,
                Image = resultPhoto.Image,
                Categories = fanfic.FanficCategories.Select(s => s.Category.Name).ToList(),
                Tags = fanfic.FanficTags.Select(s => s.Tag.Name).ToList(),
                Chapters = fanfic.Chapters.Select(s => new ChapterDto()
                {
                    FanficId = fanficId,
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