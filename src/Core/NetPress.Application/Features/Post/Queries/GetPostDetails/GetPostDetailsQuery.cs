using HGO.Hub.Interfaces.Requests;

// ReSharper disable once CheckNamespace
namespace NetPress.Application.Features
{
    public class GetPostDetailsQuery(int postId) : IRequest<Domain.Entities.Post>
    {
        public int PostId { get; } = postId;
    }
}
