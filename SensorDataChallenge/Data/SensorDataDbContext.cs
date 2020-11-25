using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SensorDataChallenge.Models;

namespace SensorDataChallenge.Data
{
    public class SensorDataDbContext : IdentityDbContext
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
        public DbSet<Permission> Permission { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Permission>()
                .HasData(
                    new Permission
                    {
                        Id = 1,
                        Description = "ViewUsers"
                    },
                    new Permission
                    {
                        Id = 2,
                        Description = "CreateUser"
                    },
                    new Permission
                    {
                        Id = 3,
                        Description = "UpdateUser"
                    },
                    new Permission
                    {
                        Id = 4,
                        Description = "DeleteUser"
                    },
                    new Permission
                    {
                        Id = 5,
                        Description = "ViewClients"
                    },
                    new Permission
                    {
                        Id = 6,
                        Description = "CreateClient"
                    },
                    new Permission
                    {
                        Id = 7,
                        Description = "UpdateClient"
                    },
                    new Permission
                    {
                        Id = 8,
                        Description = "DeleteClient"
                    },
                    new Permission
                    {
                        Id = 9,
                        Description = "ViewMap"
                    }
                );
        }
    }
}
