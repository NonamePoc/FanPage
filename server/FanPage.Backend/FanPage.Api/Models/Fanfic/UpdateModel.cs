using FanPage.Application.Fanfic;

namespace FanPage.Api.Models.Fanfic
{
    public class UpdateModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool? OriginFandom { get; set; }
        public string? Stage { get; set; }
        
        public List<FanficPhotoModel> Photo { get; set; }
    }
}