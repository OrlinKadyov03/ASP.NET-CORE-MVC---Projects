using Microsoft.AspNetCore.Mvc;
using RaceRunApp.Data;
using RaceRunApp.Interfaces;
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
    }
}
