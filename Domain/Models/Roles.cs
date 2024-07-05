using Shared.DataTransferObject;

namespace Domain.Models
{
    public class Roles : BaseModel
    {
        public string Name { get; set; }

        public int RoleLevel { get; set; }

        public IList<Users>? ListUsers { get; set; }

        public static RoleViewModel GenerateRoleViewModel(Roles? role) => new(
            role?.ID ?? 0, 
            role?.Name ?? "", 
            role?.RoleLevel ?? 0, 
            role?.ListUsers?.Select(Users.GenerateUserViewModelOnly).ToList() ?? [],
            role?.CreatedAt ?? DateTime.Now, 
            role?.CreatedBy ?? "", 
            role?.UpdatedAt, 
            role?.UpdatedBy);

        public static RoleViewModel GenerateRoleViewModelOnly(Roles? role) => new(
            role?.ID ?? 0, 
            role?.Name ?? "", 
            role?.RoleLevel ?? 0, 
            [],
            role?.CreatedAt ?? DateTime.Now, 
            role?.CreatedBy ?? "", 
            role?.UpdatedAt, 
            role?.UpdatedBy);

        public static Roles GenerateAddRoleFromDTO(AddRoleModel role) => new()
        {
            Name = role.Name,
            RoleLevel = role.RoleLevel,
            CreatedBy = role.CreatedBy,
        };

        public static Roles GenerateUpdateRoleFromDTO(Roles role, UpdateRoleModel data) => new()
        {
            ID = role.ID,
            CreatedAt = role.CreatedAt,
            CreatedBy = role.CreatedBy,
            Name = data.Name,
            RoleLevel = data.RoleLevel,
            UpdatedAt = data.UpdatedAt,
            UpdatedBy = data.UpdatedBy
        };
    }
}
