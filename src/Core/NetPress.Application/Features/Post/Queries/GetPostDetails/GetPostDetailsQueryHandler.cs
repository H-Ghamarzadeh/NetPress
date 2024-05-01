using HGO.Hub;
using HGO.Hub.Interfaces.Requests;
using NetPress.Application.Contracts.Persistence;

namespace NetPress.Application.Features.Post.Queries.GetPostDetails
{
    public class GetPostDetailsQueryHandler(IPostRepository repository)
        : IRequestHandler<GetPostDetailsQuery, Domain.Entities.Post>
    {
        public int Priority => 0;

        public async Task<RequestHandlerResult<Domain.Entities.Post>> Handle(GetPostDetailsQuery request)
        {
            if(request.PostId != null)
                return new RequestHandlerResult<Domain.Entities.Post>(await repository.GetByIdAsync(request.PostId.Value));
            if(!string.IsNullOrWhiteSpace(request.Slug))
                return new RequestHandlerResult<Domain.Entities.Post>(await repository.GetBySlugAsync(request.Slug));

            return new RequestHandlerResult<Domain.Entities.Post>(null);
        }
    }
}
