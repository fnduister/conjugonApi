

namespace ConjugonApi.Core
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> Add(T entity);

        Task<bool> AddAll(IEnumerable<T> entities);

        Task<bool> Delete(T entity);

        Task<bool> DeleteAll(IEnumerable<T> entities);

        Task<IEnumerable<T>> Get();

        T? GetById(Guid id);

        bool Update(T entity);
    }
}
