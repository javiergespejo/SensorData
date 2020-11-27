using SensorDataChallenge.DTOs;
using SensorDataChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorDataChallenge.Interfaces
{
    public interface IAccountRepository : IGenericRepository<ApplicationUser>
    {
        public Task<List<Permission>> GetPermissions();
        public Task<List<Permission>> Permissions(RegisterDTO model);
        public IEnumerable<Client> GetClients();
    }
}
