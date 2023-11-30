namespace FanPage.Api.ViewModels.Fanfic;

public class ChapterViewModel
{
    public int ChapterId { get; set; }
    
    public int FanficId { get; set; }
    
    public string? Title { get; set; }
    
    public string? Content { get; set; }
}