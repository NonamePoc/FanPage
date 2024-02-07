using FanPage.Application.Fanfic;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Interfaces.Fanfic;

public interface ITag
{
    Task<TagDto> CreateTagAsync(int fanficId, TagDto tagDto, HttpRequest request);

    Task<TagDto> SetTagAsync(int fanficId, string? name, HttpRequest request);

    Task DeleteTagAsync(int tagId, HttpRequest request);

    Task<TagDto> DeleteTagFanficAsync(int fanficId, string? tagName, HttpRequest request);
    
    Task<List<TagDto>> GetAllTagFanfic(int fanficId);

    Task<List<TagDto>> GetAllTagAsync();
}