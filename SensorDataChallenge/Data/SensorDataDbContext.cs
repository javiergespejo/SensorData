using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SensorDataChallenge.Models;

namespace SensorDataChallenge.Data
{
    public class SensorDataDbContext : IdentityDbContext<ApplicationUser>
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
            modelBuilder.Entity<Client>()
                .HasData(
                    new Client
                    {
                        Id = 1,
                        BusinessName = "Client1 SRL",
                        RucNum = 123456,
                        Address = "9 de Julio 1324",
                        Country = "Argentina",
                        City = "Rosario",
                        PostalCode = 2000,
                        Phone = "3145788845",
                        Fax = "2598741",
                        Email = "client1srl@client1srl.com",
                        Web = "www.client1srl.com",
                        IsActive = true
                    },
                    new Client
                    {
                        Id = 2,
                        BusinessName = "Client2 SRL",
                        RucNum = 123456,
                        Address = "9 de Julio 1324",
                        Country = "Argentina",
                        City = "Rosario",
                        PostalCode = 2000,
                        Phone = "3145788845",
                        Fax = "2598741",
                        Email = "client2srl@client2srl.com",
                        Web = "www.client2srl.com",
                        IsActive = true
                    },
                    new Client
                    {
                        Id = 3,
                        BusinessName = "Client3 SRL",
                        RucNum = 123456,
                        Address = "9 de Julio 1324",
                        Country = "Argentina",
                        City = "Rosario",
                        PostalCode = 2000,
                        Phone = "3145788845",
                        Fax = "2598741",
                        Email = "client3srl@client3srl.com",
                        Web = "www.client3srl.com",
                        IsActive = true
                    },
                    new Client
                    {
                        Id = 4,
                        BusinessName = "Client4 SRL",
                        RucNum = 123456,
                        Address = "9 de Julio 1324",
                        Country = "Argentina",
                        City = "Rosario",
                        PostalCode = 2000,
                        Phone = "3145788845",
                        Fax = "2598741",
                        Email = "client4srl@client4srl.com",
                        Web = "www.client4srl.com",
                        IsActive = true
                    },
                    new Client
                    {
                        Id = 5,
                        BusinessName = "Client5 SRL",
                        RucNum = 123456,
                        Address = "9 de Julio 1324",
                        Country = "Argentina",
                        City = "Rosario",
                        PostalCode = 2000,
                        Phone = "3145788845",
                        Fax = "2598741",
                        Email = "client5srl@client5srl.com",
                        Web = "www.client5srl.com",
                        IsActive = true
                    });
        }
    }
}
