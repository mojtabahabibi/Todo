using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Todo.Application.Contracts.Persistence;
using Todo.Application.Features.User.Requests.Commands;
using Todo.Application.Responses;

namespace Todo.Application.Features.User.Handlers.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand,BaseCommandResponse>
    {
        private readonly IUserRepository userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository )
        {
            this.userRepository = userRepository;
        }
        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetById(request.Id);
            if (user != null) 
            {
                await userRepository.Delete(user);
            }
        }

        async Task<BaseCommandResponse> IRequestHandler<DeleteUserCommand, BaseCommandResponse>.Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            if (request.Id != 0)
            {
                var response = new BaseCommandResponse();
                var user = await userRepository.GetById(request.Id);
                if (user != null)
                {
                    await userRepository.Delete(user);
                    response.Success = true;
                    response.Message = "Deleted Success";
                    return response;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Deleted Faild";
                    return response;
                }
            }
            else
                return new BaseCommandResponse() { Success = false, Message = "User NotFound" };
        }
    }
}
