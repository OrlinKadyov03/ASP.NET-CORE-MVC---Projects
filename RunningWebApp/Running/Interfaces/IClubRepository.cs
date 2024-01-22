using Running.Models;

namespace Running.Interfaces
{
    public interface IClubRepository
    {
        Task<IEnumerable<Club>> GetAll();
        Task<Club> GetIdByAsync(int id);

        Task<Club> GetIdByNotTrackingAsync(int id);
        Task<IEnumerable<Club>> GetAllClubByCity(string city);

        bool Add(Club club);    

        bool Update(Club club); 
        bool Delete(Club club);
        bool Save();
    }
}
