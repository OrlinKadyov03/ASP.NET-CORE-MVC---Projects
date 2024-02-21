using CarServiceShop.Data;
using CarServiceShop.Interfaces;
using CarServiceShop.Models;
using CarServiceShop.ViewModels;
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
        public async Task<IActionResult> Create(CreateCarViewModel carVM) 
        {
            if (ModelState.IsValid)
            {
                var car = new Car
                {
                    Brand = carVM.Brand,
                    Model = carVM.Model,
                    EngineVolume = carVM.EngineVolume,
                    Horsepower = carVM.Horsepower,
                    EngineType = carVM.EngineType,
                    TransmisionType = carVM.TransmisionType,
                    Color = carVM.Color,
                    Category = carVM.Category,
                    DescriptionProblem = carVM.DescriptionProblem,
                    RegisterPlate = carVM.RegisterPlate,
                    YearOfProduction = carVM.YearOfProduction,
                    Drivetrain = carVM.Drivetrain,
                };
                _carRepository.Add(car);

                return RedirectToAction("Index");
            }
            return View(carVM);
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var cardetails = await _carRepository.GetIdByAsync(id);
            if (cardetails == null) return View("Error");
            _carRepository.Delete(cardetails);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Edit(int id) 
        {
            var car = await _carRepository.GetIdByAsync(id);
            if (car == null) return View("Error");
            var carVM = new EditCarViewModel
            {
                Brand = car.Brand,
                Model = car.Model,
                EngineVolume = car.EngineVolume,
                Horsepower = car.Horsepower,
                EngineType = car.EngineType,
                TransmisionType = car.TransmisionType,
                Color = car.Color,
                Category = car.Category,
                DescriptionProblem = car.DescriptionProblem,
                RegisterPlate = car.RegisterPlate,
                YearOfProduction = car.YearOfProduction,
                Drivetrain = car.Drivetrain,
            };
            return View(carVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,EditCarViewModel editVM) 
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit club");
                return View("Edit", editVM);

            }

            var cardetails = await _carRepository.GetIdByAsyncAsNoTracking(id);
            if (cardetails != null)
            {
                var car = new Car
                {
                    Id = id,
                    Brand = editVM.Brand,
                    Model = editVM.Model,
                    EngineVolume = editVM.EngineVolume,
                    Horsepower = editVM.Horsepower,
                    EngineType = editVM.EngineType,
                    TransmisionType = editVM.TransmisionType,
                    Color = editVM.Color,
                    Category = editVM.Category,
                    DescriptionProblem = editVM.DescriptionProblem,
                    RegisterPlate = editVM.RegisterPlate,
                    YearOfProduction = editVM.YearOfProduction,
                    Drivetrain = editVM.Drivetrain,
                };
                _carRepository.Update(car);


                return RedirectToAction("Index");
            }
            else 
            {
                return View(editVM);
            }
                
        }

    }
}
