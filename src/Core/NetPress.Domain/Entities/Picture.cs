using System.ComponentModel.DataAnnotations;

namespace NetPress.Domain.Entities;

public class Picture : BaseEntity
{
    [Required]
    public required string Title { get; set; }
    public string? Alt { get; set; }
    public int? Width { get; set; }
    public int? Height { get; set; }
    public string? Format { get; set; }
    [Required]
    public required string Url { get; set; }
    public virtual ICollection<PictureMetaData> PictureMetaData { get; set; } = new List<PictureMetaData>();
}