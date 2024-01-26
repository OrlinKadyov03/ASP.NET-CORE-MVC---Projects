using Running.Data;
using Running.Interfaces;
using Running.Models;

namespace Running.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardRepository(ApplicationDbContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            this._context = context;
            this._httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<Club>> GetAllUserClubs()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userClubs = _context.Clubs.Where(r => r.AppUser.Id == curUser);
            return userClubs.ToList();
        }

        public async Task<List<Race>> GetAllUserRaces()
        {
            var curUser = _httpContextAccessor?.HttpContext?.User.GetUserId();
            var userRaces = _context.Races.Where(r => r.AppUser.Id == curUser);
            return userRaces.ToList();
        }
    }
}
