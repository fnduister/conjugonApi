using ConjugonApi.Core.Interfaces;
using ConjugonApi.Data;
using ConjugonApi.Models.Domain.User;

namespace ConjugonApi.Core.Repositories
{
    public class UserRepository : GenericRepository<UserModel>, IUserRepository
    {
        public UserRepository(TennisDbContext context) : base(context){}

    }
}
