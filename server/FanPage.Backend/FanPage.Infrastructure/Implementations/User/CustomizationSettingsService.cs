using FanPage.Domain.Entities.Identity;
using FanPage.Persistence.Context;

namespace FanPage.Infrastructure.Implementations.User
{
    public class CustomizationSettingsService
    {
        private readonly UserContext _context;

        public CustomizationSettingsService(UserContext context)
        {
            _context = context;
        }

        public async Task<int> CreateCustomizationSettings()
        {
            var customizationSettings = new CustomizationSettings();
            _context.CustomizationSettings.Add(customizationSettings);
            await _context.SaveChangesAsync();

            return customizationSettings.CustomizationSettingsId;
        }
    }
}