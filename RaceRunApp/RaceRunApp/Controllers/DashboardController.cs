using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using RaceRunApp.Data;
using RaceRunApp.Interfaces;
using RaceRunApp.Models;
using RaceRunApp.ViewModels;

namespace RaceRunApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPhotoService _photoService;

        // Explain
        public DashboardController(IDashboardRepository dashboardRepository,
            IHttpContextAccessor httpContextAccessor,IPhotoService photoService)
        {
            this._dashboardRepository = dashboardRepository;
            this._httpContextAccessor = httpContextAccessor;
            this._photoService = photoService;
        }

        private void MapUserEdit(AppUser user,EditUserViewModel editVM,ImageUploadResult photoResult) 
        {
            user.Id = editVM.Id;
            user.Pace = editVM.Pace;
            user.Mileage = editVM.Mileage;
            user.ProfileImageUrl = photoResult.Url.ToString();
            user.City = editVM.City;
            user.State = editVM.State;

        }
        public async Task<IActionResult> Index()
        {
            var userRaces = await _dashboardRepository.GetAllUserRaces();
            var userClubs = await _dashboardRepository.GetAllUserClubs();
            var userViewModel = new DashboardViewModel()
            {
                Races = userRaces,
                Clubs = userClubs
            };
            return View(userViewModel);
        }

        public async Task<IActionResult> EditUserProfile() 
        {
            var curUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var user = await _dashboardRepository.GeUserById(curUserId);
            if (user == null) 
            {
                return View("Error");
            }
            var editUserViewModel = new EditUserViewModel()
            {
                Id = curUserId,
                Pace = user.Pace,
                Mileage = user.Mileage,
                City = user.City,
                State = user.State,
                ProfileImageUrl = user.ProfileImageUrl

            };
            return View(editUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserProfile(EditUserViewModel editVM) 
        {
            if (!ModelState.IsValid) 
            {
                ModelState.AddModelError("", "Failed to edit");
                return View("EditUserProfile", editVM);
            }

            var user = await _dashboardRepository.GetIdByNoTracking(editVM.Id);

            if (user.ProfileImageUrl == "" || user.ProfileImageUrl == null) 
            {
                var photoResult = await _photoService.AddPhotoAsync(editVM.Image);

                MapUserEdit(user,editVM, photoResult);

                _dashboardRepository.Update(user);

                return RedirectToAction("Index");
            }
            else
            {
                try
                {
                    await _photoService.DeletePhotoAsync(user.ProfileImageUrl);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to delete photo");
                    return View(editVM);
                }

                var photoResult = await _photoService.AddPhotoAsync(editVM.Image);

                MapUserEdit(user, editVM, photoResult);

                _dashboardRepository.Update(user);

                return RedirectToAction("Index");


            }
        }
    }
}
