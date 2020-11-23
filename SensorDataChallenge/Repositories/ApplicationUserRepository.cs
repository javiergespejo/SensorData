using Microsoft.EntityFrameworkCore;
using SensorDataChallenge.Data;
using SensorDataChallenge.Interfaces;
using SensorDataChallenge.Models;
using System.Threading.Tasks;

namespace SensorDataChallenge.Repositories
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(SensorDataDbContext context) : base(context)
        {
        }

        public async Task<bool> UserExist(ApplicationUser user)
        {
            return await _entities.AnyAsync(x => x.UserName == user.UserName);
        }
    }
}
