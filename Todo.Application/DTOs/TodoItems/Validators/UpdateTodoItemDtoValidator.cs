using FluentValidation;
using Todo.Application.Contracts.Persistence;

namespace Todo.Application.DTOs.TodoItems.Validators
{
    public class UpdateTodoItemDtoValidator : AbstractValidator<UpdateTodoItemDto>
    {
        private readonly IUserRepository userRepository;

        public UpdateTodoItemDtoValidator(IUserRepository userRepository)
        {
            this.userRepository = userRepository;

            Include(new ITodoItemDtoValidator(userRepository));
        }
    }
}
