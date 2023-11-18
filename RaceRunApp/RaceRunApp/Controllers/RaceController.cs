using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceRunApp.Data;
using RaceRunApp.Interfaces;
using RaceRunApp.Models;

namespace RaceRunApp.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceRepository _raceRepository;

        public RaceController(IRaceRepository raceRepository)
        {
            this._raceRepository = raceRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Race> races = await _raceRepository.GetAll();
            return View(races);
        }


        //Race Repository
    }
}
