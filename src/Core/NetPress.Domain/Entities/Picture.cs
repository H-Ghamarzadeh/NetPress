using NetPress.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace NetPress.Domain.Entities;

public class Picture : BaseEntity
{
    [Required]
    public required string Title { get; set; }
    public string? Alt { get; set; }
    public string? Description { get; set; }
    public int? Width { get; set; }
    public int? Height { get; set; }
    public string? Format { get; set; }
    [Required]
    public required string Url { get; set; }
}