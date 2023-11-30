using FanPage.Application.Fanfic;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Interfaces.Fanfic;

public interface IChapter
{
    Task<ChapterDto> CreateChapterAsync(ChapterDto chapterDto, HttpRequest request);
    Task<ChapterDto> UpdateChapterAsync(int chapterId, ChapterDto chapterDto, HttpRequest request);
    Task DeleteChapterAsync(int id, HttpRequest request);
    Task<List<ChapterDto>> GetAllChaptersByFanficIdAsync(int fanficId);
    Task<List<ChapterDto>> GetAllChaptersAsync();

    Task<ChapterDto> GetByIdAsync(int id);
}