using Microsoft.AspNetCore.Mvc;

namespace Running.Controllers
{
    public class ClubController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
