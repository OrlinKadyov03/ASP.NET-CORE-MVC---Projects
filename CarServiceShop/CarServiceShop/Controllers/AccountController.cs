using CarServiceShop.Data;
using CarServiceShop.Models;
using CarServiceShop.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<Owner> _userManager;
        private readonly SignInManager<Owner> _signInManager;

        public AccountController(ApplicationDbContext applicationDbContext, UserManager<Owner> userManager, SignInManager<Owner> signInManager)
        {
            this._applicationDbContext = applicationDbContext;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }
    }
}
