using System.ComponentModel.DataAnnotations;
using NetPress.Domain.Common;

namespace NetPress.Domain.Entities;

public class TaxonomyPicture : BaseEntity
{
    [Required]
    public int PictureId { get; set; }
    [Required]
    public int TaxonomyId { get; set; }
    public int DisplayOrder { get; set; }
    [Required]
    public virtual required Picture Picture { get; set; } 
    [Required]
    public virtual required Taxonomy Taxonomy { get; set; }
}