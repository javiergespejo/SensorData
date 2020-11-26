using SensorDataChallenge.Models;
using System.Threading.Tasks;

namespace SensorDataChallenge.Interfaces
{
    public interface IClientRepository: IGenericRepository<Client>
    {
        public Task SoftDelete(int id);
        public Task<bool> ClientExist(Client client);
        public Task<Client> GetClientByIdAsync(int id);

    }
}
