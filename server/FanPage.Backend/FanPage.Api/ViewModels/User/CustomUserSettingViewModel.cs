namespace FanPage.Api.ViewModels.User;

public class CustomUserSettingViewModel
{
    public int CustomizationSettingsId { get; set; }
    public byte[]? BannerImage { get; set; }
    
    public ICollection<StickerViewModel> CustomStickers { get; set; }
}