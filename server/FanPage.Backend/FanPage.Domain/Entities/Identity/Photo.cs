using System.ComponentModel.DataAnnotations.Schema;


namespace FanPage.Domain.Entities.Identity
{
    public class Photo
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")] public User User { get; set; }
    }
}