using AppMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Controllers
{
    public class HotelManagementController : Controller
    {
        private static List<Person> persons = new List<Person>();
        public IActionResult Index()
        {
            return View(persons);
        }
        public IActionResult Create()
        {
            var myPerson = new Person();
            return View(myPerson);
        }

        public IActionResult CreatePerson(Person person)
        {
            persons.Add(person);
            return RedirectToAction(nameof(Index));
        }
    }
}
