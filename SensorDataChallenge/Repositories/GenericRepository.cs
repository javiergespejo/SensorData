using Microsoft.EntityFrameworkCore;
using SensorDataChallenge.Data;
using SensorDataChallenge.Interfaces;
using SensorDataChallenge.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorDataChallenge.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly SensorDataDbContext _context;
        protected readonly DbSet<TEntity> _entities;

        public GenericRepository(SensorDataDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public virtual void Add(TEntity entity)
        {
            _entities.Add(entity);
        }
        public virtual void Update(TEntity entity)
        {
            //_context.Entry(entity).State = EntityState.Detached;
            //_entities.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual async void DeleteAsync(int id)
        {
            var entity = await _entities.FindAsync(id);
            _entities.Remove(entity);
        }
    }
}
