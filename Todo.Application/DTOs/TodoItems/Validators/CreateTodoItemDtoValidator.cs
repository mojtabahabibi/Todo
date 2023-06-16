using FluentValidation;
using Todo.Application.Contracts.Persistence;

namespace Todo.Application.DTOs.TodoItems.Validators
{
    public class CreateTodoItemDtoValidator : AbstractValidator<CreateTodoItemDto>
    {
        private readonly IUserRepository userRepository;

        public CreateTodoItemDtoValidator(IUserRepository userRepository)
        {
            this.userRepository = userRepository;

            Include(new ITodoItemDtoValidator(userRepository));
        }
    }
}
