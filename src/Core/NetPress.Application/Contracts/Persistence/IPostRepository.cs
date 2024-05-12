using NetPress.Domain.Entities;

namespace NetPress.Application.Contracts.Persistence
{
    public interface IPostRepository : IAsyncRepository<Post>
    {
        Task<Post?> GetBySlugAsync(string slug);
        Task<List<Post>> GetLatestPostsAsync(string postType, int pageSize, int pageIndex);
    }
}
