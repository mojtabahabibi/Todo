using AutoMapper;
using Moq;
using Shouldly;
using Todo.Application.Contracts.Persistence;
using Todo.Application.DTOs.Users;
using Todo.Application.Features.User.Handlers.Commands;
using Todo.Application.Features.User.Requests.Commands;
using Todo.Application.Profiles;
using Todo.Application.Responses;
using Todo.Application.UnitTests.Mocks;

namespace Todo.Application.UnitTests.Users.Commands
{
    public class CreateUserCommandHandlerTest
    {
        IMapper mapper;
        Mock<IUserRepository> mockRepository;
        Mock<IUserRepository> mockRepositoryGet;
        CreateUserDto userDto;
        public CreateUserCommandHandlerTest()
        {
            mockRepository = MockUserRepository.CreateUserRepository();
            mockRepositoryGet = MockUserRepository.GetUsersRepository();
            var mapperConfige = new MapperConfiguration(i => { i.AddProfile<MappingProfile>(); });
            mapper = mapperConfige.CreateMapper();
            userDto = new CreateUserDto() { Id = 3, FirstName = "Ali", LastName = "habibi", BirthDate = DateTime.Now, RegisterDate = DateTime.Now };
        }
        [Fact]
        public async Task CreateUser()
        {
            var handler = new CreateUserCommandHandler(mockRepository.Object, mapper);
            var result = await handler.Handle(new CreateUserCommand() { CreateUser = userDto } , CancellationToken.None);
            result.ShouldBeOfType<BaseCommandResponse>();
            var users = await mockRepository.Object.GetAll();
            users.Count.ShouldBe(3);
        }
    }
}
