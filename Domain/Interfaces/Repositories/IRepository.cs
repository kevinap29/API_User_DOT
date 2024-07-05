using Domain.Models;
using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task<bool> DeleteAsync(T entity);

        Task<T?> FindByIdAsync(int id, bool tracking = true);

        Task<T?> FindAsync(Expression<Func<T, bool>> expression, bool tracking = true);

        Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression, bool tracking = true);
        
        Task Attach(T data);
    }
}
