
using Shared;
using Shared.DataTransferObject;

namespace Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<HttpResult<List<UserViewModel>>> GetAllAsync();
        Task<HttpResult<UserViewModel>> GetAsync(int id);
        Task<HttpResult<UserViewModel>> SaveAsync(AddUserModel data);
        Task<HttpResult<UserViewModel>> UpdateAsync(int id, UpdateUserModel data);
        Task<HttpResult<UserViewModel>> DeleteAsync(int id);
    }
}
