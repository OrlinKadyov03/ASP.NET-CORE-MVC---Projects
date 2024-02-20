using CarServiceShop.Data;
using CarServiceShop.Interfaces;
using CarServiceShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarServiceShop.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            this._carRepository = carRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Car> cars = await _carRepository.GetCars();
            return View(cars);
        }

    }
}
