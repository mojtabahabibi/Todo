using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todo.Application.Contracts.Persistence;
using Todo.Application.DTOs.Users;
using Todo.Application.Features.User.Requests.Queries;

namespace Todo.Application.Features.User.Handlers.Queries
{
    public class UserListRequestHandler : IRequestHandler<UserListRequest, List<UserDto>>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserListRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        public async Task<List<UserDto>> Handle(UserListRequest request, CancellationToken cancellationToken)
        {
            var users = await userRepository.GetAll();
            if (users != null)
                return mapper.Map<List<UserDto>>(users);
            else
                return new List<UserDto>();
        }
    }
}
