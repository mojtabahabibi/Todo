using MediatR;
using Todo.Application.DTOs.Users;
using Todo.Application.Responses;

namespace Todo.Application.Features.User.Requests.Commands
{
    public class CreateUserCommand : IRequest<BaseCommandResponse>
    {
        public CreateUserDto? CreateUser { get; set; }
    }
}
