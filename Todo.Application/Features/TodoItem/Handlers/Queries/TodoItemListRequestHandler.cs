using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todo.Application.Contracts.Persistence;
using Todo.Application.DTOs.TodoItems;
using Todo.Application.Features.TodoItem.Requests.Queries;

namespace Todo.Application.Features.TodoItem.Handlers.Queries
{
    public class TodoItemListRequestHandler : IRequestHandler<TodoItemListRequest, List<TodoItemShowDto>>
    {
        private readonly ITodoItemRepository todoItemRepository;
        private readonly IMapper mapper;

        public TodoItemListRequestHandler(ITodoItemRepository todoItemRepository,IMapper mapper)
        {
            this.todoItemRepository = todoItemRepository;
            this.mapper = mapper;
        }
        public async Task<List<TodoItemShowDto>> Handle(TodoItemListRequest request, CancellationToken cancellationToken)
        {
            var todoItems = await todoItemRepository.GetAll();
            return mapper.Map<List<TodoItemShowDto>>(todoItems);
        }
    }
}
