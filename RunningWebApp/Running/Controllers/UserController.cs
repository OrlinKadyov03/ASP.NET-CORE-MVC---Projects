using Microsoft.AspNetCore.Mvc;

namespace Running.Controllers
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
