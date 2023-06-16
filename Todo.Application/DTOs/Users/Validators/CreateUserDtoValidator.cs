using FluentValidation;

namespace Todo.Application.DTOs.Users.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator() 
        {
            Include(new IUserDtoValidator());
        }
    }
}
