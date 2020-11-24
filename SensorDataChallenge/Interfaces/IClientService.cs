using SensorDataChallenge.DTOs;
using SensorDataChallenge.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SensorDataChallenge.Interfaces
{
    public interface IClientService
    {
        public Task<IEnumerable<ClientDTO>> GetAllClients();
        public Task<Client> GetClientById(int id);
        public Client EntityDTOToEntity(ClientDTO clientDto);
        public ClientDTO EntityToEntityDTO(Client client);
        public Task<bool> ClientExist(Client client);
        public Task AddAndSave(Client client);
        public Task UpdateAndSave(Client client);
        public Task SoftDeleteAndSave(int id);

    }
}
