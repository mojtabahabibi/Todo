using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Todo.Application.Contracts.Persistence;
using Todo.Application.DTOs.TodoItems;
using Todo.Application.Features.TodoItem.Requests.Queries;

namespace Todo.Application.Features.TodoItem.Handlers.Queries
{
    public class TodoItemRequestHandler : IRequestHandler<TodoItemRequest, TodoItemShowDto>
    {
        private readonly ITodoItemRepository todoItemRepository;
        private readonly IMapper mapper;

        public TodoItemRequestHandler(ITodoItemRepository todoItemRepository, IMapper mapper)
        {
            this.todoItemRepository = todoItemRepository;
            this.mapper = mapper;
        }
        public async Task<TodoItemShowDto> Handle(TodoItemRequest request, CancellationToken cancellationToken)
        {
            var todoItem = await todoItemRepository.GetById(request.Id);
            if (todoItem != null)
            {
                return mapper.Map<TodoItemShowDto>(todoItem);
            }
            else
                return new TodoItemShowDto();
        }
    }
}
