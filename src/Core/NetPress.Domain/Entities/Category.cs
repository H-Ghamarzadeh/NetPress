using System.ComponentModel.DataAnnotations;
using NetPress.Domain.Common;

namespace NetPress.Domain.Entities
{
    public class Category: BaseEntity
    {
        [Required]
        public string? Name { get; set; }
        public virtual ICollection<Post>? Posts { get; set; }
    }
}
