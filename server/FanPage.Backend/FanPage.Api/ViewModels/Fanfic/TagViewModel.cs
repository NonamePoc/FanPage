namespace FanPage.Api.ViewModels.Fanfic;

public class TagViewModel
{
    public int TagId { get; set; }
    
    public string Name { get; set; }

    public bool IsApproved { get; set; }
    
    public ICollection<FanficTagViewModel> FanficTags { get; set; }
}