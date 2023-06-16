using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Todo.Application.Contracts.Persistence;
using Todo.Application.DTOs.TodoItems.Validators;
using Todo.Application.Features.TodoItem.Requests.Commands;
using Todo.Application.Responses;

namespace Todo.Application.Features.TodoItem.Handlers.Commands
{
    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand, BaseCommandResponse>
    {
        private readonly ITodoItemRepository todoItemRepository;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UpdateTodoItemCommandHandler(ITodoItemRepository todoItemRepository, IUserRepository userRepository, IMapper mapper)
        {
            this.todoItemRepository = todoItemRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        async Task<BaseCommandResponse> IRequestHandler<UpdateTodoItemCommand, BaseCommandResponse>.Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            if (request.UpdateTodoItem != null)
            {
                var response = new BaseCommandResponse();
                var validator = new UpdateTodoItemDtoValidator(userRepository);
                var validatorResult = await validator.ValidateAsync(request.UpdateTodoItem);
                if (!validatorResult.IsValid)
                {
                    response.Success = false;
                    response.Message = "Updated Faild";
                    response.Errors = validatorResult.Errors.Select(i => i.ErrorMessage).ToList();
                    return response;
                }
                else
                {
                    var todoItem = mapper.Map<Domain.Entites.TodoItem>(request.UpdateTodoItem);
                    await todoItemRepository.Update(todoItem);
                    response.Success = true;
                    response.Message = "Updated Success";
                    return response;
                }
            }
            else
                return new BaseCommandResponse();
        }
    }
}
