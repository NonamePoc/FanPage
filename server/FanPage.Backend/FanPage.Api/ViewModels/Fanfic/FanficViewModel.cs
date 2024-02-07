using FanPage.Application.Fanfic;

namespace FanPage.Api.ViewModels.Fanfic;

public class FanficViewModel
{
    public string? Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public byte[]? Image { get; set; }

    public string? AuthorName { get; set; }

    public bool? OriginFandom { get; set; }

    public string? Stage { get; set; }

    public string? Language { get; set; }

    public List<CategoryDto> Categories { get; set; }

    public List<TagDto> Tags { get; set; }
}