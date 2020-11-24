using System;
using System.Threading.Tasks;

namespace SensorDataChallenge.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        public Task SaveChangesAsync();

        // Add Interfaces
        IClientRepository ClientRepository { get; }
        IApplicationUserRepository ApplicationUserRepository { get; }
        IAccountRepository AccountRepository { get; }
    }
}
