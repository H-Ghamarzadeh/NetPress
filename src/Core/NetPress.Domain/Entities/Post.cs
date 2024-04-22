using System.ComponentModel.DataAnnotations;
using NetPress.Domain.Common;

namespace NetPress.Domain.Entities
{
    public class Post: BaseEntity
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Content { get; set; }
        public string? Excerpt { get; set; }
        [Required]
        public string? Slug { get; set; }
        public ICollection<Category>? Categories { get; set; }
    }
}
