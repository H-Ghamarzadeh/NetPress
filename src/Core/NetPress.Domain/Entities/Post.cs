using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using NetPress.Domain.Common;

namespace NetPress.Domain.Entities
{
    [Index("PostSlug", "PostType", IsUnique = true)]
    public class Post: BaseEntity
    {
        [Required]
        public required string PostType { get; set; }
        [Required]
        public required string PostTitle { get; set; }
        public string? PostContent { get; set; }
        public string? PostExcerpt { get; set; }
        [Required]
        public required string PostSlug { get; set; }
        public virtual ICollection<Category>? PostCategories { get; set; } = new List<Category>();
        public virtual ICollection<PostPicture>? PostPictures { get; set; } = new List<PostPicture>();
    }
}
