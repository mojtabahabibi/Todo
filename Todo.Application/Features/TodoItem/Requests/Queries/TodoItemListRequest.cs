using MediatR;
using System.Collections.Generic;
using Todo.Application.DTOs.TodoItems;

namespace Todo.Application.Features.TodoItem.Requests.Queries
{
    public class TodoItemListRequest : IRequest<List<TodoItemShowDto>>
    {
    }
}
