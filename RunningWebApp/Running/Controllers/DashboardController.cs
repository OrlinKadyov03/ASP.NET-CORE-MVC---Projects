using Microsoft.AspNetCore.Mvc;

namespace Running.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
