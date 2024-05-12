using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NetPress.Domain.Entities
{
    [Index(nameof(TaxonomySlug), nameof(TaxonomyType), IsUnique = true)]
    public class Taxonomy : BaseEntity
    {
        [Required]
        public required string TaxonomyName { get; set; }
        [Required]
        public required string TaxonomySlug { get; set; }
        [Required]
        public required string TaxonomyType { get; set; }
        public string? TaxonomyDescription { get; set; }
        public int? ParentTaxonomyId { get; set; }
        public virtual Taxonomy? ParentTaxonomy { get; set; }
        public virtual ICollection<Post> TaxonomyPosts { get; set; } = new List<Post>();
        public virtual ICollection<TaxonomyPicture> TaxonomyPictures { get; set; } = new List<TaxonomyPicture>();
        public virtual ICollection<TaxonomyMetaData> TaxonomyMetaData { get; set; } = new List<TaxonomyMetaData>();
    }
}
