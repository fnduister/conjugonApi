using MongoDB.Bson;
using System.Linq.Expressions;

namespace ConjugonApi.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> Add(T entity);

        Task<bool> AddAll(IEnumerable<T> entities);

        Task<bool> Delete(T entity);

        Task<bool> DeleteAll(IEnumerable<T> entities);

        Task<List<T>> Get(int size = 1);

        T? GetById(ObjectId id);

        Task<List<T>> Find(Expression<Func<T, bool>> predicate, int size = 1);

        bool Update(T entity);
    }
}
