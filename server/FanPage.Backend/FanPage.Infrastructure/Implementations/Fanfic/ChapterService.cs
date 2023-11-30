using AutoMapper;
using FanPage.Application.Fanfic;
using FanPage.Common.Interfaces;
using FanPage.Exceptions;
using FanPage.Infrastructure.Interfaces.Fanfic;
using FanPage.Persistence.Repositories.Interfaces.IFanfic;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Implementations.Fanfic;

public class ChapterService : IChapter
{
    private readonly IChapterRepository _chapterRepository;
    private readonly IMapper _mapper;
    private readonly IJwtTokenManager _jwtTokenManager;
    private readonly IFanficRepository _fanficRepository;
    
    public ChapterService(IChapterRepository chapterRepository, IMapper mapper, IJwtTokenManager jwtTokenManager, IFanficRepository fanficRepository)
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
        var result = await _chapterRepository.CreateAsync(chapterDto);

        if (fanfic.AuthorName != userName && fanfic == null)
        {
            throw new FanficException("Error update");
        }

        return new ChapterDto()
        {
            ChapterId = result.ChapterId,
            FanficId = result.FanficId,
            Content = result.Content,
            Title = result.Title
        };
    }

    public async Task<ChapterDto> UpdateChapterAsync(int chapterId, ChapterDto chapterDto, HttpRequest request)
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

    public async Task DeleteChapterAsync(int id, HttpRequest request)
    {
        var fanfic = await _fanficRepository.GetByIdAsync(id);
        var userName = _jwtTokenManager.GetUserNameFromToken(request);
        if (fanfic.AuthorName != userName && fanfic == null)
        {
            throw new FanficException("Error update");
        }

        await _chapterRepository.DeleteAsync(id);
    }

    public async Task<List<ChapterDto>> GetAllChaptersByFanficIdAsync(int fanficId)
    {
        var chapters = await _chapterRepository.GetAllByFanficIdAsync(fanficId);
        return _mapper.Map<List<ChapterDto>>(chapters);
    }
    
    public async Task<List<ChapterDto>> GetAllChaptersAsync()
    {
        var chapters = await _chapterRepository.GetAllAsync();
        return _mapper.Map<List<ChapterDto>>(chapters);
    }
    
    public async Task<ChapterDto> GetByIdAsync(int id)
    {
        var chapter = await _chapterRepository.GetByIdAsync(id);
        return _mapper.Map<ChapterDto>(chapter);
    }
}