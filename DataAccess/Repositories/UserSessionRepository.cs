using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class UserSessionRepository(DOTContext context) : BaseRepository<User_Sessions>(context)
    {
        private static IQueryable<User_Sessions> IncludeRelatedData(DbSet<User_Sessions> dbSet)
        {
            return dbSet.Include(a => a.Users);
        }

        public override async Task<User_Sessions?> FindByIdAsync(int id, bool tracking = true)
        {
            if (tracking)
            {
                return await IncludeRelatedData(DbSet).Where(a => a.ID == id).FirstOrDefaultAsync();
            }
            else
            {
                return await IncludeRelatedData(DbSet).AsNoTracking().Where(a => a.ID == id).FirstOrDefaultAsync();
            }
        }

        public override async Task<User_Sessions?> FindAsync(Expression<Func<User_Sessions, bool>> expression, bool tracking = true)
        {
            if (tracking)
            {
                return await IncludeRelatedData(DbSet).Where(expression).FirstOrDefaultAsync();
            }
            else
            {
                return await IncludeRelatedData(DbSet).AsNoTracking().Where(expression).FirstOrDefaultAsync();
            }
        }

        public override async Task<List<User_Sessions>> GetListAsync(Expression<Func<User_Sessions, bool>> expression, bool tracking = true)
        {
            if (tracking)
            {
                return await IncludeRelatedData(DbSet).Where(expression).ToListAsync();
            }
            else
            {
                return await IncludeRelatedData(DbSet).AsNoTracking().Where(expression).ToListAsync();
            }
        }

        public override Task<bool> DeleteAsync(User_Sessions entity)
        {
            return base.DeleteAsync(entity);
        }
    }
}
