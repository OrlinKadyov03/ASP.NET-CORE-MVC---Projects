using CarServiceShop.Data;
using CarServiceShop.Interfaces;
using CarServiceShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CarServiceShop.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<Car>> GetCars()
        {
            return await this._context.Cars.ToListAsync();
        }
    }
}
