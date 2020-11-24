using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var usersDto = await _applicationUserService.GetAllUsers();
            return View(usersDto);
        }

        [HttpGet("{id}")]
        [Route("DetailUser")]
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

        [HttpPost]
        [Route("CreateUser")]
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
                _applicationUserService.AddAndSave(user);
                return CreatedAtAction("PostUser", userDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        [Route("EditUser")]
        public async Task<IActionResult> Edit(int id, ApplicationUserDTO userDto)
        {
            var currentUser = await _applicationUserService.GetUserById(id);
            if (currentUser == null)
            {
                return NotFound();
            }
            var userUpdate = _applicationUserService.EntityDTOToEntity(userDto);
            userUpdate.Id = id;

            var usertExist = await _applicationUserService.UserExist(currentUser);
            if (!usertExist)
            {
                return NotFound();
            }

            try
            {
                _applicationUserService.UpdateAndSave(userUpdate);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpDelete("{id}")]
        [Route("DeleteUser")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _applicationUserService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            try
            {
                _applicationUserService.DeleteAndSave(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
