using HGO.Hub.Interfaces.Requests;
using NetPress.Application.Contracts.Persistence;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NetPress.Application.Features.Post.Queries.GetPostsList
{
    public class GetPostsListQueryHandler(IPostRepository repository)
        : IRequestHandler<GetPostsListQuery, List<Domain.Entities.Post>>
    {
        public int Priority => 0;

        public async Task<List<Domain.Entities.Post>> Handle(GetPostsListQuery request)
        {
            return await repository.GetAsQueryable().OrderByDescending(p => p.LastModifiedDate)
                .ThenByDescending(p => p.CreatedDate).Skip(request.PageSize * request.PageIndex).Take(request.PageSize)
                .ToListAsync();
        }
    }
}
