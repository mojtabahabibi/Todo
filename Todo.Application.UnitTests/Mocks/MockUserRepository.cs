using Moq;
using Todo.Application.Contracts.Persistence;

namespace Todo.Application.UnitTests.Mocks
{
    public static class MockUserRepository
    {
        public static Mock<IUserRepository> GetUsersRepository()
        {
            var users = new List<Domain.Entites.Users>()
            {
            new Domain.Entites.Users(){Id = 1 , FirstName = "Mojtaba" , LastName = "habibi" , BirthDate = DateTime.Now , RegisterDate = DateTime.Now},
            new Domain.Entites.Users(){Id = 2 , FirstName = "Mostafa" , LastName = "Alizadeh" , BirthDate = DateTime.Now , RegisterDate = DateTime.Now}
            };
            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(i => i.GetAll()).ReturnsAsync(users);
            return mockRepository;
        }
        public static Mock<IUserRepository> CreateUserRepository()
        {
            var users = new List<Domain.Entites.Users>()
            {
            new Domain.Entites.Users(){Id = 1 , FirstName = "Mojtaba" , LastName = "habibi" , BirthDate = DateTime.Now , RegisterDate = DateTime.Now},
            new Domain.Entites.Users(){Id = 2 , FirstName = "Mostafa" , LastName = "Alizadeh" , BirthDate = DateTime.Now , RegisterDate = DateTime.Now}
            };
            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(i => i.Add(It.IsAny<Domain.Entites.Users>()))
                  .ReturnsAsync((Domain.Entites.Users user) =>
                  {
                      users.Add(user);
                      return user;
                  });
            mockRepository.Setup(i => i.GetAll()).ReturnsAsync(users);
            return mockRepository;
        }
    }
}
