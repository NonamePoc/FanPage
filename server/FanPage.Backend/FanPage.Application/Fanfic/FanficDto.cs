using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Application.Fanfic
{
    public class FanficDto
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }

        public byte[]? Image { get; set; }

        public string? Stage { get; set; }
        public string? Language { get; set; }
        public string? Description { get; set; }
        public bool? OriginFandom { get; set; }
        public DateTimeOffset CreationDate { get; set; }

        public List<CategoryDto>? Categories { get; set; }
        public List<TagDto>? Tags { get; set; }
        
        public List<ChapterDto>? Chapters { get; set; }
        
        public List<ReviewsDto>? Reviews { get; set; }
    }
}