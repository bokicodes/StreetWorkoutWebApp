using Microsoft.EntityFrameworkCore;
using StreetWorkoutWebApp.Models;

namespace StreetWorkoutWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Park> Parks { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
