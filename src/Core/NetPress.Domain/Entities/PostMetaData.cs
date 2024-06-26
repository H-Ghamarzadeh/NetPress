﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NetPress.Domain.Entities;

[Index(nameof(PostId), IsUnique = false)]
[Index(nameof(Key), IsUnique = false)]
public class PostMetaData: BaseEntity
{
    [Required]
    public int PostId { get; set; }
    public virtual Post? Post { get; set; }
    [Required]
    public required string Key { get; set; }
    public string? Value { get; set; }
}