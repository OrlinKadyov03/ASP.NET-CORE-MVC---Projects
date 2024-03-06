using CarServiceShop.Models;

namespace CarServiceShop.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<Owner>> GetAllUsers();
        Task<Owner> GetUserById(string id);

        bool Add(Owner owner);

        bool Update(Owner owner);

        bool Delete(Owner owner);

        bool Save();
    }
}
