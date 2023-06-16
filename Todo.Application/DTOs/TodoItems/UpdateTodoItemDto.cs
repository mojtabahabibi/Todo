using Todo.Domain.Enums;

namespace Todo.Application.DTOs.TodoItems
{
    public class UpdateTodoItemDto : TodoItemDto
    {
        public new StatusLevel Status { get; set; } 
    }
}
