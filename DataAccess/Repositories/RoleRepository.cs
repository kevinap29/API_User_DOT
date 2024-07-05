using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class RoleRepository(DOTContext context) : BaseRepository<Roles>(context)
    {
        private static IQueryable<Roles> IncludeRelatedData(DbSet<Roles> dbSet)
        {
            return dbSet.Include(a => a.ListUsers);
        }

        public override async Task<Roles?> FindByIdAsync(int id, bool tracking = true)
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

        public override async Task<Roles?> FindAsync(Expression<Func<Roles, bool>> expression, bool tracking = true)
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

        public override async Task<List<Roles>> GetListAsync(Expression<Func<Roles, bool>> expression, bool tracking = true)
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

        public override Task<bool> DeleteAsync(Roles entity)
        {
            return base.DeleteAsync(entity);
        }
    }
}
