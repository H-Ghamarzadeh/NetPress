using HGO.Hub.Interfaces.Requests;
using System.Linq.Expressions;

namespace NetPress.Application.Features
{
    public class GetPostsListQuery:IRequest<List<Domain.Entities.Post>>
    {
        public int PageSize { get; set; } = 20;
        public int PageIndex { get; set; } = 0;
    }
}
