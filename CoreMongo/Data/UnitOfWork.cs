using ConjugonApi.Controllers;
using ConjugonApi.Core;
using ConjugonApi.Core.Interfaces;
using ConjugonApi.Core.Repositories;

namespace ConjugonApi.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TennisDbContext _context;

        public PlayerRepository PlayerRepo { get; private set; }

        public UnitOfWork(TennisDbContext context)
        {
            _context = context;
            PlayerRepo = new PlayerRepository(context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
