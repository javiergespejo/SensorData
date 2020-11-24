using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Index()
        {
            var clientsDto = await _clientService.GetAllClients();
            return View(clientsDto);
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int id)
        {            
            var client = await _clientService.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }
            var clientDto = _clientService.EntityToEntityDTO(client);
            return View(clientDto);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientDTO clientDto)
        {
            var client = _clientService.EntityDTOToEntity(clientDto);
            var clientExist = await _clientService.ClientExist(client);
            if (clientExist)
            {
                return Conflict($"El cliente {clientDto.BusinessName} ya existe.");
            }

            try
            {
                await _clientService.AddAndSave(client);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var client = await _clientService.GetClientById(id);
            var clientDto = _clientService.EntityToEntityDTO(client);
            return View(clientDto);
        }

        // PUT: Clients/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClientDTO clientDto)
        {
            if (id != clientDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var currentClient = await _clientService.GetClientById(id);
                    var client = _clientService.EntityDTOToEntity(clientDto);
                    client.IsActive = true;
                    await _clientService.UpdateAndSave(client);
                }
                catch (DbUpdateConcurrencyException ex)
                {

                    return BadRequest(ex.Message);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var client = await _clientService.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }

            var clientDto = _clientService.EntityToEntityDTO(client);

            return View(clientDto);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var client = await _clientService.GetClientById(id);
            //if (client == null)
            //{
            //    return NotFound();
            //}
            try
            {
                await _clientService.SoftDeleteAndSave(id);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
