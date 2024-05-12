using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NetPress.Domain.Entities;

[Index(nameof(ParentCommentId), IsUnique = false)]
[Index(nameof(CommentAuthorEmail), IsUnique = false)]
[Index(nameof(CommentAuthorName), IsUnique = false)]
[Index(nameof(PostId), IsUnique = false)]
public class Comment : BaseEntity
{
    [Required]
    public required int PostId { get; set; }
    public virtual Post? Post { get; set; }
    [Required]
    public required string CommentContent { get; set; }
    public int? ParentCommentId { get; set; }
    public virtual Comment? ParentComment { get; set; }
    public required bool CommentIsApproved { get; set; } = false;
    public string? CommentAuthorName { get; set; }
    public string? CommentAuthorEmail { get; set; }
    public string? CommentAuthorUrl { get; set; }
    public string? CommentAuthorIp { get; set; }
    public virtual ICollection<CommentMetaData> CommentMetaData { get; set; } = new List<CommentMetaData>();
}