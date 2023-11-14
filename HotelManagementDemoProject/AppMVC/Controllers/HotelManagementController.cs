using AppMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Controllers
{
    public class HotelManagementController : Controller
    {
        private static List<Manage> person = new List<Manage>();
        public IActionResult Index()
        {
            return View(person);
        }
        public IActionResult Create()
        {
            var myPerson = new Manage();
            return View(myPerson);
        }

        public IActionResult CreatePerson(Manage manage)
        {
            person.Add(manage);
            return RedirectToAction(nameof(Index));
        }
    }
}
