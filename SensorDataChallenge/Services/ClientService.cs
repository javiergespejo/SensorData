using AutoMapper;
using SensorDataChallenge.DTOs;
using SensorDataChallenge.Interfaces;
using SensorDataChallenge.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SensorDataChallenge.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientDTO>> GetAllClients()
        {
            var clients = await _unitOfWork.ClientRepository.GetAllAsync();
            var clientsDto = _mapper.Map<List<ClientDTO>>(clients);
            return clientsDto;
        }

        public async Task<Client> GetClientById(int id)
        {
            var client = await _unitOfWork.ClientRepository.GetClientByIdAsync(id);
            return client;
        }

        public Client EntityDTOToEntity(ClientDTO clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            return client;
        }

        public ClientDTO EntityToEntityDTO(Client client)
        {
            var clientDto = _mapper.Map<ClientDTO>(client);
            return clientDto;
        }

        public async Task<bool> ClientExist(Client client)
        {
            var clientExist = await _unitOfWork.ClientRepository.ClientExist(client);
            return clientExist;
        }

        public async Task AddAndSave(Client client)
        {
            client.IsActive = true;
            _unitOfWork.ClientRepository.Add(client);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAndSave(Client client)
        {
            _unitOfWork.ClientRepository.Update(client);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task SoftDeleteAndSave(int id)
        {
            await _unitOfWork.ClientRepository.SoftDelete(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
