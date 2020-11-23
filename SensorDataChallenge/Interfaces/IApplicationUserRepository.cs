using SensorDataChallenge.Models;
using System.Threading.Tasks;

namespace SensorDataChallenge.Interfaces
{
    public interface IApplicationUserRepository : IGenericRepository<ApplicationUser>
    {
        public Task<bool> UserExist(ApplicationUser user);
    }
}
