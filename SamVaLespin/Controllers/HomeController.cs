using Microsoft.AspNetCore.Mvc;
using SamVaLespin.Services;

namespace SamVaLespin.Controllers
{
    public class HomeController(ILogger<HomeController> logger, ImageService imageService) : ControllerBase
    {
        [HttpGet]
        public IActionResult Index() => File(imageService.GetPicture(), "image/jpeg");
    }
}
