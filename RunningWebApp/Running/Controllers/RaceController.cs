using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Running.Data;
using Running.Interfaces;
using Running.Models;
using Running.Repository;
using Running.Services;
using Running.ViewModels;

namespace Running.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceRepository _raceRepository;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RaceController(IRaceRepository raceRepository,IPhotoService photoService
            ,IHttpContextAccessor httpContextAccessor)
        {
            this._raceRepository = raceRepository;
            this._photoService = photoService;
            this._httpContextAccessor = httpContextAccessor;
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

        public IActionResult Create() 
        {
            var curUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var createRaceViewModel = new CreateRaceViewModel { AppUserId = curUserId };
            return View(createRaceViewModel);
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
                    AppUserId = raceVM.AppUserId,
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
                ModelState.AddModelError("", "Photo upload failed");
            }
            return View(raceVM);
        }

        public async Task<IActionResult> Edit(int id) 
        {
            var race = await _raceRepository.GetIdByAsync(id);
            if (race == null) return View("Error");
            var raceVM = new EditRaceViewModel
            {
                Id = id,
                Title = race.Title,
                Description = race.Description,
                AddressId = race.AddressId,
                Address = race.Address,
                URL = race.Image,
                RaceCategory = race.RaceCategory

            };
            return View(raceVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,EditRaceViewModel raceVM) 
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit race");
                return View("Edit", raceVM);
            }

            var userRace = await _raceRepository.GetIdByNotTrackingAsync(id);
            if (userRace != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userRace.Image);
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(raceVM);
                }

                var photoResult = await _photoService.AddPhotoAsync(raceVM.Image);

                var race = new Race
                {
                    Id = id,
                    Title = raceVM.Title,
                    Description = raceVM.Description,
                    AddressId = raceVM.AddressId,
                    Address = raceVM.Address,
                    Image = photoResult.Url.ToString()
                };

                _raceRepository.Update(race);

                return RedirectToAction("Index");
            }
            else 
            {
                return View(raceVM);
            }
        }
    }
}
