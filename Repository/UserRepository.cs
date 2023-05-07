using Contracts;
using Entities;
using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<User> Login(string login, string password, bool tracking, CancellationToken cancellation = default)
            => await FindByCondition(x=>x.Login.Equals(login) && x.Password.Equals(password),tracking)
            .SingleOrDefaultAsync(cancellation);
    }
}
