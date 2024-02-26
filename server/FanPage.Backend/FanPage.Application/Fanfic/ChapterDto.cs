namespace FanPage.Application.Fanfic;

public class ChapterDto
{
    public int ChapterId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public string FanficTitle { get; set; }

    public string AuthorName { get; set; }

    public byte[] FanficPhoto { get; set; }

    public int FanficId { get; set; }
}
