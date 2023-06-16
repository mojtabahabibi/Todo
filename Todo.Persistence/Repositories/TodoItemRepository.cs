using Todo.Application.Contracts.Persistence;
using Todo.Domain.Entites;

namespace Todo.Persistence.Repositories
{
    public class TodoItemRepository : GenericRepository<TodoItem>, ITodoItemRepository
    {
        private readonly ApplicationDbContext context;

        public TodoItemRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
