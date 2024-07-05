using Domain.Interfaces;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DOTContext _dbContext;

        public UnitOfWork(DOTContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
