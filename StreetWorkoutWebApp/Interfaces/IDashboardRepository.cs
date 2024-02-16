using StreetWorkoutWebApp.Models;

namespace StreetWorkoutWebApp.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Park>> GetUsersParks();
        Task<AppUser> GetUserById(string id);
        Task<AppUser> GetUserByIdNoTracking(string id);
        bool Update(AppUser user);
        bool Save();
    }
}
