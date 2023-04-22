using Microsoft.AspNetCore.Mvc;
using OrCarsOriginal.Models;
using System.Diagnostics;

namespace OrCarsOriginal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Display()
        {
            ViewBag.Message = "";
            ViewBag.Info = "";

            return View();
        }

        // ref https://blog.elmah.io/upload-and-resize-an-image-with-asp-net-core-and-imagesharp/

        public IActionResult Upload()
        {
            // ...
            return View();
        }

        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            using var image = Image.Load(file.OpenReadStream());
            image.Mutate(x => x.Resize(150,150));
            image.SaveAsJpeg("wwwroot/image.jpg");
            return Ok(" File Uploaded ");
        }
    }
}