using AutoMapper;
using FanPage.Application.Fanfic;
using FanPage.Domain.Entities.Fanfic;
using FanPage.Persistence.Context;
using FanPage.Persistence.Repositories.Interfaces.IFanfic;
using Microsoft.EntityFrameworkCore;

namespace FanPage.Persistence.Repositories.Implementations.FanficRepos;

public class ChapterRepository : RepositoryBase<Chapter>, IChapterRepository
{
    private readonly FanficContext _context;

    private readonly IMapper _mapper;

    public ChapterRepository(FanficContext context, IMapper mapper) : base(context)
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

    public async Task<Chapter?> GetByIdAsync(int id)
    {
        var chapter =  await _context.Chapters.FirstOrDefaultAsync(x => x.ChapterId == id);
        return _mapper.Map<Chapter>(chapter);
    }

    public async Task<List<Chapter>> GetAllAsync()
    {
        var chapters = await _context.Chapters.ToListAsync();
        return  _mapper.Map<List<Chapter>>(chapters);
    }

    public async Task<List<Chapter>> GetAllByFanficIdAsync(int fanficId)
    {
        var chapters = await _context.Chapters.Where(x => x.FanficId == fanficId).ToListAsync();
        return _mapper.Map<List<Chapter>>(chapters);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}