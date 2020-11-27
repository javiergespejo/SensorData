using SensorDataChallenge.Models;
using System.Threading.Tasks;

namespace SensorDataChallenge.Interfaces
{
    public interface IApplicationUserRepository : IGenericRepository<ApplicationUser>
    {
        public Task<bool> UserExist(ApplicationUser user);
        public Task<ApplicationUser> EditMethod(string id);
        public Task UpdateUser(ApplicationUser currentUser);
    }
}
