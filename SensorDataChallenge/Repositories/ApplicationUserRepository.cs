using Microsoft.EntityFrameworkCore;
using SensorDataChallenge.Data;
using SensorDataChallenge.Interfaces;
using SensorDataChallenge.Models;
using System.Linq;
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

        public override async Task<ApplicationUser> GetByIdAsync(string id)
        {
            var user = await _entities.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
            return user;
        }

        public override void Update(ApplicationUser user)
        {            
            _context.Entry(user).Property(u => u.Name).IsModified = true;
            _context.Entry(user).Property(u => u.Description).IsModified = true;
        }
    }
}
