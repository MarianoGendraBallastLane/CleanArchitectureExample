using System.ComponentModel.DataAnnotations;
using MSG.Domain.Common;

namespace MSG.Domain.Entities;

public sealed class User : BaseEntity
{
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string PasswordHash { get; set; } = string.Empty;
    [Required]
    public string Name { get; set; } = string.Empty;
}