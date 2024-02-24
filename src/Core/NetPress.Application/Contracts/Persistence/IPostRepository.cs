using NetPress.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPress.Application.Contracts.Persistence
{
    public interface IPostRepository : IAsyncRepository<Post>
    {
    }
}
