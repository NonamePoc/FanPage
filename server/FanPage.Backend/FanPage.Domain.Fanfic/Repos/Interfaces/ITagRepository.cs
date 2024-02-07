using FanPage.Application.Fanfic;
using FanPage.Domain.Fanfic.Entities;

namespace FanPage.Domain.Fanfic.Repos.Interfaces
{
    public interface ITagRepository
    {
        Task<Tag> GetByNameAsync(string? name);
        Task<TagDto> CreateAsync(TagDto tag);
        Task UpdateAsync(TagDto tag);
        Task DeleteAsync(int id);

        Task<List<TagDto>> GetNotApprovedTags();

        Task<List<Tag>> GetAllAsync();

        Task<TagDto> GetByIdAsync(int id);
        Task AddTagToFanficAsync(int fanficId, int tagId);

        Task<TagDto> GetTagByFanficIdAsync(int fanficId, int tagId);

        Task<List<TagDto>> GetTagsByFanficIdAsync(int fanficId);
        Task DeleteTagFromFanficAsync(int fanficId, string? tagName);

        Task<bool> ApproveTag(int tagId);
    }
}