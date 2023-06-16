using AutoMapper;
using MediatR;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Todo.Application.Contracts.Persistence;
using Todo.Application.DTOs.Users.Validators;
using Todo.Application.Features.User.Requests.Commands;
using Todo.Application.Responses;
using Todo.Domain.Entites;

namespace Todo.Application.Features.User.Handlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseCommandResponse>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (request.CreateUser != null)
            {
                var response = new BaseCommandResponse();
                var validator = new CreateUserDtoValidator();
                var validatorResult = await validator.ValidateAsync(request.CreateUser);
                if (!validatorResult.IsValid)
                {
                    response.Success = false;
                    response.Message = "Creation Faild";
                    response.Errors = validatorResult.Errors.Select(i => i.ErrorMessage).ToList();
                    return response;
                }
                else
                {
                    var user = mapper.Map<Users>(request.CreateUser);
                    user = await userRepository.Add(user);
                    response.Success = true;
                    response.Message = "Createion Success";
                    response.Id = user.Id;
                    return response;
                }
            }
            else
                return new BaseCommandResponse() { Success = false, Message = "User is Empty" };
        }
    }
}
