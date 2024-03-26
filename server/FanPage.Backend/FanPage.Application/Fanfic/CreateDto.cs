using Microsoft.AspNetCore.Http;

namespace FanPage.Application.Fanfic
{
    public class CreateDto
    {
        public string? Description { get; set; }
        public bool OriginFandom { get; set; }

        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string? Stage { get; set; }

        public string? Language { get; set; }

        public IFormFile File { get; set; }
        public List<string> Categories { get; set; }
        public List<string> Tags { get; set; }

        public List<FanficPhotoDto>? ImageFanfic { get; set; }
    }
}