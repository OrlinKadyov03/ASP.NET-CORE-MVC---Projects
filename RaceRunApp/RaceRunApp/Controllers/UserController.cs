using Microsoft.AspNetCore.Mvc;

namespace RaceRunApp.Controllers
{
    public class UserController : Controller
    {
        [HttpGet("users")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
