using FanPage.Application.CustomUserSetting;
using FanPage.Domain.Account.Entities;

namespace FanPage.Domain.Account.Repos.Interfaces;

public interface ICustomizationSettingsRepository
{
    Task ChangeBannerImage(int customizationSettingsId, byte[] bannerImage);

    Task<int> CreateCustomizationSettings();

    Task<CustomUserSettingDto> GetCustomizationSettings(int customizationSettingsId);
}