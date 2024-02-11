using Running.Models;

namespace Running.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Club>> GetAllUserClubs();
        Task<List<Race>> GetAllUserRaces();
        Task<AppUser> GetUserById(string id);
        Task<AppUser> GetIdByNoTracking(string id);

        bool Update(AppUser user);

        bool Save();
    }
}
