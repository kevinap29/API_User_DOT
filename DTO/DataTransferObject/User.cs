
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObject
{
    #region User
    public record UserViewModel(
        int ID,
        string Username,
        string Password,
        RoleViewModel? Role,
        DateTime CreatedAt,
        string CreatedBy,
        DateTime? UpdatedAt,
        string? UpdatedBy);

    public record AddUserModel(
        [StringLength(20, MinimumLength = 1)] string Username,
        string Password,
        [Range(0, 100)] int RoleID,
        [StringLength(20, MinimumLength = 1)] string CreatedBy);

    public record UpdateUserModel(
        [StringLength(20, MinimumLength = 1)] string Username,
        string Password,
        [Range(0, 100)] int RoleID,
        [Range(typeof(DateTime), "1980-01-01", "2045-01-01")] DateTime UpdatedAt,
        [StringLength(20, MinimumLength = 1)] string UpdatedBy);
    #endregion

    #region User Session
    public record UserSessionViewModel(
        int ID,
        string Token,
        DateTime ValidUntil,
        UserViewModel? User,
        DateTime CreatedAt,
        string CreatedBy,
        DateTime? UpdatedAt,
        string? UpdatedBy);

    public record AddUserSessionModel(
        int UserID,
        [StringLength(20, MinimumLength = 1)] string CreatedBy);

    public record UpdateUserSessionModel(
        string Token,
        [Range(typeof(DateTime), "1980-01-01", "2045-01-01")] DateTime ValidUntil,
        int UserID,
        [Range(typeof(DateTime), "1980-01-01", "2045-01-01")] DateTime UpdatedAt,
        [StringLength(20, MinimumLength = 1)] string UpdatedBy);
    #endregion
}
