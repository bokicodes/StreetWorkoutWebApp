using StreetWorkoutWebApp.Models;

namespace StreetWorkoutWebApp.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Park>> GetUsersParks();
        Task<AppUser> GetUserById(string id);
    }
}
