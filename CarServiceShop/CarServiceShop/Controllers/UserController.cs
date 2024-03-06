using Microsoft.AspNetCore.Mvc;

namespace CarServiceShop.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
