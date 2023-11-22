using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceRunApp.Data;
using RaceRunApp.Interfaces;
using RaceRunApp.Models;
using RaceRunApp.ViewModels;
using System.Diagnostics.Eventing.Reader;

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
        public async Task<IActionResult> Edit(int id) 
        {
            var race = await _raceRepository.GetIdByAsync(id);
            if (race == null) return View("Error");
            var raceVM = new EditRaceViewModel
            {
                Title = race.Title,
                Description = race.Description,
                URL = race.Image,
                AddressId = race.AddressId,
                Address = race.Address,
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

            var raceClub = await _raceRepository.GetIdByAsyncNoTracking(id);
            if (raceClub != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(raceClub.Image);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to delete photo!");
                    return View(raceVM);
                }

                var photoResult = await _photoService.AddPhotoAsync(raceVM.Image);

                var race = new Race
                {
                    Id = id,
                    Title = raceVM.Title,
                    Description = raceVM.Description,
                    Address = raceVM.Address,
                    Image = photoResult.Uri.ToString(),
                    AddressId = raceVM.AddressId,

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
