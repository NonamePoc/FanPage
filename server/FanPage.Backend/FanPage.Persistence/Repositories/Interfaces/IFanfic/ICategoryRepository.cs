using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FanPage.Application.Fanfic;
using FanPage.Domain.Entities.Fanfic;

namespace FanPage.Persistence.Repositories.Interfaces.IFanfic
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