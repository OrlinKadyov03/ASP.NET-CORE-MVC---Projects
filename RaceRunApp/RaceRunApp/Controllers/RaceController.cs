using Microsoft.AspNetCore.Mvc;
using RaceRunApp.Data;
using RaceRunApp.Models;

namespace RaceRunApp.Controllers
{
    public class RaceController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RaceController(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            List<Race> races = _context.Races.ToList();
            return View(races);
        }
    }
}
