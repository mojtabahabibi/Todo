using FluentValidation;

namespace Todo.Application.DTOs.Users.Validators
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            Include(new IUserDtoValidator());
            RuleFor(i => i.Id).NotNull().WithMessage("{PropertyName} is required");
        }
    }
}
