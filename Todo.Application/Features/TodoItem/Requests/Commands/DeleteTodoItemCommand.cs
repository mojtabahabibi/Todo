using MediatR;
using Todo.Application.Responses;

namespace Todo.Application.Features.TodoItem.Requests.Commands
{
    public class DeleteTodoItemCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
