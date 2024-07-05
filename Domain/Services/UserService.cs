using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Shared;
using Shared.DataTransferObject;
using System.Data;

namespace Domain.Services
{
    public class UserService(IRepository<Users> repository, IUnitOfWork unitOfWork) : BaseService<Users>(repository, unitOfWork), IUserService
    {
        public async Task<HttpResult<List<UserViewModel>>> GetAllAsync()
        {
            var users = await Repository.GetListAsync(a => true);

            if (users.Count < 1)
            {
                return new HttpResult<List<UserViewModel>>("Tidak ada data users");
            }

            return new HttpResult<List<UserViewModel>>(users.Select(a => new UserViewModel(
                a.ID,
                a.Username,
                a.Password,
                Roles.GenerateRoleViewModel(a.Roles),
                a.CreatedAt,
                a.CreatedBy,
                a.UpdatedAt,
                a.UpdatedBy)
            ).ToList());
            
        }

        public async Task<HttpResult<UserViewModel>> GetAsync(int id)
        {
            var user = await Repository.FindByIdAsync(id);

            if (user == null) 
            {
                return new HttpResult<UserViewModel>($"Data users tidak ada: id = {id}");
            }

            return new HttpResult<UserViewModel>(new UserViewModel(
                user.ID,
                user.Username,
                user.Password,
                Roles.GenerateRoleViewModel(user.Roles),
                user.CreatedAt,
                user.CreatedBy,
                user.UpdatedAt,
                user.UpdatedBy));
        }

        public async Task<HttpResult<UserViewModel>> SaveAsync(AddUserModel data)
        {
            var user = Users.GenerateAddUserFromDTO(data);

            try
            {
                await Repository.AddAsync(user);
                var result = await UnitOfWork.SaveChangesAsync();

                if (result < 1) throw new Exception("Data users gagal tersimpan");


                var userDTO = Users.GenerateUserViewModel(user);

                return new HttpResult<UserViewModel>(userDTO);
            }
            catch (Exception ex)
            {
                return new HttpResult<UserViewModel>($"Terdapat kesalahan saat save data users: {ex.Message}");
            }
        }

        public async Task<HttpResult<UserViewModel>> UpdateAsync(int id, UpdateUserModel data)
        {
            var user = await Repository.FindByIdAsync(id, tracking: false);

            if (user == null) return new HttpResult<UserViewModel>("Data user tidak ditemukan");

            var updatedUser = Users.GenerateUpdateUserFromDTO(user, data);

            try
            {
                //await Repository.Attach(updatedUser);
                await Repository.UpdateAsync(updatedUser);
                await UnitOfWork.SaveChangesAsync();

                var userDTO = Users.GenerateUserViewModel(updatedUser);

                return new HttpResult<UserViewModel>(userDTO);
            }
            catch(Exception ex)
            {
                return new HttpResult<UserViewModel>(ex.Message);
            }
        }

        public async Task<HttpResult<UserViewModel>> DeleteAsync(int id)
        {
            var user = await Repository.FindByIdAsync(id);

            if (user == null) return new HttpResult<UserViewModel>("Data user tidak ditemukan");

            try
            {
                var success = await Repository.DeleteAsync(user);

                await UnitOfWork.SaveChangesAsync();

                var userDTO = Users.GenerateUserViewModel(user);

                return new HttpResult<UserViewModel>(userDTO);
            }
            catch( Exception ex)
            {
                return new HttpResult<UserViewModel>(ex.Message);
            }
        }
    }
}
