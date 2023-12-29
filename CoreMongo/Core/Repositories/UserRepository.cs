using ConjugonApi.Core.Interfaces;
using ConjugonApi.Models;

namespace ConjugonApi.Core.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(ConjugonDbContext context) : base(context){}
    }
}
