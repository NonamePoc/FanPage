using AutoMapper;
using FanPage.Application.Fanfic;
using FanPage.Common.Interfaces;
using FanPage.Domain.Fanfic.Repos.Interfaces;
using FanPage.Exceptions;
using FanPage.Infrastructure.Interfaces.Fanfic;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Implementations.Fanfic;

public class CategoryService : ICategory
{
    private readonly ICategoryRepository _categoryRepository;

    private readonly IFanficRepository _fanficRepository;

    private readonly IJwtTokenManager _jwtTokenManager;

    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IFanficRepository fanficRepository,
        IJwtTokenManager jwtTokenManager, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _fanficRepository = fanficRepository;
        _jwtTokenManager = jwtTokenManager;
        _mapper = mapper;
    }

    public async Task<CategoryDto> SetCategoryAsync(int fanficId, string categoryName, HttpRequest request)
    {
        var fanfic = await _fanficRepository.GetByIdAsync(fanficId);
        var userName = _jwtTokenManager.GetUserNameFromToken(request);
        var category = await _categoryRepository.GetByNameAsync(categoryName);
        var categoryId = category.CategoryId;
        var categoryAlreadyFanfic = await _categoryRepository.GetCategoryByFanficIdAsync(fanficId, categoryId);
        if (fanfic.AuthorName != userName && fanfic == null)
        {
            throw new FanficException("Error update");
        }

        if (categoryAlreadyFanfic != null)
        {
            throw new FanficException("Category already exist");
        }

        if (category == null)
        {
            throw new FanficException("Category not found");
        }

        await _categoryRepository.AddCategoryToFanficAsync(fanficId, categoryId);

        return new CategoryDto()
        {
            CategoryId = category.CategoryId,
            Name = categoryName
        };
    }

    public async Task DeleteCategoryAsync(int fanficId, int categoryId, HttpRequest request)
    {
        var fanfic = await _fanficRepository.GetByIdAsync(fanficId);
        var userName = _jwtTokenManager.GetUserNameFromToken(request);
        if (fanfic.AuthorName != userName && fanfic == null)
        {
            throw new FanficException("Error update");
        }

        await _categoryRepository.DeleteCategoryFromFanficAsync(fanficId, categoryId);
    }

    public async Task<List<CategoryDto>> GetAllCategoryFanfic(int fanficId)
    {
        var reviews = await _categoryRepository.GetAllCategoryByFanficIdAsync(fanficId);
        return _mapper.Map<List<CategoryDto>>(reviews);
    }
}