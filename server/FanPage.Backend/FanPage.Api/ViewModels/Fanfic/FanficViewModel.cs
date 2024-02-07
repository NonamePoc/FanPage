using FanPage.Api.Models.Fanfic;

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

    public List<string> Categories { get; set; }

    public List<string> Tags { get; set; }

    public List<ChapterModel> Chapter { get; set; }
}