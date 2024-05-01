using HGO.Hub.Interfaces.Requests;

// ReSharper disable once CheckNamespace
namespace NetPress.Application.Features
{
    public class GetPostDetailsQuery(int? postId, string? slug) : IRequest<Domain.Entities.Post>
    {
        public int? PostId { get; } = postId;
        public string? Slug { get; } = slug;
    }
}
