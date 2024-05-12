using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NetPress.Domain.Entities;

[Index(nameof(TaxonomyId), IsUnique = false)]
[Index(nameof(Key), IsUnique = false)]
public class TaxonomyMetaData : BaseEntity
{
    [Required]
    public int TaxonomyId { get; set; }
    public virtual Taxonomy? Taxonomy { get; set; }
    [Required]
    public required string Key { get; set; }
    public string? Value { get; set; }
}