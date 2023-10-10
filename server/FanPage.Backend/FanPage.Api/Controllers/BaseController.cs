using Microsoft.AspNetCore.Mvc;

namespace FanPage.APi.Controllers
{
    public class BaseController : ControllerBase
    {
        [HttpGet]
        public string? GetUserId()
        {
            return User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
        }
    }
}
