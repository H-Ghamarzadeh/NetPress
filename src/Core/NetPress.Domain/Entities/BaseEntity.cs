using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NetPress.Domain.Entities
{
    [Index(nameof(IsDeleted), IsUnique = false)]
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
