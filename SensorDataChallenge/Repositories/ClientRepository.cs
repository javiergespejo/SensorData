using Microsoft.EntityFrameworkCore;
using SensorDataChallenge.Data;
using SensorDataChallenge.Interfaces;
using SensorDataChallenge.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorDataChallenge.Repositories
{
    public class ClientRepository: GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(SensorDataDbContext context) : base(context)
        {
        }

        public async Task SoftDelete(int id)
        {
            var client = await _entities.FindAsync(id);
            client.IsActive = false;
        }

        public async Task<bool> ClientExist(Client client)
        {
            return await _entities.AnyAsync(x => x.Email == client.Email);
        }

        public override async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _entities.Where(c => c.IsActive == true).ToListAsync();
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _entities.AsNoTracking().Where(c => c.IsActive == true && c.Id == id).FirstOrDefaultAsync();
        }
    }
}
