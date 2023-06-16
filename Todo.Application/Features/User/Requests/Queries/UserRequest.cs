using MediatR;
using Todo.Application.DTOs.Users;

namespace Todo.Application.Features.User.Requests.Queries
{
    public class UserRequest : IRequest<UserDto>
    {
        public int Id { get; set; }
    }
}
