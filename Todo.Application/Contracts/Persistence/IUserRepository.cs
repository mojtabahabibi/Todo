using System.Threading.Tasks;
using Todo.Domain.Entites;

namespace Todo.Application.Contracts.Persistence
{
    public interface IUserRepository : IGenericRepository<Users>
    {
    }
}
