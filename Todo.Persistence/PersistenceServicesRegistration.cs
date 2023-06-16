using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Contracts.Persistence;
using Todo.Persistence.Repositories;

namespace Todo.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurationPersistenceservice(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => { options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString")); });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITodoItemRepository, TodoItemRepository>();
            return services;
        }
    }
}
