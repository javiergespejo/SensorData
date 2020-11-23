using Microsoft.EntityFrameworkCore;
using SensorDataChallenge.Models;

namespace SensorDataChallenge.Data
{
    public class SensorDataDbContext : DbContext
    {
        public SensorDataDbContext()
        {
        }

        public SensorDataDbContext(DbContextOptions<SensorDataDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
