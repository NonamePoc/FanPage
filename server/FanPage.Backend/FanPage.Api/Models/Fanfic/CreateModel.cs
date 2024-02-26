namespace FanPage.Api.Models.Fanfic
{
    public class CreateModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool? OriginFandom { get; set; }
        public string? Language { get; set; }
        public string? Stage { get; set; }

        public List<string> Categories { get; set; }
        public List<string> Tags { get; set; }

        public List<FanficPhotoModel> ImageFanfic { get; set; }
    }
}
