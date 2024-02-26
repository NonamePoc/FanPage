using AutoMapper;
using FanPage.Application.Fanfic;
using FanPage.Common.Interfaces;
using FanPage.Domain.Fanfic.Repos.Interfaces;
using FanPage.Exceptions;
using FanPage.Infrastructure.Interfaces.Fanfic;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Implementations.Fanfic;

public class ChapterService : IChapter
{
    private readonly IChapterRepository _chapterRepository;
    private readonly IMapper _mapper;
    private readonly IJwtTokenManager _jwtTokenManager;
    private readonly IFanficRepository _fanficRepository;

    public ChapterService(
        IChapterRepository chapterRepository,
        IMapper mapper,
        IJwtTokenManager jwtTokenManager,
        IFanficRepository fanficRepository
    )
    {
        _chapterRepository = chapterRepository;
        _mapper = mapper;
        _jwtTokenManager = jwtTokenManager;
        _fanficRepository = fanficRepository;
    }

    public async Task<ChapterDto> CreateChapterAsync(ChapterDto chapterDto, HttpRequest request)
    {
        var fanfic = await _fanficRepository.GetByIdAsync(chapterDto.FanficId);
        var userName = _jwtTokenManager.GetUserNameFromToken(request);
        if (fanfic.AuthorName != userName && fanfic == null)
        {
            throw new FanficException("Error update");
        }

        var result = await _chapterRepository.CreateAsync(chapterDto);

        return new ChapterDto()
        {
            ChapterId = result.ChapterId,
            FanficId = result.FanficId,
            Content = result.Content,
            Title = result.Title
        };
    }

    public async Task<ChapterDto> UpdateChapterAsync(
        int chapterId,
        ChapterDto chapterDto,
        HttpRequest request
    )
    {
        var fanfic = await _fanficRepository.GetByIdAsync(chapterDto.FanficId);
        var chapter = await _chapterRepository.GetByIdAsync(chapterId);
        var userName = _jwtTokenManager.GetUserNameFromToken(request);
        if (fanfic.AuthorName != userName && fanfic == null)
        {
            throw new FanficException("Error update");
        }

        chapterDto.Content = chapter.Content ?? chapterDto.Content;
        chapterDto.Title = chapter.Title ?? chapterDto.Title;

        await _chapterRepository.UpdateAsync(chapterDto);

        return new ChapterDto()
        {
            ChapterId = chapterId,
            FanficId = chapterDto.FanficId,
            Content = chapterDto.Content,
            Title = chapterDto.Title
        };
    }

    public async Task DeleteChapterAsync(int id, int fanficId, HttpRequest request)
    {
        var fanfic = await _fanficRepository.GetByIdAsync(fanficId);
        var userName = _jwtTokenManager.GetUserNameFromToken(request);
        if (fanfic.AuthorName != userName && fanfic == null)
        {
            throw new FanficException("Error update");
        }

        await _chapterRepository.DeleteAsync(id);
    }

    public async Task<List<ChapterDto>> GetAllFanficChapter(int fanficId)
    {
        var fanfic = await _fanficRepository.GetByIdAsync(fanficId);
        var chapters = await _chapterRepository.GetAllFanficChapter(fanficId);
        return chapters
            .Select(s => new ChapterDto
            {
                ChapterId = s.ChapterId,
                Title = s.Title,
                Content = s.Content,
                FanficId = s.FanficId,
                AuthorName = fanfic.AuthorName,
                FanficPhoto = fanfic.Image,
                FanficTitle = fanfic.Title
            })
            .ToList();
    }

    public async Task<ChapterDto> GetByIdAsync(int id, int fanficId)
    {
        var fanfic = await _fanficRepository.GetByIdAsync(fanficId);
        var chapter = await _chapterRepository.GetByIdAsync(id);
        return new ChapterDto
        {
            ChapterId = chapter.ChapterId,
            Title = chapter.Title,
            Content = chapter.Content,
            FanficId = chapter.FanficId,
            AuthorName = fanfic.AuthorName,
            FanficPhoto = fanfic.Image,
            FanficTitle = fanfic.Title
        };
    }
}
