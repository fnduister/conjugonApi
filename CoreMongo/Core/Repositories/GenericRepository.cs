using ConjugonApi.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MongoDB.Bson;
using System.Linq.Expressions;

namespace ConjugonApi.Core
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ConjugonDbContext _context;
        protected DbSet<T> _dbSet;

        public GenericRepository(ConjugonDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<bool> Add(T entity)
        {
            _dbSet.Add(entity);
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

        public async Task<List<T>> Find(Expression<Func<T, bool>> predicate, int size = 1)
        {
            return await _dbSet.Where(predicate).Take(size).ToListAsync();
        }

        public virtual async Task<List<T>> Get(int size = 1)
        {
            return await _dbSet.Take(size).ToListAsync();
        }

        public virtual T? GetById(ObjectId id)
        {
            return _dbSet.Find(id);
        }

        public virtual bool Update(T entity)
        {
            // TODO: maybe use this?
            //var planet = db.Planets.FirstOrDefault(p => p.name == "Mercury");
            //planet.name = "Mercury the first planet";
            //db.SaveChanges();

            _context.Update(entity);
            return true;
        }
    }
}
