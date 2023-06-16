using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Todo.Application.Contracts.Persistence;
using Todo.Application.Features.TodoItem.Requests.Commands;
using Todo.Application.Responses;

namespace Todo.Application.Features.TodoItem.Handlers.Commands
{
    public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand, BaseCommandResponse>
    {
        private readonly ITodoItemRepository todoItemRepository;

        public DeleteTodoItemCommandHandler(ITodoItemRepository todoItemRepository)
        {
            this.todoItemRepository = todoItemRepository;
        }
      
        async Task<BaseCommandResponse> IRequestHandler<DeleteTodoItemCommand, BaseCommandResponse>.Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            if (request.Id != 0)
            {
                var response = new BaseCommandResponse();
                var todoItem = await todoItemRepository.GetById(request.Id);
                if (todoItem != null)
                {
                    await todoItemRepository.Delete(todoItem);
                    response.Success = true;
                    response.Message = "Deleted Success";
                    return response;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Deleted Faild";
                    return response;
                }
            }
            else
                return new BaseCommandResponse();
        }
    }
}
