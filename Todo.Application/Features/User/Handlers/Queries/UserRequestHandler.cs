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
    public class UserRequestHandler : IRequestHandler<UserRequest, UserDto>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        public async Task<UserDto> Handle(UserRequest request, CancellationToken cancellationToken)
        {
            if (request.Id != 0)
            {
                var user = await userRepository.GetById(request.Id);
                if (user != null)
                    return mapper.Map<UserDto>(user);
                else
                    return new UserDto();
            }
            else
                return new UserDto();
        }
    }
}
