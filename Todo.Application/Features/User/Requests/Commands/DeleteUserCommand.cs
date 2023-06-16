using MediatR;
using Todo.Application.Responses;

namespace Todo.Application.Features.User.Requests.Commands
{
    public class DeleteUserCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
