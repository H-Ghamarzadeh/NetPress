using NetPress.Application.Contracts.Persistence;
using NetPress.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPress.Persistence.Repository
{
    public class PostRepository(NetPressDbContext dbContext) : AsyncRepository<Post>(dbContext), IPostRepository
    {
    }
}
