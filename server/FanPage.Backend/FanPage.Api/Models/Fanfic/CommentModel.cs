namespace FanPage.Api.Models.Fanfic;

public class CommentModel
{
    public string Content { get; set; }
    
    public byte[] Image { get; set; }
    
    public int FanficId { get; set; }
}