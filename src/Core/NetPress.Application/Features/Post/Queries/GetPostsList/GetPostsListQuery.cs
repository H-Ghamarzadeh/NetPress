using HGO.Hub.Interfaces.Requests;
using NetPress.Domain.Entities;

namespace NetPress.Application.Features.Post.Queries.GetPostsList
{
    public class GetPostsListQuery:IRequest<List<NetPress.Domain.Entities.Post>>
    {
    }
}
