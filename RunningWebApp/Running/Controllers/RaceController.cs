using Microsoft.AspNetCore.Mvc;

namespace Running.Controllers
{
    public class RaceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
