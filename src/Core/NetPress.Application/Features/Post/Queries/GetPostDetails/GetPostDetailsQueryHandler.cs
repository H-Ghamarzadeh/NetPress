using HGO.Hub.Interfaces.Requests;
using NetPress.Application.Contracts.Persistence;

namespace NetPress.Application.Features.Post.Queries.GetPostDetails
{
    public class GetPostDetailsQueryHandler(IPostRepository repository)
        : IRequestHandler<GetPostDetailsQuery, Domain.Entities.Post>
    {
        public int Priority => 0;

        public async Task<Domain.Entities.Post> Handle(GetPostDetailsQuery request) => await repository.GetByIdAsync(request.PostId, post => post.Categories);
    }
}
