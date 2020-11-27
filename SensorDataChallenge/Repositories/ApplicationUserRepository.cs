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

        public async Task<ApplicationUser> EditMethod(string id)
        {
            var currentUser = await _entities.Include(x => x.Permission).FirstOrDefaultAsync(x => x.Id == id);
            return currentUser;
        }

        public async Task UpdateUser(ApplicationUser currentUser)
        {
            _context.Entry(currentUser).Property(x => x.UserName).IsModified = true;
            _context.Entry(currentUser).Property(x => x.Description).IsModified = true;
            //_context.Entry(currentUser).Property(x => x.Permission.).IsModified = true;
            _context.Entry(currentUser).Property(x => x.Email).IsModified = true;
            _context.Entry(currentUser).Property(x => x.ClientId).IsModified = true;
            await _context.SaveChangesAsync();
        }
    }
}
