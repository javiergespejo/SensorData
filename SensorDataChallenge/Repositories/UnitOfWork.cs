using SensorDataChallenge.Data;
using SensorDataChallenge.Interfaces;
using System.Threading.Tasks;

namespace SensorDataChallenge.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        // DbContext
        private readonly SensorDataDbContext _context;

        // Add Repositories
        private ClientRepository _clientRepository;
        private ApplicationUserRepository _applicationUserRepository;
        private AccountRepository _accountRepository;


        public UnitOfWork(SensorDataDbContext context)
        {
            _context = context;
        }

        // Add Interfaces
        public IClientRepository ClientRepository
        {
            get
            {
                if (_clientRepository == null)
                {
                    _clientRepository = new ClientRepository(_context);
                    return _clientRepository;
                }
                return _clientRepository;
            }
        }

        public IApplicationUserRepository ApplicationUserRepository
        {
            get
            {
                if (_applicationUserRepository == null)
                {
                    _applicationUserRepository = new ApplicationUserRepository(_context);
                }
                return _applicationUserRepository;
            }
        }

        public IAccountRepository AccountRepository
        {
            get
            {
                if (_accountRepository == null)
                {
                    _accountRepository = new AccountRepository(_context);
                }
                return _accountRepository;
            }
        }               

        public async Task SaveChangesAsync()
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
