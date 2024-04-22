using HGO.Hub.Interfaces.Requests;
using NetPress.Application.Contracts.Persistence;

namespace NetPress.Application.Features.Post.Queries.GetPostsList
{
    public class GetPostsListQueryHandler(IPostRepository repository)
        : IRequestHandler<GetPostsListQuery, List<Domain.Entities.Post>>
    {
        public int Priority => 0;

        public async Task<List<Domain.Entities.Post>> Handle(GetPostsListQuery request)
        {
            return (await repository.GetAllAsync()).ToList();
        }
    }
}
