using Microsoft.AspNetCore.Mvc;
using SamVaLespin.Services;

namespace SamVaLespin.Controllers
{
    public class HomeController : ControllerBase
    {

        private readonly ILogger<HomeController> _logger;
        private readonly ImageService imageService;

        public HomeController(ILogger<HomeController> logger, ImageService imageService)
        {
            _logger = logger;
            this.imageService = imageService;
        }

        [HttpGet]
        public IActionResult Index() => File(imageService.GetRandomPicture(), "image/jpeg");
    }
}
