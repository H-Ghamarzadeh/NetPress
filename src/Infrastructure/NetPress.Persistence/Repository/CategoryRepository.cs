using Microsoft.EntityFrameworkCore;
using NetPress.Application.Contracts.Persistence;
using NetPress.Domain.Entities;

namespace NetPress.Persistence.Repository
{
    public class CategoryRepository(NetPressDbContext dbContext) : AsyncRepository<Category>(dbContext), ICategoryRepository
    {
        public override async Task<Category?> GetByIdAsync(int id)
        {
            return await dbContext.Categories.Include(p => p.Pictures)
                                             .ThenInclude(p => p.Picture)
                                             .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
