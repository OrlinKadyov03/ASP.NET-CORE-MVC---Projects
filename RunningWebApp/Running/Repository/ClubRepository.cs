using Microsoft.EntityFrameworkCore;
using Running.Data;
using Running.Interfaces;
using Running.Models;

namespace Running.Repository
{
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationDbContext _context;

        public ClubRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public bool Add(Club club)
        {
            this._context.Add(club);
            return Save();
        }

        public bool Delete(Club club)
        {
           this._context.Remove(club);
            return Save();
        }

        public async Task<IEnumerable<Club>> GetAll()
        {
           return await this._context.Clubs.ToListAsync();
        }

        public async Task<IEnumerable<Club>> GetAllClubByCity(string city)
        {
            return await _context.Clubs.Where(c=>c.Address.City.Contains(city)).ToListAsync();
        }

        public async Task<Club> GetIdByAsync(int id)
        {
            return await _context.Clubs.Include(i =>i.Address).FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<Club> GetIdByNotTrackingAsync(int id) 
        {
            return await _context.Clubs.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Club club)
        {
            this._context.Update(club);
            return Save();
        }
    }
}
