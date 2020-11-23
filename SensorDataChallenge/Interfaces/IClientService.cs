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
        public ClientDTO EntityDTOToEntity(Client client);
        public Client EntityToEntityDTO(ClientDTO clientDto);
        public Task<bool> ClientExist(Client client);
        public void AddAndSave(Client client);
        public void UpdateAndSave(Client client);
        public void SoftDeleteAndSave(Client client);

    }
}
