using NetPress.Application.Contracts.Persistence;
using NetPress.Domain.Entities;

namespace NetPress.Persistence.Repository
{
    public class CategoryRepository(NetPressDbContext dbContext) : AsyncRepository<Category>(dbContext), ICategoryRepository
    {
    }
}
