using HGO.Hub.Interfaces.Requests;
using System.Linq.Expressions;

namespace NetPress.Application.Features
{
    public class GetPostDetailsQuery : IRequest<Domain.Entities.Post>
    {
        public int PostId { get; set; }
    }
}
