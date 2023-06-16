using MediatR;
using Todo.Application.DTOs.TodoItems;
using Todo.Application.Responses;

namespace Todo.Application.Features.TodoItem.Requests.Commands
{
    public class UpdateTodoItemCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
        public UpdateTodoItemDto? UpdateTodoItem { get; set; }
    }
}
