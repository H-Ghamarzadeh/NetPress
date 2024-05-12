using Microsoft.EntityFrameworkCore;
using NetPress.Domain.Entities;

namespace NetPress.Persistence
{
    public class NetPressDbContext : DbContext
    {

        public NetPressDbContext(DbContextOptions<NetPressDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NetPressDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

            //Soft Delete
            modelBuilder.Entity<BaseEntity>().HasQueryFilter(p => !p.IsDeleted);
        }

        public override int SaveChanges()
        {
            OnBeforeSaving();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            OnBeforeSaving();
            
            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.IsDeleted = true;
                        break;
                }
            }
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<PostMetaData> PostMetaData { get; set; }
        public DbSet<PostPicture> PostPictures { get; set; }
        public DbSet<Taxonomy> Taxonomies { get; set; }
        public DbSet<TaxonomyMetaData> TaxonomyMetaData { get; set; }
        public DbSet<TaxonomyPicture> TaxonomyPictures { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<PictureMetaData> PictureMetaData { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentMetaData> CommentMetaData { get; set; }
        public DbSet<Option> Options { get; set; }
    }
}
