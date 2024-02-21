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

        public bool Add(Car car)
        {
            this._context.Cars.Add(car);
            return Save();
        }

        public bool Delete(Car car)
        {
            this._context.Cars.Remove(car);
            return Save();
        }

        public async Task<IEnumerable<Car>> GetCars()
        {
            return await this._context.Cars.ToListAsync();
        }

        public async Task<Car> GetIdByAsync(int id)
        {
           return await this._context.Cars.FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<Car> GetIdByAsyncAsNoTracking(int id)
        {
            return await this._context.Cars.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }
        public bool Save()
        {
            var saved = this._context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Car car)
        {
            this._context.Cars.Update(car);
            return Save();
        }
    }
}
