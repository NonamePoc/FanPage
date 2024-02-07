using AutoMapper;
using FanPage.Application.CustomUserSetting;
using FanPage.Domain.Account.Context;
using FanPage.Domain.Account.Entities;
using FanPage.Domain.Account.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FanPage.Domain.Account.Repos.Impl;

public class CustomizationSettingsRepository : ICustomizationSettingsRepository
{
    private readonly UserContext _context;
    private readonly IMapper _mapper;

    public CustomizationSettingsRepository(UserContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task ChangeBannerImage(int customizationSettingsId, byte[] bannerImage)
    {
        var customizationSettings = await _context.CustomizationSettings
            .FirstOrDefaultAsync(cs => cs.CustomizationSettingsId == customizationSettingsId);
        if (customizationSettings != null) customizationSettings.BannerImage = bannerImage;
        await _context.SaveChangesAsync();
    }
    
    public async Task<int> CreateCustomizationSettings()
    {
        var customizationSettings = new CustomizationSettings();
        _context.CustomizationSettings.Add(customizationSettings);
        await _context.SaveChangesAsync();

        return customizationSettings.CustomizationSettingsId;
    }

    public async Task<CustomUserSettingDto> GetCustomizationSettings(int customizationSettingsId)
    {
        var customizationSettings = await _context.CustomizationSettings
            .FirstOrDefaultAsync(cs => cs.CustomizationSettingsId == customizationSettingsId);
        return _mapper.Map<CustomUserSettingDto>(customizationSettings);
    }
}