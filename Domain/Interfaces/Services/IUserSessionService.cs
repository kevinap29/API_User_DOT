using Shared.DataTransferObject;
using Shared;

namespace Domain.Interfaces.Services
{
    public interface IUserSessionService
    {
        Task<HttpResult<List<UserSessionViewModel>>> GetAllAsync();
        Task<HttpResult<UserSessionViewModel>> GetAsync(int id);
        Task<HttpResult<UserSessionViewModel>> SaveAsync(AddUserSessionModel data);
        Task<HttpResult<UserSessionViewModel>> UpdateAsync(int id, UpdateUserSessionModel data);
        Task<HttpResult<UserSessionViewModel>> DeleteAsync(int id);
    }
}
