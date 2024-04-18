using HGO.Hub.Interfaces.Requests;
using NetPress.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPress.Application.Features.Post.Queries.GetPostsList
{
    public class GetPostsListQueryHandler : IRequestHandler<GetPostsListQuery, List<NetPress.Domain.Entities.Post>>
    {
        private readonly IPostRepository postRepository;

        public GetPostsListQueryHandler(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }
        public int Priority => 0;

        public async Task<List<NetPress.Domain.Entities.Post>> Handle(GetPostsListQuery request)
        {
            return (await postRepository.GetAllAsync()).ToList();
        }
    }
}
