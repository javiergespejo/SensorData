using System;

namespace SensorDataChallenge.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        public void SaveChangesAsync();

        // Add Interfaces
        IClientRepository ClientRepository { get; }
        IApplicationUserRepository ApplicationUserRepository { get; }
        IAccountRepository AccountRepository { get; }
    }
}
