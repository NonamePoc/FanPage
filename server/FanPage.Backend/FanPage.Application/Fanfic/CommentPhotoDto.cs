namespace FanPage.Application.Fanfic;

public class CommentPhotoDto
{
    public int Id { get; set; }
    public byte[] Image { get; set; }
    public int CommentId { get; set; }
}