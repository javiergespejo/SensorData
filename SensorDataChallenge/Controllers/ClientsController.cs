using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SensorDataChallenge.DTOs;
using SensorDataChallenge.Enums;
using SensorDataChallenge.Filters;
using SensorDataChallenge.Interfaces;
using System.Threading.Tasks;
using static SensorDataChallenge.Helper;

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
        [Authorize(PermissionEnum.ViewClients)]
        public async Task<IActionResult> Index()
        {
            var clientsDto = await _clientService.GetAllClients();
            return View(clientsDto);
        }

        // GET: Clients/Details/5
        [Authorize(PermissionEnum.ViewClients)]
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
        [Authorize(PermissionEnum.CreateClient)]
        public IActionResult Create()
        {
            return View(new ClientDTO());
        }

        // POST: Clients/Create
        [Authorize(PermissionEnum.CreateClient)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientDTO clientDto)
        {
            if (ModelState.IsValid)
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
                }
                catch (DbUpdateException ex)
                {
                    return BadRequest(ex.Message);
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _clientService.GetAllClients()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Create", clientDto) });

        }

        // GET: Clients/Edit/5
        [Authorize(PermissionEnum.UpdateClient)]
        [NoDirectAccess]
        public async Task<IActionResult> Edit(int id)
        {
            var client = await _clientService.GetClientById(id);
            var clientDto = _clientService.EntityToEntityDTO(client);
            return View(clientDto);
        }

        // POST: Clients/5
        [Authorize(PermissionEnum.UpdateClient)]
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
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _clientService.GetAllClients()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", clientDto) });
        }

        // POST: ApplicationUsers/Delete/5
        [Authorize(PermissionEnum.DeleteClient)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _clientService.SoftDeleteAndSave(id);
                return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _clientService.GetAllClients()) });
            }
            catch (DbUpdateConcurrencyException ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
