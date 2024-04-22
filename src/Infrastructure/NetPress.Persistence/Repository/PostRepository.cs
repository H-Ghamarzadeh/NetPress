using NetPress.Application.Contracts.Persistence;
using NetPress.Domain.Entities;

namespace NetPress.Persistence.Repository
{
    public class PostRepository(NetPressDbContext dbContext) : AsyncRepository<Post>(dbContext), IPostRepository
    {
    }
}
