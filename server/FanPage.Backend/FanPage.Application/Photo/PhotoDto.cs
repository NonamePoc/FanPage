namespace FanPage.Application.Photo
{
    public class PhotoDto
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }

        public string UserId { get; set; }
    }
}