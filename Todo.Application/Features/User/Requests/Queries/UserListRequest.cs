using MediatR;
using System.Collections.Generic;
using Todo.Application.DTOs.Users;

namespace Todo.Application.Features.User.Requests.Queries
{
    public class UserListRequest : IRequest<List<UserDto>>
    {
    }
}
