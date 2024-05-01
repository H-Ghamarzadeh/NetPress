using Microsoft.EntityFrameworkCore;
using NetPress.Application.Contracts.Persistence;
using NetPress.Domain.Entities;

namespace NetPress.Persistence.Repository
{
    public class PostRepository(NetPressDbContext dbContext) : AsyncRepository<Post>(dbContext), IPostRepository
    {
        public override async Task<Post?> GetByIdAsync(int id)
        {
            return await dbContext.Posts.Include(p => p.Categories)
                                        .Include(p => p.Pictures)
                                        .ThenInclude(p => p.Picture)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Post?> GetBySlugAsync(string slug)
        {
            return await dbContext.Posts.Include(p => p.Categories)
                .Include(p => p.Pictures)
                .ThenInclude(p => p.Picture)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Slug == slug);
        }
    }
}
