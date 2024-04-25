using HGO.Hub.Interfaces.Requests;

// ReSharper disable once CheckNamespace
namespace NetPress.Application.Features
{
    public class GetPostDetailsQuery : IRequest<Domain.Entities.Post>
    {
        public int PostId { get; set; }
    }
}
