using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SensorDataChallenge.DTOs;
using SensorDataChallenge.Interfaces;
using System;
using System.Threading.Tasks;

namespace SensorDataChallenge.Controllers
{
    public class ApplicationUsersController : Controller
    {
        private readonly IApplicationUserService _applicationUserService;
        public ApplicationUsersController(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }

        // GET: ApplicationUsers
        public async Task<IActionResult> Index()
        {
            var usersDto = await _applicationUserService.GetAllUsers();
            return View(usersDto);
        }

        // GET: ApplicationUsers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var user = await _applicationUserService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            var userDto = _applicationUserService.EntityToEntityPublicViewDTO(user);
            return View(userDto);
        }

        // GET: ApplicationUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUsers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationUserDTO userDto)
        {
            var user = _applicationUserService.EntityDTOToEntity(userDto);
            var userExist = await _applicationUserService.UserExist(user);
            if (userExist)
            {
                return Conflict($"El usuario {userDto.UserName} ya existe.");
            }

            try
            {
                await _applicationUserService.AddAndSave(user);
                return RedirectToAction(nameof(Index));
                //return CreatedAtAction("PostUser", userDto);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: ApplicationUsers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _applicationUserService.GetUserById(id);
            var userDto = _applicationUserService.EntityToEntityEditDTO(user);
            return View(userDto);
        }

        // POST: ApplicationUsers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ApplicationUserEditDTO userDto)
        {
            if (id != userDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var currentUser = await _applicationUserService.GetUserById(id);
                    var user = _applicationUserService.EntityEditDTOToEntity(userDto);
                    await _applicationUserService.UpdateAndSave(user);
                }
                catch (DbUpdateConcurrencyException ex)
                {

                    return BadRequest(ex.Message);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        //GET: ApplicationUsers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _applicationUserService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            var userDto = _applicationUserService.EntityToEntityPublicViewDTO(user);

            return View(userDto);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _applicationUserService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            try
            {
                await _applicationUserService.DeleteAndSave(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
