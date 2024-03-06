using CarServiceShop.Data;
using CarServiceShop.Interfaces;
using CarServiceShop.Models;
using Microsoft.EntityFrameworkCore;

namespace CarServiceShop.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public bool Add(Owner owner)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Owner owner)
        {
           throw new NotImplementedException();
        }

        public async Task<IEnumerable<Owner>> GetAllUsers()
        {
            return await _context.Owners.ToListAsync();
        }

        public async Task<Owner> GetUserById(string id)
        {
            return await _context.Owners.FindAsync(id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Owner owner)
        {
            _context.Update(owner);
            return Save();
        }
    }
}
