using HGO.Hub;
using HGO.Hub.Interfaces.Requests;
using Microsoft.EntityFrameworkCore;
using NetPress.Application.Contracts.Persistence;

namespace NetPress.Application.Features.Post.Queries.GetLatestPostsList
{
    public class GetLatestPostsListQueryHandler(IPostRepository repository)
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

            var postType = (string.IsNullOrWhiteSpace(request.PostType) ? "post" : request.PostType).Trim().ToLower();

            return new (await repository.GetAsQueryable()
                .Where(p => p.Type == postType)
                .OrderByDescending(p => p.LastModifiedDate)
                .ThenByDescending(p => p.CreatedDate)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync());
        }
    }
}
