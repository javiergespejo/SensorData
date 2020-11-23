using SensorDataChallenge.DTOs;
using SensorDataChallenge.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SensorDataChallenge.Interfaces
{
    public interface IApplicationUserService
    {
        public Task<IEnumerable<ApplicationUserDTO>> GetAllUsers();
        public ApplicationUser EntityToEntityDTO(ApplicationUserDTO userDto);
        public ApplicationUserDTO EntityDTOToEntity(ApplicationUser user);
        public Task<ApplicationUser> GetUserById(int id);
        public Task<bool> UserExist(ApplicationUser user);
        public void AddAndSave(ApplicationUser user);
        public void UpdateAndSave(ApplicationUser user);
        public void DeleteAndSave(int id);
    }
}
