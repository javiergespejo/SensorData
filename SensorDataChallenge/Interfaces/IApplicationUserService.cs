using SensorDataChallenge.DTOs;
using SensorDataChallenge.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SensorDataChallenge.Interfaces
{
    public interface IApplicationUserService
    {
        public Task<IEnumerable<ApplicationUserPublicViewDTO>> GetAllUsers();
        public ApplicationUserPublicViewDTO EntityToEntityPublicViewDTO(ApplicationUser user);
        public ApplicationUser RegisterDTOToEntity(RegisterDTO registerDto);
        public RegisterDTO EntityToRegisterDTO(ApplicationUser user);
        public Task<ApplicationUser> GetUserById(string id);
        public Task<bool> UserExist(ApplicationUser user);
        public Task AddAndSave(ApplicationUser user);
        public Task UpdateAndSave(ApplicationUser user);
        public Task DeleteAndSave(string id);
        public Task<List<Permission>> GetPermissions();
        public Task<List<Permission>> Permissions(RegisterDTO registerDto);
        public Task UpdateClient(string id, RegisterDTO registerDto);
    }
}
