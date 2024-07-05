
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObject
{
    public record RoleViewModel(
        int ID,
        string Name,
        int RoleLevel,
        IList<UserViewModel>? ListUsers,
        DateTime CreatedAt,
        string CreatedBy,
        DateTime? UpdatedAt,
        string? UpdatedBy);

    public record AddRoleModel(
        [StringLength(50, MinimumLength = 1)] string Name,
        [Range(0, 100)] int RoleLevel,
        [StringLength(20, MinimumLength = 1)] string CreatedBy);

    public record UpdateRoleModel(
        [StringLength(50, MinimumLength = 1)] string Name,
        [Range(0, 100)] int RoleLevel,
        [Range(typeof(DateTime), "1980-01-01", "2045-01-01")] DateTime UpdatedAt,
        [StringLength(20, MinimumLength = 1)] string UpdatedBy);


}
