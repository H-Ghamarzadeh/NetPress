using HGO.Hub.Interfaces.Requests;
using System.Linq.Expressions;

// ReSharper disable once CheckNamespace
namespace NetPress.Application.Features
{
    public class GetPostsListQuery:IRequest<List<Domain.Entities.Post>>
    {
        public int? PageSize { get; set; } = 16;
        public int? PageIndex { get; set; } = 0;
    }
}
