namespace FanPage.Application.Fanfic;

public class CommentDto
{
    public int CommentId { get; set; }

    public string Content { get; set; }

    public string AuthorName { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public int FanficId { get; set; }

    public byte[] Image { get; set; }
}