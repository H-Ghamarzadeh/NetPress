using System.ComponentModel.DataAnnotations;

namespace NetPress.Domain.Common
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
