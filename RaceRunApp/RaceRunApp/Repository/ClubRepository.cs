using Microsoft.EntityFrameworkCore;
using RaceRunApp.Data;
using RaceRunApp.Interfaces;
using RaceRunApp.Models;

namespace RaceRunApp.Repository
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
            _context.Add(club);
            return Save();
        }

        public bool Delete(Club club)
        {
            _context.Remove(club);
            return Save();
        }

        public async Task<IEnumerable<Club>> GetAll()
        {
            return await _context.Clubs.ToListAsync();
            
        }

        public async Task<IEnumerable<Club>> GetClubByCity(string city)
        {
            return await _context.Clubs.Where(c=>c.Address.City.Contains(city)).ToListAsync();
            
        }

        public async Task<Club> GetIdByAsync(int id)
        {
            return await _context.Clubs.Include(i=>i.Address).FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task<Club> GetIdByAsyncNoTracking(int id)
        {
            return await _context.Clubs.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Club club)
        {
           _context.Update(club);
            return Save();
        }
    }
}
