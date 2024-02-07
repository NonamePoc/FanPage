using FanPage.Application.CustomUserSetting;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Interfaces.User;

public interface ICustomizationSettings
{
    Task<CustomUserSettingDto> ChangeBannerImage(int customizationSettingsId, byte[] bannerImage, HttpRequest request);
    
    Task<CustomUserSettingDto> GetCustomizationSettings(int customizationSettingsId, HttpRequest request);
}