using MediatR;
using Todo.Application.DTOs.TodoItems;
using Todo.Application.Responses;

namespace Todo.Application.Features.TodoItem.Requests.Commands
{
    public class CreateTodoItemCommand : IRequest<BaseCommandResponse>
    {
        public CreateTodoItemDto? CreateTodoItem { get; set; }
    }
}

