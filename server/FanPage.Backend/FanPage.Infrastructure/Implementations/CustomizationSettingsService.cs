using FanPage.Domain.Entities.Identity;
using FanPage.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Infrastructure.Implementations
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

