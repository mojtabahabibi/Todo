using AutoMapper;
using Moq;
using Shouldly;
using Todo.Application.Contracts.Persistence;
using Todo.Application.DTOs.Users;
using Todo.Application.Features.User.Handlers.Queries;
using Todo.Application.Features.User.Requests.Queries;
using Todo.Application.Profiles;
using Todo.Application.UnitTests.Mocks;

namespace Todo.Application.UnitTests.Users.Queries
{
    public class UserListRequestHandlerTest
    {
        IMapper mapper;
        Mock<IUserRepository> mockRepository;
        public UserListRequestHandlerTest()
        {
            mockRepository = MockUserRepository.GetUsersRepository();
            var mapperConfig = new MapperConfiguration(i => { i.AddProfile<MappingProfile>(); });
            mapper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async Task UserListTest()
        {
            var handler = new UserListRequestHandler(mockRepository.Object, mapper);
            var result = await handler.Handle(new UserListRequest(), CancellationToken.None);
            result.ShouldBeOfType<List<UserDto>>();
            result.Count().ShouldBe(2);
        }
    }
}
