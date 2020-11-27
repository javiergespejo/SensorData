using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SensorDataChallenge.Data;
using SensorDataChallenge.DTOs;
using SensorDataChallenge.Enums;
using SensorDataChallenge.Filters;
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
        [Authorize(PermissionEnum.ViewUsers)]
        public async Task<IActionResult> Index()
        {
            var usersDto = await _applicationUserService.GetAllUsers();
            return View(usersDto);
        }

        // GET: ApplicationUsers/Details/5
        [Authorize(PermissionEnum.ViewUsers)]
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

        // GET: ApplicationUsers/Edit/5
        [Authorize(PermissionEnum.UpdateUser)]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _applicationUserService.GetUserById(id);
            var registerDto = _applicationUserService.EntityToRegisterDTO(user);
            var permissions = await _applicationUserService.GetPermissions();
            ViewBag.Permissions = new MultiSelectList(permissions, "Id", "Description"); var clients = _applicationUserService.GetClients();
            ViewData["ClientId"] = new SelectList(clients, "Id", "BusinessName");

            return View(registerDto);
        }

        // POST: ApplicationUsers/Edit/5
        [Authorize(PermissionEnum.UpdateUser)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, RegisterDTO registerDto)
        {
            registerDto.Permission = await _applicationUserService.Permissions(registerDto);

            if (id != registerDto.Id)
            {
                return NotFound();
            }

            try
            {
                await _applicationUserService.UpdateClient(id, registerDto);
            }
            catch (DbUpdateConcurrencyException ex)
            {

                return BadRequest(ex.Message);
            }
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index", _applicationUserService.GetAllUsers()) });

            //return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", registerDto) });
        }

        // POST: ApplicationUsers/Delete/5
        [Authorize(PermissionEnum.DeleteUser)]
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
                await _applicationUserService.DeleteAndSave(id);
                return Json(new { html = Helper.RenderRazorViewToString(this, "Index", _applicationUserService.GetAllUsers()) });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
