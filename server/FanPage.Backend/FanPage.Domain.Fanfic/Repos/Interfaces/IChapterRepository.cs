using FanPage.Application.Fanfic;
using FanPage.Domain.Fanfic.Entities;

namespace FanPage.Domain.Fanfic.Repos.Interfaces;

public interface IChapterRepository
{
    Task<ChapterDto> CreateAsync(ChapterDto chapter);
    Task DeleteAsync(int id);
    Task<ChapterDto> UpdateAsync(ChapterDto chapter);

    Task<ChapterDto> GetByIdAsync(int id);
    Task<List<ChapterDto>> GetAllFanficChapter(int fanficId);

    Task SaveChangesAsync();
}
