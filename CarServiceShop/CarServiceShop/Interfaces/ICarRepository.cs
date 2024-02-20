using CarServiceShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceShop.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetCars();
    }
}
