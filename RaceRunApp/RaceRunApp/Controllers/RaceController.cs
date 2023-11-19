using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceRunApp.Data;
using RaceRunApp.Interfaces;
using RaceRunApp.Models;
using RaceRunApp.ViewModels;

namespace RaceRunApp.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceRepository _raceRepository;
        private readonly IPhotoService _photoService;

        public RaceController(IRaceRepository raceRepository,IPhotoService photoService)
        {
            this._raceRepository = raceRepository;
            this._photoService = photoService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Race> races = await _raceRepository.GetAll();
            return View(races);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Race race = await _raceRepository.GetIdByAsync(id);
            return View(race);
        }

        //Race Repository

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRaceViewModel raceVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(raceVM.Image);

                var race = new Race
                {
                    Title = raceVM.Title,
                    Description = raceVM.Description,
                    Image = result.Url.ToString(),
                    Address = new Address
                    {
                        Street = raceVM.Address.Street,
                        City = raceVM.Address.City,
                        State = raceVM.Address.State
                    }

                 };
            _raceRepository.Add(race);
            return RedirectToAction("Index");
           }
           else
           {
               ModelState.AddModelError("", "Failed to upload file!");
           }
           return View(raceVM);
        }

    }
}
