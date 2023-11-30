using FanPage.Application.Fanfic;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Interfaces.Fanfic;

public interface ICategory
{
    Task<CategoryDto> SetCategoryAsync(int fanficId, string categoryName, HttpRequest request);

    Task DeleteCategoryAsync(int fanficId, int categoryId, HttpRequest request);

    Task<List<CategoryDto>> GetAllCategoryFanfic(int fanficId);
}