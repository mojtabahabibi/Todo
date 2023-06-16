using FluentValidation;
using System;
using Todo.Application.Contracts.Persistence;

namespace Todo.Application.DTOs.TodoItems.Validators
{
    public class ITodoItemDtoValidator : AbstractValidator<TodoItemDto>
    {
        private readonly IUserRepository userRepository;

        public ITodoItemDtoValidator(IUserRepository userRepository)
        {
            this.userRepository = userRepository;

            RuleFor(i => i.Title).NotNull().WithMessage("{PropertyName} is required").NotNull()
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100");
            RuleFor(i => i.Note).NotNull().WithMessage("{PropertyName} is required").NotNull()
              .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200");
            RuleFor(i => (int)i.Priority).GreaterThan(-1).LessThan(4).WithMessage("Select {PropertyName} from None,Low,Medium,High");
            RuleFor(i => i.Reminder).GreaterThanOrEqualTo(i => DateTime.Now).WithMessage("{PropertyName} must be greater than today");
            RuleFor(i => i.UserId).GreaterThan(0).MustAsync(async (id, token) =>
            {
                return await userRepository.Exist(id);
            }).WithMessage("{PropertyName} does not exist");
        }
    }
}
