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
        public async Task<IActionResult> Details(string id)
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
            return View(new ApplicationUserDTO());
        }

        // POST: ApplicationUsers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationUserDTO userDto)
        {
            if (ModelState.IsValid)
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
                }
                catch (DbUpdateException ex)
                {
                    return BadRequest(ex);
                }                                                                          /*CAMBIAR EL REDIRECT*/
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index", _applicationUserService.GetAllUsers()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Create", userDto) });
        }

        // GET: ApplicationUsers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _applicationUserService.GetUserById(id);
            var userDto = _applicationUserService.EntityToEntityEditDTO(user);
            return View(userDto);
        }

        // POST: ApplicationUsers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ApplicationUserEditDTO userDto)
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
                }                                                                          /*CAMBIAR EL REDIRECT*/
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index", _applicationUserService.GetAllUsers()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Create", userDto) });
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _applicationUserService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            try
            {
                await _applicationUserService.DeleteAndSave(id);              /*CAMBIAR EL REDIRECT*/
                return Json(new { html = Helper.RenderRazorViewToString(this, "Index", _applicationUserService.GetAllUsers()) });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
