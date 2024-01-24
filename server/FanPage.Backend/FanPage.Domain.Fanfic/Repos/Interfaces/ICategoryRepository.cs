using FanPage.Application.Fanfic;

namespace FanPage.Domain.Fanfic.Repos.Interfaces
{
    public interface ICategoryRepository
    {
        Task<CategoryDto> GetByNameAsync(string name);
        Task<List<CategoryDto>> GetAllAsync();
        Task AddCategoryToFanficAsync(int fanficId, int categoryId);
        Task<CategoryDto> GetByIdAsync(int id);
        Task DeleteCategoryFromFanficAsync(int fanficId, int categoryId);
        Task<CategoryDto> GetCategoryByFanficIdAsync(int fanficId, int categoryId);

        Task<List<CategoryDto>> GetAllCategoryByFanficIdAsync(int fanficId);
    }
}