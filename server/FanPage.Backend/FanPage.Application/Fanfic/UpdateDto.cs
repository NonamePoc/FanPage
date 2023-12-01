namespace FanPage.Application.Fanfic
{
    public class UpdateDto
    {
        public string? Description { get; set; }
        public bool? OriginFandom { get; set; }
        public string? Stage { get; set; }
        
        public List<FanficPhotoDto> Photo { get; set; }
    }
}