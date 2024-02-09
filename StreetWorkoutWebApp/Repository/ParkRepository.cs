using Microsoft.EntityFrameworkCore;
using StreetWorkoutWebApp.Data;
using StreetWorkoutWebApp.Interfaces;
using StreetWorkoutWebApp.Models;

namespace StreetWorkoutWebApp.Repository
{
    public class ParkRepository : IParkRepository
    {
        private readonly ApplicationDbContext _context;

        public ParkRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Park park)
        {
            _context.Add(park);
            return Save();
        }

        public bool Delete(Park park)
        {
            _context.Remove(park);
            return Save();
        }

        public async Task<IEnumerable<Park>> GetAll()
        {
            return await _context.Parks.ToListAsync();
        }

        public async Task<Park> GetByIdAsync(int id)
        {
            return await _context.Parks.Include(a => a.Address).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Park> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Parks.Include(a => a.Address).AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Park>> GetParksByCity(string city)
        {
            return await _context.Parks.Where(p => p.Address.City.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            int saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(Park park)
        {
            _context.Update(park);
            return Save();
        }
    }
}
