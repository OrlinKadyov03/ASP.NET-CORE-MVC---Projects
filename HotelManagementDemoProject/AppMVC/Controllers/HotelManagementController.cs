using AppMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Controllers
{
    public class HotelManagementController : Controller
    {
        public IActionResult Index()
        {
            Manage manage = new Manage() { Name = "Orlin", Age = 20, IdNum = 5 };
            return View(manage);
        }
    }
}
