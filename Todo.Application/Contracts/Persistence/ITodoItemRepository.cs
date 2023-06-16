using Todo.Domain.Entites;

namespace Todo.Application.Contracts.Persistence
{
    public interface ITodoItemRepository : IGenericRepository<TodoItem>
    {
    }
}
