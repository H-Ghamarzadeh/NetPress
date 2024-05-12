using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NetPress.Domain.Entities;

[Index("PictureId", IsUnique = false)]
[Index("Key", IsUnique = false)]
public class PictureMetaData : BaseEntity
{
    [Required]
    public int PictureId { get; set; }
    public virtual Picture? Picture { get; set; }
    [Required]
    public required string Key { get; set; }
    public string? Value { get; set; }
}