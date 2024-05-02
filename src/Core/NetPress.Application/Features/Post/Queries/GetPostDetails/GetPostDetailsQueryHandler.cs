using HGO.Hub;
using HGO.Hub.Interfaces.Requests;
using NetPress.Application.Contracts.Persistence;
using NetPress.Application.Exceptions;

namespace NetPress.Application.Features.Post.Queries.GetPostDetails
{
    public class GetPostDetailsQueryHandler(IPostRepository repository)
        : IRequestHandler<GetPostDetailsQuery, Domain.Entities.Post>
    {
        public int Priority => 0;

        public async Task<RequestHandlerResult<Domain.Entities.Post>> Handle(GetPostDetailsQuery request)
        {
            if (string.IsNullOrWhiteSpace(request.Slug) && request.PostId == null)
            {
                throw new MissingOrInvalidOrNullPropertyValueException(request.GetType(), nameof(request.PostId), nameof(request.Slug));
            }

            Domain.Entities.Post? result = null;
            if (request.PostId != null)
                result = await repository.GetByIdAsync(request.PostId.Value);
            if(!string.IsNullOrWhiteSpace(request.Slug))
                result = await repository.GetBySlugAsync(request.Slug);

            if (result == null)
            {
                throw new EntityNotFoundException(typeof(Domain.Entities.Post), $"ID: {request.PostId}", $"Slug: {request.Slug}");
            }

            return new RequestHandlerResult<Domain.Entities.Post>(result);
        }
    }
}
