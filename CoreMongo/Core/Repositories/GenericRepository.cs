using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ConjugonApi.Data;
using ConjugonApi.Models.Domain.Player;

namespace ConjugonApi.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TennisDbContext _context;
        protected DbSet<T> _dbSet;

        public GenericRepository(TennisDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<bool> Add(T entity)
        {
            EntityEntry sdf =  _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> AddAll(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> Delete(T entity)
        {
            _dbSet.Remove(entity);

            await _context.SaveChangesAsync();

            return true;

        }

        public virtual async Task<bool> DeleteAll(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            
            await _context.SaveChangesAsync();

            return true;
        }

        public virtual async Task<IEnumerable<T>> Get()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual T? GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public virtual bool Update(T entity)
        {
            _context.Update(entity);
            return true;
        }
    }
}
