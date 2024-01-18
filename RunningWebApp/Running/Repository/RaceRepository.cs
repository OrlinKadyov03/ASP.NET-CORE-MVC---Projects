using Microsoft.EntityFrameworkCore;
using Running.Data;
using Running.Interfaces;
using Running.Models;

namespace Running.Repository
{
    public class RaceRepository : IRaceRepository
    {
        private readonly ApplicationDbContext _context;

        public RaceRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public bool Add(Race race)
        {
            this._context.Races.Add(race);
            return Save();
        }

        public bool Delete(Race race)
        {
            this._context.Races.Remove(race);
            return Save();
        }

        public async Task<IEnumerable<Race>> GetAll()
        {
            return await this._context.Races.ToListAsync();
        }

        public async Task<Race> GetIdByAsync(int id)
        {
            return await this._context.Races.Include(i=>i.Address).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Race>> GetAllRaceByCity(string city)
        {
            return await this._context.Races.Where(r=>r.Address.City.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Race race)
        {
            this._context.Update(race);
            return Save();
        }
    }
}
