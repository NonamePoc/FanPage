using AutoMapper;
using FanPage.Application.Fanfic;
using FanPage.Domain.Entities.Fanfic;
using FanPage.Persistence.Context;
using FanPage.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace FanPage.Persistence.Repositories.Implementations.FanficRepos
{
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        private readonly FanficContext _context;

        private readonly IMapper _mapper;

        public TagRepository(FanficContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Tag> GetByNameAsync(string name)
        {
            return await _context.Tags.Where(x => x.Name == name).FirstOrDefaultAsync();
        }

        public async Task<TagDto> GetByIdAsync(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            return _mapper.Map<TagDto>(tag);
        }

        public async Task<List<Tag>> GetAllAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<TagDto> CreateAsync(TagDto tag)
        {
            var tagEntity = _mapper.Map<Tag>(tag);
            await _context.Tags.AddAsync(tagEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<TagDto>(tagEntity);
        }

        public async Task UpdateAsync(TagDto tag)
        {
            var tagEntity = _mapper.Map<Tag>(tag);
            _context.Tags.Update(tagEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
        }

        public async Task AddTagToFanficAsync(int fanficId, int tagId)
        {
            var fanficTag = new FanficTag { FanficId = fanficId, TagId = tagId };
            await _context.FanficTags.AddAsync(fanficTag);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTagFromFanficAsync(int fanficId, string tagName)
        {
            var fanficTag =
                await _context.FanficTags.FirstOrDefaultAsync(x => x.FanficId == fanficId && x.Tag.Name == tagName);
            _context.FanficTags.Remove(fanficTag);
            await _context.SaveChangesAsync();
        }

        public async Task<TagDto> GetTagByFanficIdAsync(int fanficId, int tagId)
        {
            var tag = await _context.FanficTags.FirstOrDefaultAsync(x => x.FanficId == fanficId && x.TagId == tagId);
            return _mapper.Map<TagDto>(tag);
        }

        public async Task<List<TagDto>> GetTagsByFanficIdAsync(int fanficId)
        {
            var tags = await _context.FanficTags.Where(x => x.FanficId == fanficId).Select(x => x.Tag).ToListAsync();
            return _mapper.Map<List<TagDto>>(tags);
        }
    }
}