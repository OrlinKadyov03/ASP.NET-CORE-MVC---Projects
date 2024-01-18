using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Running.Data;
using Running.Interfaces;
using Running.Models;

namespace Running.Controllers
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

        public async Task <IActionResult> Detail(int id) 
        {
            Race race = await _raceRepository.GetIdByAsync(id);
            return View(race);
        }
    }
}
