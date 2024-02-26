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

        public FanficService(
            IJwtTokenManager jwtTokenManager,
            IFanficRepository fanficRepository,
            IFanficPhotoRepository fanficPhotoRepository,
            ICategoryRepository categoryRepository,
            ITagRepository tagRepository
        )
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

            using var transaction = _fanficRepository.BeginTransactionAsync(); // start transaction
            try
            {
                var fanficResult = await _fanficRepository.CreateAsync(createFanfic);

                foreach (var categoryName in createFanfic.Categories.OrEmptyIfNull())
                {
                    var categoryDto = await _categoryRepository.GetByNameAsync(categoryName);
                    await _categoryRepository.AddCategoryToFanficAsync(
                        fanficResult.Id,
                        categoryDto.CategoryId
                    );
                }

                foreach (
                    var tagName in createFanfic
                        .Tags.OrEmptyIfNull()
                        .Where(tagName => !string.IsNullOrEmpty(tagName))
                )
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

                var categoryFanfic = await _categoryRepository.GetAllCategoryByFanficIdAsync(
                    fanficResult.Id
                );
                var tagFanfic = await _tagRepository.GetTagsByFanficIdAsync(fanficResult.Id);

                await _fanficRepository.CommitTransactionAsync(); // save changes transaction

                var result = new FanficDto
                {
                    Id = fanficResult.Id,
                    Title = createFanfic.Title,
                    AuthorName = createFanfic.AuthorName,
                    Image = createFanfic.ImageFanfic.Select(s => s.Image).FirstOrDefault(),
                    Stage = createFanfic.Stage,
                    Language = createFanfic.Language,
                    Description = createFanfic.Description,
                    OriginFandom = createFanfic.OriginFandom,
                    CreationDate = fanficResult.CreationDate,
                    Categories = categoryFanfic
                        ?.Select(c => new CategoryDto { Name = c.Name, CategoryId = c.CategoryId })
                        .ToList(),
                    Tags = tagFanfic
                        ?.Select(t => new TagDto
                        {
                            Name = t.Name,
                            TagId = t.TagId,
                            IsApproved = t.IsApproved
                        })
                        .ToList(),
                };
                return result;
            }
            catch (Exception ex)
            {
                await _fanficRepository.RollBackAsync();
                throw new FanficException($"Error create fanfic {ex.Message}");
            }
        }

        public async Task<FanficDto> UpdateAsync(
            int fanficId,
            UpdateDto updateFanfic,
            HttpRequest request
        )
        {
            using var transactions = _fanficRepository.BeginTransactionAsync();
            try
            {
                var fanfic = await _fanficRepository.GetByIdAsync(fanficId);
                var userName = _jwtTokenManager.GetUserNameFromToken(request);
                if (fanfic.AuthorName != userName && fanfic == null)
                {
                    throw new FanficException("Error update");
                }

                fanfic.Description = !string.IsNullOrWhiteSpace(updateFanfic.Description)
                    ? updateFanfic.Description
                    : fanfic.Description;
                fanfic.OriginFandom = updateFanfic.OriginFandom ?? fanfic.OriginFandom;
                fanfic.Stage = !string.IsNullOrWhiteSpace(updateFanfic.Stage)
                    ? updateFanfic.Stage
                    : fanfic.Stage;
                fanfic.Title = !string.IsNullOrWhiteSpace(updateFanfic.Title)
                    ? updateFanfic.Title
                    : fanfic.Title;
                fanfic.Language = !string.IsNullOrWhiteSpace(updateFanfic.Language)
                    ? updateFanfic.Language
                    : fanfic.Language;
                if (updateFanfic.Image != null && updateFanfic.Image.Length != 0)
                {
                    var fanficPhoto = await _fanficPhotoRepository.GetByIdAsync(fanficId);

                    if (fanficPhoto != null)
                    {
                        fanficPhoto.Image = updateFanfic.Image;
                        await _fanficPhotoRepository.UpdateAsync(fanficPhoto);
                    }
                    else
                    {
                        fanficPhoto = new FanficPhotoDto
                        {
                            FanficId = fanficId,
                            Image = updateFanfic.Image
                        };
                        await _fanficPhotoRepository.CreateAsync(fanficPhoto);
                    }
                }

                if (updateFanfic.Categories.Count != 0)
                {
                    var categoryFanfic = await _categoryRepository.GetAllCategoryByFanficIdAsync(
                        fanficId
                    );

                    foreach (var category in categoryFanfic)
                    {
                        await _categoryRepository.DeleteCategoryFromFanficAsync(
                            fanficId,
                            category.CategoryId
                        );
                    }

                    foreach (var categoryName in updateFanfic.Categories)
                    {
                        var categoryDto = await _categoryRepository.GetByNameAsync(categoryName);
                        await _categoryRepository.AddCategoryToFanficAsync(
                            fanficId,
                            categoryDto.CategoryId
                        );
                    }
                }

                if (updateFanfic.Tags.Count != 0)
                {
                    var tagFanfic = await _tagRepository.GetTagsByFanficIdAsync(fanficId);

                    foreach (var tag in tagFanfic)
                    {
                        await _tagRepository.DeleteTagFromFanficAsync(fanficId, tag.Name);
                    }

                    foreach (var tagName in updateFanfic.Tags)
                    {
                        var existingTag = await _tagRepository.GetByNameAsync(tagName);
                        if (existingTag == null)
                        {
                            var tagDtos = new TagDto { Name = tagName };
                            await _tagRepository.CreateAsync(tagDtos);
                        }

                        var tagDto = await _tagRepository.GetByNameAsync(tagName);
                        if (tagDto != null)
                        {
                            await _tagRepository.AddTagToFanficAsync(fanficId, tagDto.TagId);
                        }
                    }
                }

                var result = new UpdateDto()
                {
                    Title = fanfic.Title,
                    Image = fanfic.Image,
                    Description = fanfic.Description,
                    OriginFandom = fanfic.OriginFandom,
                    Stage = fanfic.Stage,
                    Language = fanfic.Language,
                    Categories = updateFanfic.Categories.ToList(),
                    Tags = updateFanfic.Tags.ToList()
                };

                await _fanficRepository.UpdateAsync(result, fanficId);
                await _fanficRepository.CommitTransactionAsync();

                return new FanficDto
                {
                    Id = fanficId,
                    Title = fanfic.Title,
                    AuthorName = fanfic.AuthorName,
                    Image = fanfic.Image,
                    Stage = fanfic.Stage,
                    Language = fanfic.Language,
                    Description = fanfic.Description,
                    OriginFandom = fanfic.OriginFandom,
                    CreationDate = fanfic.CreationDate,
                    Categories = updateFanfic
                        .Categories.Select(c => new CategoryDto { Name = c })
                        .ToList(),
                    Tags = updateFanfic.Tags.Select(t => new TagDto { Name = t }).ToList()
                };
            }
            catch (Exception ex)
            {
                await _fanficRepository.RollBackAsync();
                throw new FanficException($"Error update fanfic {ex.Message}");
            }
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
