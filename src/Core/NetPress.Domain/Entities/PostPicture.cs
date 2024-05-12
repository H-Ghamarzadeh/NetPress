using System.ComponentModel.DataAnnotations;

namespace NetPress.Domain.Entities;

public class PostPicture : BaseEntity
{
    [Required]
    public int PictureId { get; set; }
    [Required]
    public int PostId { get; set; }
    public int DisplayOrder { get; set; }

    public virtual Picture? Picture { get; set; }
    public virtual Post? Post { get; set; }
}