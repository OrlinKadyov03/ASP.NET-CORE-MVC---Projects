using Running.Models;

namespace Running.Interfaces
{
    public interface IRaceRepository
    {
        Task<IEnumerable<Race>> GetAll();
        Task<Race> GetIdByAsync(int id);

        Task<Race> GetIdByNotTrackingAsync(int id);
        Task<IEnumerable<Race>> GetAllRaceByCity(string city);

        bool Add(Race race);

        bool Update(Race race);
        bool Delete(Race race);
        bool Save();
    }
}
