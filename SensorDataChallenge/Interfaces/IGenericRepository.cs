using SensorDataChallenge.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SensorDataChallenge.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void DeleteAsync(int id);
    }
}
