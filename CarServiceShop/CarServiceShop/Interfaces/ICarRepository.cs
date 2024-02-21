using CarServiceShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceShop.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetCars();

        Task<Car> GetIdByAsync(int id);

        Task<Car> GetIdByAsyncAsNoTracking(int id);

        bool Add(Car car);

        bool Update(Car car);
        bool Delete(Car car);
        bool Save();
    }
}
