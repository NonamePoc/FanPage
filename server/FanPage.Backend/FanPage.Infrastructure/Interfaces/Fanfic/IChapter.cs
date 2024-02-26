using FanPage.Application.Fanfic;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Interfaces.Fanfic;

public interface IChapter
{
    Task<ChapterDto> CreateChapterAsync(ChapterDto chapterDto, HttpRequest request);
    Task<ChapterDto> UpdateChapterAsync(int chapterId, ChapterDto chapterDto, HttpRequest request);
    Task DeleteChapterAsync(int id, int fanficId, HttpRequest request);
    Task<List<ChapterDto>> GetAllFanficChapter(int fanficId);

    Task<ChapterDto> GetByIdAsync(int id, int fanficId);
}
