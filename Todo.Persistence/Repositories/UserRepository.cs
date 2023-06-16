using Todo.Application.Contracts.Persistence;
using Todo.Domain.Entites;

namespace Todo.Persistence.Repositories
{
    public class UserRepository : GenericRepository<Users>, IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
