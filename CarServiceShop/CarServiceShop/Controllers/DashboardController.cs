using CarServiceShop.Interfaces;
using CarServiceShop.Models;
using CarServiceShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceShop.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController(IHttpContextAccessor httpContextAccessor, IDashboardRepository dashboardRepository)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._dashboardRepository = dashboardRepository;
        }

        public void MapUserEdit(Owner owner,EditUserDashboardViewModel editVM)
        {
            owner.Id = editVM.Id;
            owner.FirstName = editVM.FirstName;
            owner.LastName = editVM.LastName;
            owner.Address.City = editVM.City;
            owner.Address.State = editVM.State;

        }
        public async Task<IActionResult> Index()
        {
            var carOwners = await _dashboardRepository.GetAllUserCars();
            var dashboardViewModel = new DashboardViewModel()
            {
                Cars = carOwners,
            };
            return View(dashboardViewModel);
            
        }

        public async Task<IActionResult> EditUserProfile()
        {
            var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var user = await _dashboardRepository.GetUserById(curUserId);
            if (user == null) return View("Error");
            var editUserViewModel = new EditUserDashboardViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                City = user.Address?.City,
                State = user.Address?.State,
            };
            return View(editUserViewModel);
            
        }
        [HttpPost]
        public async Task<IActionResult> EditUserProfile(EditUserDashboardViewModel editVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Cannot edit profile");
                return View("EditUserProfile",editVM);
            }

            var user = await _dashboardRepository.GetIdByNoTracking(editVM.Id);
            MapUserEdit(user,editVM);
            _dashboardRepository.Update(user);

            return RedirectToAction("Index");
        }
    }
}
