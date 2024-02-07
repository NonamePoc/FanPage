namespace FanPage.Application.CustomUserSetting;

public class CustomUserSettingDto
{
    public int CustomizationSettingsId { get; set; }
    public ICollection<StickerDto> CustomStickers { get; set; }
    public byte[]? BannerImage { get; set; }
}