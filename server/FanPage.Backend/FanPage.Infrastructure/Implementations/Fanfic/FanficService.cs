using FanPage.Application.Fanfic;
using FanPage.Common.Interfaces;
using FanPage.Domain.Fanfic.Context;
using FanPage.Domain.Fanfic.Entities;
using FanPage.Domain.Fanfic.Repos.Interfaces;
using FanPage.Exceptions;
using FanPage.Infrastructure.Extensions;
using FanPage.Infrastructure.Implementations.Helper;
using FanPage.Infrastructure.Interfaces.Fanfic;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Implementations.Fanfic
{
    public class FanficService : IFanfic
    {
        private readonly IJwtTokenManager _jwtTokenManager;
        private readonly IFanficRepository _fanficRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IStorageHttp _storageHttp;

        public FanficService(
            IJwtTokenManager jwtTokenManager,
            IFanficRepository fanficRepository,
            IFanficPhotoRepository fanficPhotoRepository,
            ICategoryRepository categoryRepository,
            ITagRepository tagRepository,
            IStorageHttp storageHttp
        )
        {
            _jwtTokenManager = jwtTokenManager;
            _fanficRepository = fanficRepository;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
            _storageHttp = storageHttp;
        }

        public async Task<FanficDto> CreateAsync(CreateDto createFanfic, HttpRequest request)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            createFanfic.AuthorName = userName;

            var uploadResult = await _storageHttp.SendFileToStorageService(createFanfic.File);

            if (uploadResult == null || string.IsNullOrEmpty(uploadResult.FilePath))
            {
                uploadResult = new UploadResult { FilePath = "None" };
            }

            using var transaction = _fanficRepository.BeginTransactionAsync(); // start transaction
            try
            {
                var fanficResult = await _fanficRepository.CreateAsync(
                    createFanfic,
                    uploadResult.FilePath
                );

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

                var img = await _storageHttp.GetImageBase64FromStorageService(fanficResult.Image);
                var result = new FanficDto
                {
                    Id = fanficResult.Id,
                    Title = createFanfic.Title,
                    AuthorName = createFanfic.AuthorName,
                    Image = img,
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

        public async Task<FanficDto> UpdateBanner(string image, int id, HttpRequest request)
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            var fanfic = await _fanficRepository.GetByIdAsync(id);
            if (fanfic.AuthorName != userName)
            {
                throw new FanficException("Årror when changing the banner");
            }
            var resul = await _fanficRepository.UpdateBannerAsync(id, image);
            return resul;
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

                var img = await _storageHttp.GetImageBase64FromStorageService(fanfic.Image);

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
                    Image = img,
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
