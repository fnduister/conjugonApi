using ConjugonApi.Core.Repositories;

namespace ConjugonApi.Core
{
    public interface IUnitOfWork
    {
        PlayerRepository PlayerRepo { get; }
        public Task CompleteAsync();
        public void Dispose(); 
    }
}
