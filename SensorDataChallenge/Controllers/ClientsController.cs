using Microsoft.AspNetCore.Mvc;
using SensorDataChallenge.DTOs;
using SensorDataChallenge.Interfaces;
using System;
using System.Threading.Tasks;

namespace SensorDataChallenge.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: Clients
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clientsDto = await _clientService.GetAllClients();
            return Ok(clientsDto);
        }

        // GET: Clients/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Client(int id)
        {            
            var client = await _clientService.GetClientById(id);
            var clientDto = _clientService.EntityDTOToEntity(client);
            if (clientDto == null)
            {
                return NotFound();
            }
            return Ok(clientDto);
        }

        // POST: Clients
        [HttpPost]
        public async Task<IActionResult> PostClient(ClientDTO clientDto)
        {
            var client = _clientService.EntityToEntityDTO(clientDto);
            var clientExist = await _clientService.ClientExist(client);
            if (clientExist)
            {
                return BadRequest();
            }

            try
            {
                _clientService.AddAndSave(client);
                return CreatedAtAction("PostClient", clientDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT: Clients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, ClientDTO clientDto)
        {
            var currentClient = await _clientService.GetClientById(id);
            var clientUpdate = _clientService.EntityToEntityDTO(clientDto);
            clientUpdate.Id = id;
            
            var clientExist = await _clientService.ClientExist(currentClient);
            if (!clientExist)
            {
                return NotFound();
            }

            try
            {
                _clientService.UpdateAndSave(clientUpdate);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE: Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _clientService.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }

            try
            {
                _clientService.SoftDeleteAndSave(client);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
