using AutoMapper;
using FanPage.Application.Fanfic;
using FanPage.Domain.Fanfic.Context;
using FanPage.Domain.Fanfic.Entities;
using FanPage.Domain.Fanfic.Repos.Interfaces;
using FanPage.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace FanPage.Domain.Fanfic.Repos.Impl;

public class ChapterRepository : RepositoryBase<Chapter>, IChapterRepository
{
    private readonly FanficContext _context;

    private readonly IMapper _mapper;

    public ChapterRepository(FanficContext context, IMapper mapper)
        : base(context)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ChapterDto> CreateAsync(ChapterDto chapter)
    {
        var chapterEntity = _mapper.Map<Chapter>(chapter);
        chapterEntity.CreateDate = DateTimeOffset.Now.ToUniversalTime();
        _context.Chapters.Add(chapterEntity);
        await _context.SaveChangesAsync();
        return _mapper.Map<ChapterDto>(chapterEntity);
    }

    public async Task DeleteAsync(int id)
    {
        var chapter = _context.Chapters.FirstOrDefault(x => x.ChapterId == id);
        _context.Chapters.Remove(chapter);
        await _context.SaveChangesAsync();
    }

    public async Task<ChapterDto> UpdateAsync(ChapterDto chapter)
    {
        var chapterEntity = _mapper.Map<Chapter>(chapter);
        _context.Chapters.Update(chapterEntity);
        chapterEntity.CreateDate = DateTimeOffset.Now.ToUniversalTime();
        await _context.SaveChangesAsync();
        return _mapper.Map<ChapterDto>(chapterEntity);
    }

    public async Task<ChapterDto> GetByIdAsync(int id)
    {
        var chapter = await _context.Chapters.FirstOrDefaultAsync(x => x.ChapterId == id);
        if (chapter == null)
        {
            throw new FanficException("Chapter not found");
        }
        return new ChapterDto
        {
            ChapterId = chapter.ChapterId,
            Title = chapter.Title,
            Content = chapter.Content,
            FanficId = chapter.FanficId,
        };
    }

    public async Task<List<ChapterDto>> GetAllFanficChapter(int fanficId)
    {
        var chapters = await _context
            .Chapters.Where(x => x.FanficId == fanficId)
            .OrderBy(o => o.CreateDate)
            .ToListAsync();
        return chapters
            .Select(x => new ChapterDto
            {
                ChapterId = x.ChapterId,
                Title = x.Title,
                Content = x.Content,
                FanficId = x.FanficId,
            })
            .ToList();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
