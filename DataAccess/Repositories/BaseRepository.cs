using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class BaseRepository<T>(DOTContext dbContext) : IRepository<T> where T : BaseModel
    {
        protected DbSet<T> DbSet => dbContext.Set<T>();

        public async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
        }

        public Task UpdateAsync(T entity)
        {
            DbSet.Update(entity);
            return Task.FromResult(entity);
        }

        public virtual Task<bool> DeleteAsync(T entity)
        {
            DbSet.Remove(entity);
            return Task.FromResult(true);
        }

        public virtual async Task<T?> FindByIdAsync(int id, bool tracking = true)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<T?> FindAsync(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            return await DbSet.SingleOrDefaultAsync(expression);
        }

        public virtual async Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            return await DbSet.Where(expression).ToListAsync();
        }

        public async Task Attach(T data)
        {
            await Task.Run(() =>
            {
                DbSet.Attach(data);
            });
        }
    }
}
