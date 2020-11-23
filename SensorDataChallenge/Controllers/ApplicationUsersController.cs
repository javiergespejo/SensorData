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
            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> UserId(int id)
        {
            var user = await _applicationUserService.GetUserById(id);
            var userDto = _applicationUserService.EntityDTOToEntity(user);
            if (userDto == null)
            {
                return NotFound();
            }
            return Ok(userDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostUser(ApplicationUserDTO userDto)
        {
            var user = _applicationUserService.EntityToEntityDTO(userDto);
            var userExist = await _applicationUserService.UserExist(user);
            if (userExist)
            {
                return BadRequest();
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

        [HttpPut]
        public async Task<IActionResult> PutUser(int id, ApplicationUserDTO userDto)
        {
            var currentUser = await _applicationUserService.GetUserById(id);
            var userUpdate = _applicationUserService.EntityToEntityDTO(userDto);
            userUpdate.Id = id;

            var usertExist = await _applicationUserService.UserExist(currentUser);
            if (!usertExist)
            {
                return NotFound();
            }

            try
            {
                _applicationUserService.UpdateAndSave(userUpdate);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
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
