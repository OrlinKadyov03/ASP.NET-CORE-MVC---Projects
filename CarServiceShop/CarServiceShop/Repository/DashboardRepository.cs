using CarServiceShop.Data;
using CarServiceShop.Interfaces;
using CarServiceShop.Models;
using Microsoft.EntityFrameworkCore;

namespace CarServiceShop.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardRepository(ApplicationDbContext dbContext,IHttpContextAccessor httpContextAccessor)
        {
            this._dbContext = dbContext;
            this._httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<Car>> GetAllUserCars()
        {
            var curOwner = _httpContextAccessor.HttpContext?.User.GetUserId();
            var OwnerCars = _dbContext.Cars.Where(r => r.Owner.Id == curOwner);
            return OwnerCars.ToList();
        }

        public async Task<Owner> GetIdByNoTracking(string id)
        {
            return await _dbContext.Owners.FindAsync(id);
        }

        public async Task<Owner> GetUserById(string id)
        {
            return await _dbContext.Owners.Where(i => i.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public bool Save()
        {
            var saved = _dbContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Owner owner)
        {
            _dbContext.Owners.Update(owner);
            return Save();
        }
    }
}
