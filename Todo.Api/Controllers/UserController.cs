using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.DTOs.Users;
using Todo.Application.Features.User.Requests.Commands;
using Todo.Application.Features.User.Requests.Queries;

namespace Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> Get()
        {
            var users = await mediator.Send(new UserListRequest());
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            var user = await mediator.Send(new UserRequest() { Id = id });
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateUserDto user)
        {
            var command = new CreateUserCommand() { CreateUser = user };
            var response = await mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateUserDto user)
        {
            var command = new UpdateUserCommand() { Id = id, UpdateUser = user };
            var response = await mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand() { Id = id };
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
