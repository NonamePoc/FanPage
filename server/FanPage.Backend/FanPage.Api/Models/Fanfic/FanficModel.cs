using FanPage.Application.Fanfic;

namespace FanPage.Api.Models.Fanfic
{
    public class FanficModel
    {
        public int Id { get; set; }
        
        public string AuthorName { get; set; }
        
        public double Rating { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public bool OriginFandom { get; set; }
        
        public DateTimeOffset CreationDate { get; set; }

        public List<FanficCategoryModel> Categories { get; set; }
        public List<FanficTagModel> Tags { get; set; }

        public List<ChapterModel> Chapters { get; set; }
        
        
    }
}