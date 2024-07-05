using Shared.DataTransferObject;
using System.Text;

namespace Domain.Models
{
    public class Users : BaseModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public int RoleID { get; set; }

        public Roles? Roles { get; set; }

        public IList<User_Sessions>? ListUser_Sessions { get; set; }

        public static UserViewModel GenerateUserViewModel(Users? user) => new(
            user?.ID ?? 0,
            user?.Username ?? "",
            user?.Password ?? "",
            Roles.GenerateRoleViewModelOnly(user?.Roles),
            user?.CreatedAt ?? DateTime.Now,
            user?.CreatedBy ?? "",
            user?.UpdatedAt,
            user?.UpdatedBy);

        public static UserViewModel GenerateUserViewModelOnly(Users? user) => new(
            user?.ID ?? 0,
            user?.Username ?? "",
            user?.Password ?? "",
            Roles.GenerateRoleViewModelOnly(user?.Roles),
            user?.CreatedAt ?? DateTime.Now,
            user?.CreatedBy ?? "",
            user?.UpdatedAt,
            user?.UpdatedBy);

        public static Users GenerateAddUserFromDTO(AddUserModel user) => new()
        {
            Username = user.Username,
            Password = user.Password,
            RoleID = user.RoleID,
            CreatedBy = user.CreatedBy,
        };
        
        public static Users GenerateUpdateUserFromDTO(Users user, UpdateUserModel data) => new()
        {
            ID = user.ID,
            CreatedAt = user.CreatedAt,
            CreatedBy = user.CreatedBy,
            RoleID = data.RoleID,
            Username = data.Username,
            Password = data.Password,
            UpdatedAt = data.UpdatedAt,
            UpdatedBy = data.UpdatedBy
        };
    }

    public class User_Sessions : BaseModel
    {
        public string Token { get; set; }

        public DateTime ValidUntil { get; set; }

        public int UserID { get; set; }

        public Users? Users { get; set; }

        public static UserSessionViewModel GenerateUserSessionViewModel(User_Sessions? user_sess) => new(
            user_sess?.ID ?? 0,
            user_sess?.Token ?? "",
            user_sess?.ValidUntil ?? DateTime.Now,
            Users.GenerateUserViewModelOnly(user_sess?.Users),
            user_sess?.CreatedAt ?? DateTime.Now,
            user_sess?.CreatedBy ?? "",
            user_sess?.UpdatedAt,
            user_sess?.UpdatedBy);

        public static UserSessionViewModel GenerateUserSessionViewModelOnly(User_Sessions? user_sess) => new(
            user_sess?.ID ?? 0,
            user_sess?.Token ?? "",
            user_sess?.ValidUntil ?? DateTime.Now,
            Users.GenerateUserViewModelOnly(user_sess?.Users),
            user_sess?.CreatedAt ?? DateTime.Now,
            user_sess?.CreatedBy ?? "",
            user_sess?.UpdatedAt,
            user_sess?.UpdatedBy);

        public static User_Sessions GenerateAddUserSessionFromDTO(AddUserSessionModel user_sess) => new()
        {
            Token = Convert.ToBase64String(Encoding.UTF8.GetBytes($"test_{DateTime.Now}")),
            ValidUntil = DateTime.Now.AddHours(3),
            UserID = user_sess.UserID,
            CreatedBy = user_sess.CreatedBy,
        };

        public static User_Sessions GenerateUpdateUserSessionFromDTO(User_Sessions user_sess, UpdateUserSessionModel data) => new()
        {
            ID = user_sess.ID,
            CreatedAt = user_sess.CreatedAt,
            CreatedBy = user_sess.CreatedBy,
            UserID = data.UserID,
            Token = data.Token,
            ValidUntil = data.ValidUntil,
            UpdatedAt = data.UpdatedAt,
            UpdatedBy = data.UpdatedBy
        };
    }
}
