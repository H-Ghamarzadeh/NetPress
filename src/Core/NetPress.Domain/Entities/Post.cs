using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using NetPress.Domain.Common;

namespace NetPress.Domain.Entities
{
    [Index("Slug", "Type", IsUnique = true)]
    public class Post: BaseEntity
    {
        [Required]
        public string Type { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Content { get; set; }
        public string? Excerpt { get; set; }
        [Required]
        public string Slug { get; set; }
        public virtual ICollection<Category>? Categories { get; set; } = new List<Category>();
        public virtual ICollection<PostPicture>? Pictures { get; set; } = new List<PostPicture>();
    }
}
