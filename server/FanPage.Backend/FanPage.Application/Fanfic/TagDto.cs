namespace FanPage.Application.Fanfic;

public class TagDto
{
    public int TagId { get; set; }
    public string Name { get; set; }

    public bool IsApproved { get; set; }

    public ICollection<FanficTagDto> FanficTags { get; set; }
}