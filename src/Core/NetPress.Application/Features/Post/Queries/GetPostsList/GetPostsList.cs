using HGO.Hub.Interfaces.Requests;
using NetPress.Domain.Entities;

namespace NetPress.Application.Features.Post.Queries.GetPostsList
{
    public class GetPostsList:IRequest<IEnumerable<NetPress.Domain.Entities.Post>>
    {
    }
}
