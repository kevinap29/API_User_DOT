using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class UserRepository(DOTContext context) : BaseRepository<Users>(context)
    {
        private static IQueryable<Users> IncludeRelatedData(DbSet<Users> dbSet)
        {
            return dbSet.Include(a => a.Roles);
        }

        public override async Task<Users?> FindByIdAsync(int id, bool tracking = true)
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

        public override async Task<Users?> FindAsync(Expression<Func<Users, bool>> expression, bool tracking = true)
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

        public override async Task<List<Users>> GetListAsync(Expression<Func<Users, bool>> expression, bool tracking = true)
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

        public override Task<bool> DeleteAsync(Users entity)
        {
            return base.DeleteAsync(entity);
        }
    }
}
