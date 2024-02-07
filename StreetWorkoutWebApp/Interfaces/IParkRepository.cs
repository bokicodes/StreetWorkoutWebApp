using StreetWorkoutWebApp.Models;

namespace StreetWorkoutWebApp.Interfaces
{
    public interface IParkRepository
    {
        Task<IEnumerable<Park>> GetAll();
        Task<Park> GetByIdAsync(int id);
        Task<IEnumerable<Park>> GetParksByCity(string city);
        bool Add(Park park);
        bool Update(Park park);
        bool Delete(Park park);
        bool Save();
    }
}
