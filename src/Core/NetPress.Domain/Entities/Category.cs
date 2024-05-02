using System.ComponentModel.DataAnnotations;
using NetPress.Domain.Common;

namespace NetPress.Domain.Entities
{
    public class Category: BaseEntity
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Slug { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Post>? Posts { get; set; } = new List<Post>();
        public virtual ICollection<CategoryPicture>? Pictures { get; set; } = new List<CategoryPicture>();
    }
}
