using Microsoft.EntityFrameworkCore;
using NetPress.Application.Contracts.Persistence;
using NetPress.Domain.Entities;

namespace NetPress.Persistence.Repository
{
    public class PostRepository(NetPressDbContext dbContext) : AsyncRepository<Post>(dbContext), IPostRepository
    {
        public override async Task<Post?> GetByIdAsync(int id)
        {
            return await dbContext.Posts.Include(p => p.PostTaxonomies)
                                        .Include(p => p.PostMetaData)
                                        .Include(p => p.PostPictures)
                                        .ThenInclude(p => p.Picture)
                                        .ThenInclude(p => p.PictureMetaData)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Post?> GetBySlugAsync(string slug)
        {
            return await dbContext.Posts.Include(p => p.PostTaxonomies)
                .Include(p => p.PostMetaData)
                .Include(p => p.PostPictures)
                .ThenInclude(p => p.Picture)
                .ThenInclude(p => p.PictureMetaData)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PostSlug == slug);
        }

        public async Task<List<Post>> GetLatestPostsAsync(string postType, int pageSize, int pageIndex)
        {
            return await GetAsQueryable()
                .Where(p => p.PostType == postType)
                .OrderByDescending(p => p.LastModifiedDate)
                .ThenByDescending(p => p.CreatedDate)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
