namespace FanPage.Api.Controllers.User;

using AutoMapper;
using JsonResponse;
using FanPage.Api.ViewModels.User;
using FanPage.Infrastructure.Interfaces.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route(Route)]
public class CustomizationController : ControllerBase
{
    private const string Route = "v1/customizationUser";

    private readonly ICustomizationSettings _customization;

    private readonly IMapper _mapper;

    public CustomizationController(ICustomizationSettings customization, IMapper mapper)
    {
        _customization = customization;
        _mapper = mapper;
    }

    
    /// <summary>
    ///   Change banner image
    /// </summary>
    /// <param name="customizationSettingsId"> User custom id</param>
    /// <param name="bannerImage"> img</param>
    /// <returns></returns>
    [HttpPut]
    [Route("changeBannerImage")]
    [ProducesResponseType(typeof(JsonResponseContainer<CustomUserSettingViewModel>), 200)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> ChangeBannerImage(int customizationSettingsId, byte[] bannerImage)
    {
        var retrieval =
            await _customization.ChangeBannerImage(customizationSettingsId, bannerImage, HttpContext.Request);
        var response = _mapper.Map<CustomUserSettingViewModel>(retrieval);
        return Ok(response);
    }
    
    /// <summary>
    ///  Customization settings user
    /// </summary>
    /// <param name="customizationSettingsId"> user custom id</param>
    /// <returns></returns>
    [HttpGet]
    [Route("getCustomizationSettings")]
    [ProducesResponseType(typeof(JsonResponseContainer<CustomUserSettingViewModel>), 200)]
    [ProducesResponseType(typeof(JsonResponseContainer[]), 400)]
    [ProducesResponseType(typeof(JsonResponseContainer), 500)]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> GetCustomizationSettings(int customizationSettingsId)
    {
        var retrieval = await _customization.GetCustomizationSettings(customizationSettingsId, HttpContext.Request);
        var response = _mapper.Map<CustomUserSettingViewModel>(retrieval);
        return Ok(response);
    }
}