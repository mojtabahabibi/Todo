using FluentValidation;
using System;

namespace Todo.Application.DTOs.Users.Validators
{
    public class IUserDtoValidator : AbstractValidator<UserDto>
    {
        public IUserDtoValidator()
        {
            RuleFor(i => i.FirstName).NotEmpty().WithMessage("{PropertyName} is required").NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50");
            RuleFor(i => i.LastName).NotEmpty().WithMessage("{PropertyName} is required").NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50");
            RuleFor(i => i.BirthDate).NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(i=>DateTime.Now.AddYears(-150)).WithMessage("{PropertyName} is Wrong")
                .LessThan(i => DateTime.Now).WithMessage("{PropertyName} LessThan Today");
        }
    }
}
