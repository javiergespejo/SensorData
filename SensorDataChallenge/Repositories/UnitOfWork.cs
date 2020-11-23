using SensorDataChallenge.Data;
using SensorDataChallenge.Interfaces;

namespace SensorDataChallenge.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        // DbContext
        private readonly SensorDataDbContext _context;

        // Add Repositories
        private readonly ClientRepository _clientRepository;
        private readonly ApplicationUserRepository _applicationUserRepository;


        public UnitOfWork(SensorDataDbContext context)
        {
            _context = context;
        }

        // Add Interfaces
        public IClientRepository ClientRepository => _clientRepository ?? new ClientRepository(_context);
        public IApplicationUserRepository ApplicationUserRepository => _applicationUserRepository ?? new ApplicationUserRepository(_context); 

        public async void SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async void Dispose()
        {
            if (_context != null)
            {
                await _context.DisposeAsync();
            }
        }
    }
}
