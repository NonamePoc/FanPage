using FanPage.Application.Fanfic;
using FanPage.Domain.Fanfic.Entities;

namespace FanPage.Domain.Fanfic.Repos.Interfaces;

public interface IChapterRepository
{
    Task<ChapterDto> CreateAsync(ChapterDto chapter);
    Task DeleteAsync(int id);
    Task<ChapterDto> UpdateAsync(ChapterDto chapter);

    Task<Chapter?> GetByIdAsync(int id);
    Task<List<Chapter>> GetAllAsync();
    Task<List<Chapter>> GetAllByFanficIdAsync(int fanficId);

    
    Task SaveChangesAsync();
}