namespace FanPage.Application.Fanfic
{
    public class UpdateDto
    {
        public string Title { get; set; }
        public byte[]? Image { get; set; }
        public string? Description { get; set; }
        public bool? OriginFandom { get; set; }
        public string? Stage { get; set; }
        public string? Language { get; set; }
        public List<string> Categories { get; set; }
        public List<string> Tags { get; set; }
    }
}