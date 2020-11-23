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
            var client = await _unitOfWork.ClientRepository.GetByIdAsync(id);
            return client;
        }

        public Client EntityToEntityDTO(ClientDTO clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            return client;
        }

        public ClientDTO EntityDTOToEntity(Client client)
        {
            var clientDto = _mapper.Map<ClientDTO>(client);
            return clientDto;
        }

        public async Task<bool> ClientExist(Client client)
        {
            var clientExist = await _unitOfWork.ClientRepository.ClientExist(client);
            return clientExist;
        }

        public void AddAndSave(Client client)
        {
            _unitOfWork.ClientRepository.Add(client);
            _unitOfWork.SaveChangesAsync();
        }

        public void UpdateAndSave(Client client)
        {
            _unitOfWork.ClientRepository.Update(client);
            _unitOfWork.SaveChangesAsync();
        }

        public void SoftDeleteAndSave(Client client)
        {
            _unitOfWork.ClientRepository.SoftDelete(client);
            _unitOfWork.SaveChangesAsync();
        }
    }
}
