using System.ComponentModel.DataAnnotations;
using NetPress.Domain.Common;

namespace NetPress.Domain.Entities
{
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
