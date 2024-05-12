using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NetPress.Domain.Entities
{
    [Index(nameof(PostSlug),nameof(PostType), IsUnique = true)]
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
        public virtual ICollection<Taxonomy> PostTaxonomies { get; set; } = new List<Taxonomy>();
        public virtual ICollection<PostPicture> PostPictures { get; set; } = new List<PostPicture>();
        public virtual ICollection<PostMetaData> PostMetaData { get; set; } = new List<PostMetaData>();
    }
}
