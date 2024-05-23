using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NetPress.Domain.Entities;

[Index(nameof(UserId), IsUnique = false)]
[Index(nameof(Key), IsUnique = false)]
public class UserMetaData : BaseEntity
{
    [Required]
    public required string UserId { get; set; }
    public virtual User? User { get; set; }
    [Required]
    public required string Key { get; set; }
    public string? Value { get; set; }
}