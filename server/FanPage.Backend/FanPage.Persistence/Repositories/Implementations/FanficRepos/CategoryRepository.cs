using FanPage.Persistence.Context;
using FanPage.Persistence.Repositories.Interfaces.IFanfic;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FanPage.Application.Fanfic;
using FanPage.Domain.Entities.Fanfic;

namespace FanPage.Persistence.Repositories.Implementations.FanficRepos
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        private readonly FanficContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(FanficContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryDto> GetByNameAsync(string name)
        {
            var category = await _context.Categories.Where(x => x.Name == name).FirstOrDefaultAsync();
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return _mapper.Map<List<CategoryDto>>(categories);
        }

        public async Task AddCategoryToFanficAsync(int fanficId, int categoryId)
        {
            var fanficCategory = new FanficCategory { FanficId = fanficId, CategoryId = categoryId };
            await _context.FanficCategories.AddAsync(fanficCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryFromFanficAsync(int fanficId, int categoryId)
        {
            var fanficCategory = await _context.FanficCategories
                .Where(x => x.FanficId == fanficId && x.CategoryId == categoryId).FirstOrDefaultAsync();
            _context.FanficCategories.Remove(fanficCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<CategoryDto> GetCategoryByFanficIdAsync(int fanficId, int categoryId)
        {
            var fanficCategory = await _context.FanficCategories
                .Where(x => x.FanficId == fanficId && x.CategoryId == categoryId).FirstOrDefaultAsync();
            return _mapper.Map<CategoryDto>(fanficCategory);
        }

        public async Task<List<CategoryDto>> GetAllCategoryByFanficIdAsync(int fanficId)
        {
            var category = await _context.FanficCategories.Where(x => x.FanficId == fanficId)
                .Select(s => s.Category).ToListAsync();
            return _mapper.Map<List<CategoryDto>>(category);
        }
    }
}