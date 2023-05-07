using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext context;
        private IUserRepository userRepository;
        public RepositoryManager(RepositoryContext context)
        {
            this.context = context;
        }

        public IUserRepository User
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(context);
                }
                return userRepository;
            }
        }
        public async Task SaveAsync() => await context.SaveChangesAsync();
    }
}
