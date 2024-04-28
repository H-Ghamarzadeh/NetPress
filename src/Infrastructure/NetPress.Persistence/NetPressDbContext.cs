using Microsoft.EntityFrameworkCore;
using NetPress.Domain.Common;
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
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
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
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<PostPicture> PostPictures { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryPicture> CategoryPictures { get; set; }
        public DbSet<Picture> Pictures { get; set; }
    }
}
