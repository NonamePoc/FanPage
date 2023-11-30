namespace FanPage.Api.ViewModels.Fanfic;

public class ReviewViewModel
{
    public int ReviewId { get; set; }

    public string UserName { get; set; }

    public string Text { get; set; }
    
    public double Rating { get; set; }

    public DateTimeOffset CreationDate { get; set; }

    public int FanficId { get; set; }
}