using RaceRunApp.Models;

namespace RaceRunApp.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Race>> GetAllUserRaces();
        Task<List<Club>> GetAllUserClubs();

        Task<AppUser> GeUserById(string id);

        Task<AppUser> GetIdByNoTracking(string id);

        bool Update(AppUser user);

        bool Save();
    }
}
