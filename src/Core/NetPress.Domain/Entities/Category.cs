﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetPress.Domain.Common;

namespace NetPress.Domain.Entities
{
    public class Category: BaseEntity
    {
        [Required]
        public string? Name { get; set; }
        public ICollection<Post>? Posts { get; set; }
    }
}
