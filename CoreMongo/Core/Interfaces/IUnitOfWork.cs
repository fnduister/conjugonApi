using ConjugonApi.Core.Repositories;

namespace ConjugonApi.Core.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        public Task CompleteAsync();
        
        public void Dispose();
    }
}
