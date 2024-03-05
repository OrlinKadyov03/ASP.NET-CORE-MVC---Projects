using CarServiceShop.Models;
using System.Diagnostics;

namespace CarServiceShop.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Car>> GetAllUserCars();
        Task<Owner> GetUserById(string id);
        Task<Owner> GetIdByNoTracking(string id);

        bool Update(Owner owner);

        bool Save();
    }
}
