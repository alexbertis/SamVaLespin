using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SamVaLespin.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public IActionResult Index()
        {
            return File(imageService.GetRandomPicture(), "image/jpeg");
        }
    }
}
