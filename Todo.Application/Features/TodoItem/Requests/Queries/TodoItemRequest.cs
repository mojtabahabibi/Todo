using MediatR;
using Todo.Application.DTOs.TodoItems;

namespace Todo.Application.Features.TodoItem.Requests.Queries
{
    public class TodoItemRequest : IRequest<TodoItemShowDto>
    {
        public int Id { get; set; }
    }
}
