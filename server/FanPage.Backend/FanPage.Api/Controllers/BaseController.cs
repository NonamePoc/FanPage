using Microsoft.AspNetCore.Mvc;

namespace FanPage.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        [HttpGet]
        public string? GetUserId()
        {
            return User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;
        }
    }
}
