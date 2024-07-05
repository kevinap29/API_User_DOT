using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Domain.Services
{
    public abstract class BaseService<T>(IRepository<T> repository, IUnitOfWork unitOfWork) where T : BaseModel
    {
        protected internal IRepository<T> Repository => repository;
        protected internal IUnitOfWork UnitOfWork => unitOfWork;
    }
}
