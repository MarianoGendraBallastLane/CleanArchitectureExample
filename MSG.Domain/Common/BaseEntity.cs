using System.ComponentModel.DataAnnotations;

namespace MSG.Domain.Common;

public abstract class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset? DateUpdated { get; set; }
    public DateTimeOffset? DateDeleted { get; set; }
}