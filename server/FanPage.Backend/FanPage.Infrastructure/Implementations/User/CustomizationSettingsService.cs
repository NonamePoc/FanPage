using FanPage.Application.CustomUserSetting;
using FanPage.Common.Interfaces;
using FanPage.Domain.User.Repos.Interfaces;
using FanPage.Infrastructure.Interfaces.User;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Implementations.User
{
    public class CustomizationSettingsService : ICustomizationSettings
    {
        private readonly ICustomizationSettingsRepository _customizationSettings;

        private readonly IJwtTokenManager _jwtTokenManager;

        public CustomizationSettingsService(ICustomizationSettingsRepository customizationSettings,
            IJwtTokenManager jwtTokenManager)
        {
            _customizationSettings = customizationSettings;
            _jwtTokenManager = jwtTokenManager;
        }

        public async Task<CustomUserSettingDto> ChangeBannerImage(int customizationSettingsId, byte[] bannerImage, HttpRequest request)
        {
            var customizationSettings = await _customizationSettings.GetCustomizationSettings(customizationSettingsId);

            if (customizationSettings == null) throw new Exception("Customization settings not found");

            var userId = _jwtTokenManager.GetUserIdFromToken(request);

            if (userId != null) throw new Exception("User not found");

            await _customizationSettings.ChangeBannerImage(customizationSettingsId, bannerImage);
            
            return new CustomUserSettingDto
            {
                BannerImage = bannerImage,
                CustomizationSettingsId = customizationSettingsId
            };
        }

        public async Task<CustomUserSettingDto> GetCustomizationSettings(int customizationSettingsId,
            HttpRequest request)
        {
            var userId = _jwtTokenManager.GetUserIdFromToken(request);
            if (userId == null) throw new Exception("User not found");
            var customizationSettings = await _customizationSettings.GetCustomizationSettings(customizationSettingsId);

            return new CustomUserSettingDto
            {
                BannerImage = customizationSettings.BannerImage,
                CustomizationSettingsId = customizationSettings.CustomizationSettingsId
            };
        }
    }
}