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

        public async Task<IActionResult> Detail(int id) 
        {
            Car car = await _carRepository.GetIdByAsync(id);
            return View(car);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Car car) 
        {
            if (!ModelState.IsValid)
            {
                return View(car);
            }
            _carRepository.Add(car);
            return RedirectToAction("Index");
        }

    }
}
