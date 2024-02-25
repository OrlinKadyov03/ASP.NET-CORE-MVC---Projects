using CarServiceShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationBuilder _applicationDbContext;
        private readonly UserManager<Owner> _userManager;
        private readonly SignInManager<Owner> _signInManager;

        public AccountController(ApplicationBuilder applicationDbContext,UserManager<Owner> userManager,SignInManager<Owner> signInManager)
        {
            this._applicationDbContext = applicationDbContext;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
