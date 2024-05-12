using System.ComponentModel.DataAnnotations;

namespace NetPress.Domain.Entities;

public class TaxonomyPicture : BaseEntity
{
    [Required]
    public int PictureId { get; set; }
    [Required]
    public int TaxonomyId { get; set; }
    public int DisplayOrder { get; set; }
    public virtual Picture? Picture { get; set; } 
    public virtual Taxonomy? Taxonomy { get; set; }
}