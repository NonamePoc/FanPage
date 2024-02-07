using System.ComponentModel.DataAnnotations;

namespace FanPage.Domain.Account.Entities
{
    public class Bookmark
    {
        [Key] public int BookmarkId { get; set; }
        public string? Stage { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int FanficReadingId { get; set; }
    }
}