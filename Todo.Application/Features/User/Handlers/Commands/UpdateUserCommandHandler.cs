using AutoMapper;
using MediatR;
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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, BaseCommandResponse>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
      
        async Task<BaseCommandResponse> IRequestHandler<UpdateUserCommand, BaseCommandResponse>.Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (request.UpdateUser != null)
            {
                var response = new BaseCommandResponse();
                var validator = new UpdateUserDtoValidator();
                var validatorResult = await validator.ValidateAsync(request.UpdateUser);
                if (!validatorResult.IsValid)
                {
                    response.Success = false;
                    response.Message = "Updated Faild";
                    response.Errors = validatorResult.Errors.Select(i => i.ErrorMessage).ToList();
                    return response;
                }
                else
                {
                    var user = mapper.Map<Users>(request.UpdateUser);
                    await userRepository.Update(user);
                    response.Success = true;
                    response.Message = "Updated Success";
                    return response;
                }
            }
            else
                return new BaseCommandResponse() { Success = false, Message = "User is Empty" };
        }
    }
}
