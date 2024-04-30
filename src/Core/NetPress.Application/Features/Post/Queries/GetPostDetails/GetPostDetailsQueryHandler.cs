using HGO.Hub;
using HGO.Hub.Interfaces.Requests;
using NetPress.Application.Contracts.Persistence;

namespace NetPress.Application.Features.Post.Queries.GetPostDetails
{
    public class GetPostDetailsQueryHandler(IPostRepository repository)
        : IRequestHandler<GetPostDetailsQuery, Domain.Entities.Post>
    {
        public int Priority => 0;

        public async Task<RequestHandlerResult<Domain.Entities.Post>> Handle(GetPostDetailsQuery request) =>
            new(await repository.GetByIdAsync(request.PostId));
    }
}
