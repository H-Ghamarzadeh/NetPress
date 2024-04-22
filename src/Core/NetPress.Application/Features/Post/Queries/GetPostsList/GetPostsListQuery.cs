using HGO.Hub.Interfaces.Requests;

namespace NetPress.Application.Features
{
    public class GetPostsListQuery:IRequest<List<Domain.Entities.Post>>
    {
    }
}
