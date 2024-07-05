using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces;
using Domain.Models;
using Shared.DataTransferObject;
using Shared;
using System.Data;

namespace Domain.Services
{
    public class RoleService(IRepository<Roles> repository, IUnitOfWork unitOfWork) : BaseService<Roles>(repository, unitOfWork), IRoleService
    {
        public async Task<HttpResult<List<RoleViewModel>>> GetAllAsync()
        {
            var roles = await Repository.GetListAsync(a => true);

            if (roles.Count < 1)
            {
                return new HttpResult<List<RoleViewModel>>("Tidak ada data roles");
            }

            return new HttpResult<List<RoleViewModel>>(roles.Select(a => new RoleViewModel(
                a.ID,
                a.Name,
                a.RoleLevel,
                a.ListUsers?.Select(Users.GenerateUserViewModel).ToList() ?? [],
                a.CreatedAt,
                a.CreatedBy,
                a.UpdatedAt,
                a.UpdatedBy)
            ).ToList());
        }

        public async Task<HttpResult<RoleViewModel>> GetAsync(int id)
        {
            var role = await Repository.FindByIdAsync(id);

            if (role == null)
            {
                return new HttpResult<RoleViewModel>($"Data roles tidak ada: id = {id}");
            }

            return new HttpResult<RoleViewModel>(new RoleViewModel(
                role.ID,
                role.Name,
                role.RoleLevel,
                role.ListUsers?.Select(Users.GenerateUserViewModel).ToList() ?? [],
                role.CreatedAt,
                role.CreatedBy,
                role.UpdatedAt,
                role.UpdatedBy));
        }

        public async Task<HttpResult<RoleViewModel>> SaveAsync(AddRoleModel data)
        {
            var role = Roles.GenerateAddRoleFromDTO(data);

            try
            {
                await Repository.AddAsync(role);
                var result = await UnitOfWork.SaveChangesAsync();

                if (result < 1) throw new Exception("Data roles gagal tersimpan");


                var roleDTO = Roles.GenerateRoleViewModel(role);

                return new HttpResult<RoleViewModel>(roleDTO);
            }
            catch (Exception ex)
            {
                return new HttpResult<RoleViewModel>($"Terdapat kesalahan saat save data roles: {ex.Message}");
            }
        }

        public async Task<HttpResult<RoleViewModel>> UpdateAsync(int id, UpdateRoleModel data)
        {
            var role = await Repository.FindByIdAsync(id, tracking: false);

            if (role == null) return new HttpResult<RoleViewModel>("Data role tidak ditemukan");

            var updatedRole = Roles.GenerateUpdateRoleFromDTO(role, data);

            try
            {
                //await Repository.Attach(updatedRole);
                await Repository.UpdateAsync(updatedRole);
                await UnitOfWork.SaveChangesAsync();

                var roleDTO = Roles.GenerateRoleViewModel(updatedRole);

                return new HttpResult<RoleViewModel>(roleDTO);
            }
            catch (Exception ex)
            {
                return new HttpResult<RoleViewModel>(ex.Message);
            }
        }

        public async Task<HttpResult<RoleViewModel>> DeleteAsync(int id)
        {
            var role = await Repository.FindByIdAsync(id);

            if (role == null) return new HttpResult<RoleViewModel>("Data role tidak ditemukan");

            try
            {
                var success = await Repository.DeleteAsync(role);

                await UnitOfWork.SaveChangesAsync();

                var roleDTO = Roles.GenerateRoleViewModel(role);

                return new HttpResult<RoleViewModel>(roleDTO);
            }
            catch (Exception ex)
            {
                return new HttpResult<RoleViewModel>(ex.Message);
            }
        }
    }
}
