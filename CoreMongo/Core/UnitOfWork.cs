using ConjugonApi.Configuration.Options;
using ConjugonApi.Core.Interfaces;
using ConjugonApi.Core.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver;

namespace ConjugonApi.Core
{
    public class DomainWork: IUnitOfWork, IDisposable
    {
        public UserRepository Users;

        public VerbRepository Verbs;

        private ConjugonDbContext _context;

        public DomainWork(IOptions<MongoSettings> mongoSettings)
        {
            var _mongoSettings = mongoSettings.Value;
            var client = new MongoClient(_mongoSettings.ConnectionString);
            _context = ConjugonDbContext.Create(client.GetDatabase(_mongoSettings.DatabaseName));

            Users = new UserRepository(_context);
            Verbs = new VerbRepository(_context);
        }

        public Task CompleteAsync()
        {
            throw new NotImplementedException();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
