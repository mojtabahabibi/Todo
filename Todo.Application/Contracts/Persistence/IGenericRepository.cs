using System.Collections.Generic;
using System.Threading.Tasks;

namespace Todo.Application.Contracts.Persistence
{
    public interface IGenericRepository <T> where T : class
    {
        Task<IReadOnlyCollection<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<bool> Exist(int id);
    }
}
