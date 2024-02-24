using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetPress.Domain.Common;

namespace NetPress.Domain.Entities
{
    public class Post: BaseEntity
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public ICollection<Category>? Categories { get; set; }
    }
}
