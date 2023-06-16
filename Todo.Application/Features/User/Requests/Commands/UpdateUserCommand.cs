using MediatR;
using Todo.Application.DTOs.Users;
using Todo.Application.Responses;

namespace Todo.Application.Features.User.Requests.Commands
{
    public class UpdateUserCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
        public UpdateUserDto? UpdateUser { get; set; }
    }
}
