using Todo.Domain.Enums;

namespace Todo.Application.DTOs.TodoItems
{
    public class CreateTodoItemDto : TodoItemDto
    {
        private readonly StatusLevel status = 0;
        public new StatusLevel Status { get { return status; } }
    }
}
