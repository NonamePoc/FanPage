namespace FanPage.Application.CustomUserSetting;

public class StickerDto
{
    public int StickerId { get; set; }

    public byte[] Image { get; set; }

    public int CustomizationSettingsId { get; set; }
}