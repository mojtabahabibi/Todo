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
    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, BaseCommandResponse>
    {
        private readonly ITodoItemRepository todoItemRepository;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public CreateTodoItemCommandHandler(ITodoItemRepository todoItemRepository,IUserRepository userRepository, IMapper mapper)
        {
            this.todoItemRepository = todoItemRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        async Task<BaseCommandResponse> IRequestHandler<CreateTodoItemCommand, BaseCommandResponse>.Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            if (request.CreateTodoItem != null)
            {
                var response = new BaseCommandResponse();
                var validator = new CreateTodoItemDtoValidator(userRepository);
                var validatorResult = await validator.ValidateAsync(request.CreateTodoItem);
                if (!validatorResult.IsValid)
                {
                    response.Success = false;
                    response.Message = "Creation Faild";
                    response.Errors = validatorResult.Errors.Select(i => i.ErrorMessage).ToList();
                    return response;
                }
                else
                {
                    var todoItem = mapper.Map<Domain.Entites.TodoItem>(request.CreateTodoItem);
                    todoItem = await todoItemRepository.Add(todoItem);
                    response.Success = true;
                    response.Message = "Createion Success";
                    response.Id = todoItem.Id;
                    return response;
                }
            }
            else
                return new BaseCommandResponse();
        }
    }
}
