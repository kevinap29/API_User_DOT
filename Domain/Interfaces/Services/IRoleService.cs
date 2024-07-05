using Shared.DataTransferObject;
using Shared;

namespace Domain.Interfaces.Services
{
    public interface IRoleService
    {
        Task<HttpResult<List<RoleViewModel>>> GetAllAsync();
        Task<HttpResult<RoleViewModel>> GetAsync(int id);
        Task<HttpResult<RoleViewModel>> SaveAsync(AddRoleModel data);
        Task<HttpResult<RoleViewModel>> UpdateAsync(int id, UpdateRoleModel data);
        Task<HttpResult<RoleViewModel>> DeleteAsync(int id);
    }
}
