using HGO.Hub;
using HGO.Hub.Interfaces;
using HGO.Hub.Interfaces.Requests;
using NetPress.Application.Contracts.Persistence;
using NetPress.Domain.Constants;

namespace NetPress.Application.Features.Post.Queries.GetLatestPostsList
{
    public class GetLatestPostsListQueryHandler(IPostRepository repository, IHub hub)
        : IRequestHandler<GetLatestPostsListQuery, List<Domain.Entities.Post>>
    {
        public int Priority => 0;

        public async Task<RequestHandlerResult<List<Domain.Entities.Post>>> Handle(GetLatestPostsListQuery request)
        {
            var pageSize = request.PageSize ?? 16;
            if (pageSize <= 0)
            {
                pageSize = 1;
            }

            var pageIndex = request.PageIndex ?? 1;
            if (pageIndex <= 0)
            {
                pageIndex = 1;
            }
            pageIndex--;

            var postType = string.IsNullOrWhiteSpace(request.PostType) ? PostsType.BlogPost : request.PostType;

            var result = await hub.ApplyFiltersAsync(await repository.GetLatestPostsAsync(postType, pageSize, pageIndex));

            return new(result);
        }
    }
}
