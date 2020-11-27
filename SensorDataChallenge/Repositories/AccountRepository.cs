using Microsoft.EntityFrameworkCore;
using SensorDataChallenge.Data;
using SensorDataChallenge.DTOs;
using SensorDataChallenge.Interfaces;
using SensorDataChallenge.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorDataChallenge.Repositories
{
    public class AccountRepository : GenericRepository<ApplicationUser>, IAccountRepository
    {
        public AccountRepository(SensorDataDbContext context) : base(context)
        {
        }

        public async Task<List<Permission>> GetPermissions()
        {
            var permissions = await _context.Permission.ToListAsync();
            return permissions;
        }

        public async Task<List<Permission>> Permissions(RegisterDTO model)
        {
            var permissions = await _context.Permission.Where(x => model.PermissionsId.Contains(x.Id)).ToListAsync();
            return permissions;
        }

        public IEnumerable<Client> GetClients()
        {            
            var clients = _context.Client.Where(c => c.IsActive == true).AsEnumerable();
            return clients;
        }
    }
}
