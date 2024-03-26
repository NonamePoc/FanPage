using System.ComponentModel.DataAnnotations.Schema;

namespace FanPage.Domain.Account.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
