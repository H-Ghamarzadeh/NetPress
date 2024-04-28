using HGO.Hub.Interfaces.Requests;

// ReSharper disable once CheckNamespace
namespace NetPress.Application.Features
{
    public class GetLatestPostsListQuery(
        string? postType = null, 
        int? pageSize = null, 
        int? pageIndex = null) : IRequest<List<Domain.Entities.Post>>
    {
        public string? PostType { get; } = postType;
        public int? PageSize { get; } = pageSize;
        public int? PageIndex { get; } = pageIndex;
    }
}
