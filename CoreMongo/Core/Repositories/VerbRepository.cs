using ConjugonApi.Core.Interfaces;
using ConjugonApi.Models;

namespace ConjugonApi.Core.Repositories
{
    public class VerbRepository : GenericRepository<Verb>
    {
        public VerbRepository(ConjugonDbContext context) : base(context){}
    }
}
