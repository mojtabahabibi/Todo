using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.DTOs.TodoItems;
using Todo.Application.Features.TodoItem.Requests.Commands;
using Todo.Application.Features.TodoItem.Requests.Queries;

namespace Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IMediator mediator;

        public TodoController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<TodoItemShowDto>>> Get()
        {
            var todos = await mediator.Send(new TodoItemListRequest());
            return Ok(todos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemShowDto>> Get(int id)
        {
            var todo = await mediator.Send(new TodoItemRequest() { Id = id });
            return Ok(todo);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateTodoItemDto todo)
        {
            var command = new CreateTodoItemCommand() { CreateTodoItem = todo };
            var response = await mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateTodoItemDto todo)
        {
            var command = new UpdateTodoItemCommand() { Id = id, UpdateTodoItem = todo };
            var response = await mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteTodoItemCommand() { Id = id };
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
