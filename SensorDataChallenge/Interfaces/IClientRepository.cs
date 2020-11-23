using SensorDataChallenge.Models;
using System.Threading.Tasks;

namespace SensorDataChallenge.Interfaces
{
    public interface IClientRepository: IGenericRepository<Client>
    {
        public void SoftDelete(Client client);
        public Task<bool> ClientExist(Client client);
    }
}
