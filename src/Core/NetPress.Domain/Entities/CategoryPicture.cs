using System.ComponentModel.DataAnnotations;
using NetPress.Domain.Common;

namespace NetPress.Domain.Entities;

public class CategoryPicture : BaseEntity
{
    [Required]
    public int PictureId { get; set; }
    [Required]
    public int CategoryId { get; set; }
    public int DisplayOrder { get; set; }
    [Required]
    public virtual Picture Picture { get; set; } 
    [Required]
    public virtual Category Category { get; set; }
}