using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces;
using Domain.Models;
using Shared.DataTransferObject;
using Shared;

namespace Domain.Services
{
    public class UserSessionService(IRepository<User_Sessions> repository, IUnitOfWork unitOfWork) : BaseService<User_Sessions>(repository, unitOfWork), IUserSessionService
    {
        public async Task<HttpResult<List<UserSessionViewModel>>> GetAllAsync()
        {
            var user_sess = await Repository.GetListAsync(a => true);

            if (user_sess.Count < 1)
            {
                return new HttpResult<List<UserSessionViewModel>>("Tidak ada data user_sessions");
            }

            return new HttpResult<List<UserSessionViewModel>>(user_sess.Select(a => new UserSessionViewModel(
                a.ID,
                a.Token,
                a.ValidUntil,
                Users.GenerateUserViewModel(a.Users),
                a.CreatedAt,
                a.CreatedBy,
                a.UpdatedAt,
                a.UpdatedBy)
            ).ToList());

        }

        public async Task<HttpResult<UserSessionViewModel>> GetAsync(int id)
        {
            var user_sess = await Repository.FindByIdAsync(id);

            if (user_sess == null)
            {
                return new HttpResult<UserSessionViewModel>($"Data user_sessions tidak ada: id = {id}");
            }

            return new HttpResult<UserSessionViewModel>(new UserSessionViewModel(
                user_sess.ID,
                user_sess.Token,
                user_sess.ValidUntil,
                Users.GenerateUserViewModel(user_sess.Users),
                user_sess.CreatedAt,
                user_sess.CreatedBy,
                user_sess.UpdatedAt,
                user_sess.UpdatedBy));
        }

        public async Task<HttpResult<UserSessionViewModel>> SaveAsync(AddUserSessionModel data)
        {
            var user_sess = User_Sessions.GenerateAddUserSessionFromDTO(data);

            try
            {
                await Repository.AddAsync(user_sess);
                var result = await UnitOfWork.SaveChangesAsync();

                if (result < 1) throw new Exception("Data user_sessions gagal tersimpan");


                var user_sessDTO = User_Sessions.GenerateUserSessionViewModel(user_sess);

                return new HttpResult<UserSessionViewModel>(user_sessDTO);
            }
            catch (Exception ex)
            {
                return new HttpResult<UserSessionViewModel>($"Terdapat kesalahan saat save data user_sessions: {ex.Message}");
            }
        }

        public async Task<HttpResult<UserSessionViewModel>> UpdateAsync(int id, UpdateUserSessionModel data)
        {
            var user_sess = await Repository.FindByIdAsync(id, tracking: false);

            if (user_sess == null) return new HttpResult<UserSessionViewModel>("Data user_sessions tidak ditemukan");

            var updatedUserSession = User_Sessions.GenerateUpdateUserSessionFromDTO(user_sess, data);

            try
            {
                //await Repository.Attach(updatedUserSession);
                await Repository.UpdateAsync(updatedUserSession);
                await UnitOfWork.SaveChangesAsync();

                var userDTO = User_Sessions.GenerateUserSessionViewModel(updatedUserSession);

                return new HttpResult<UserSessionViewModel>(userDTO);
            }
            catch (Exception ex)
            {
                return new HttpResult<UserSessionViewModel>(ex.Message);
            }
        }

        public async Task<HttpResult<UserSessionViewModel>> DeleteAsync(int id)
        {
            var user_sess = await Repository.FindByIdAsync(id);

            if (user_sess == null) return new HttpResult<UserSessionViewModel>("Data user_sessions tidak ditemukan");

            try
            {
                var success = await Repository.DeleteAsync(user_sess);

                await UnitOfWork.SaveChangesAsync();

                var userDTO = User_Sessions.GenerateUserSessionViewModel(user_sess);

                return new HttpResult<UserSessionViewModel>(userDTO);
            }
            catch (Exception ex)
            {
                return new HttpResult<UserSessionViewModel>(ex.Message);
            }
        }
    }
}
