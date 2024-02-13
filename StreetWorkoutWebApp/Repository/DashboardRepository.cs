using StreetWorkoutWebApp.Data;
using StreetWorkoutWebApp.Interfaces;
using StreetWorkoutWebApp.Models;

namespace StreetWorkoutWebApp.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public async Task<List<Park>> GetUsersParks()
        {
            var currentUser = _httpContext.HttpContext?.User.GetUserId();

            var userParks = _context.Parks.Where(p => p.AppUser.Id == currentUser);

            return userParks.ToList();
        }
    }
}
